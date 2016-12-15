using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DBInitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dlgScriptsFolderBrowser.ShowNewFolderButton = false;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtDBHost.Text.Length == 0)
                this.txtDBHost.BackColor = System.Drawing.Color.Red;

            if (this.txtScriptsFolder.Text.Length == 0)
                this.txtScriptsFolder.BackColor = System.Drawing.Color.Red;

            DbConnectionStringBuilder dbsb = new DbConnectionStringBuilder();
            dbsb.Add("Data Source", this.txtDBHost.Text);
            dbsb.Add("Initial Catalog", "master");
            dbsb.Add("Trusted_Connection", "yes");

            IEnumerable<string> files = Directory.EnumerateFiles(this.txtScriptsFolder.Text, "*.sql");
            List<string> scripts = new List<string>(files);
            scripts.Sort();
            DBInitter.Configs.KnownPaths.Add(this.txtScriptsFolder.Text);

            this.toolStripStatusLabelStatus.Text = "Running";
            this.toolStripLabelCurrentFile.Visible = true;
            this.toolStripProgressBar.Value = 0;

            using (SqlConnection conn = new SqlConnection(dbsb.ConnectionString))
            {
                conn.Open();
                DBInitter.Configs.KnownHosts.Add(this.txtDBHost.Text);

                //using (SqlTransaction trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                //{
                this.toolStripProgressBar.Maximum = scripts.Count();

                foreach (string script in scripts)
                {
                    this.toolStripLabelCurrentFile.Text = script;
                    System.Text.RegularExpressions.Regex re = new Regex(@"([1-9][0-9]{2,})\s*-");
                    Match mc = re.Match(script);

                    int scriptVersion = 0;
                    if (mc.Success)
                    {
                        scriptVersion = Int32.Parse(mc.Groups[1].ToString());
                    }

                    //Thread.Sleep(1000);
                    string query = File.ReadAllText(script);

                    foreach (string original in DBInitter.Configs.Replacements.Keys)
                    {
                        query = query.Replace(original, DBInitter.Configs.Replacements[original]);
                    }

                    Regex dbNameRe = new Regex(@"^use\s*\[?([\w_]+)\]?", RegexOptions.IgnoreCase);
                    mc = dbNameRe.Match(query);
                    if (mc.Success)
                    {
                        string dbName = mc.Groups[1].ToString();

                        conn.ChangeDatabase(dbName);
                        if (DBInitter.Configs.CheckVersion)
                        {
                            // Check last executed script
                            string maxVersionQuery = "select max(Version) from DBScriptVersions";
                            SqlCommand maxVersionCmd = conn.CreateCommand();
                            maxVersionCmd.CommandText = maxVersionQuery;
                            int maxScriptVersionDb = -1;
                            try
                            {
                                maxScriptVersionDb = Int32.Parse(maxVersionCmd.ExecuteScalar().ToString());
                            }
                            catch (Exception) { }

                            if (maxScriptVersionDb > scriptVersion)
                            {
                                System.Console.WriteLine("Skipping " + scriptVersion + " because max is " + maxScriptVersionDb);
                                continue;
                            }
                        }

                        int idxOfGo = query.IndexOf("GO");
                        if (idxOfGo > 0)
                            query = query.Substring(idxOfGo + 2);
                    }

                    try
                    {
                        SqlCommand queryCommand = conn.CreateCommand();
                        queryCommand.CommandText = query;
                        queryCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqle)
                    {
                        System.Console.WriteLine("script " + scriptVersion + " failed" + sqle.Message);
                    }
                    catch (ApplicationException ex)
                    {
                        System.Console.WriteLine("ApplicationException Message: {0}", ex.Message);
                    }

                    this.toolStripProgressBar.Increment(1);
                }
                //if (DBInitter.Configs.Commit)
                //    if (trans.Connection != null)
                //        trans.Commit();
                //    else
                //    {
                //        if (trans.Connection != null)
                //            trans.Rollback();
                //    }
                conn.Close();
                //}
            }

            this.toolStripStatusLabelStatus.Text = "Ok";
        }

        private void btnScriptsFolder_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.dlgScriptsFolderBrowser.ShowDialog(this);
            if (dr.Equals(DialogResult.OK))
            {
                this.txtScriptsFolder.Text = this.dlgScriptsFolderBrowser.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }
    }
}