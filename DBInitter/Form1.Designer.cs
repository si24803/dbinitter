using System.Linq;
using System.Windows.Forms;

namespace DBInitter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlgScriptsFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLabelCurrentFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtDBHost = new System.Windows.Forms.TextBox();
            this.lblDBHost = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblScriptsFolder = new System.Windows.Forms.Label();
            this.txtScriptsFolder = new System.Windows.Forms.TextBox();
            this.btnScriptsFolder = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgScriptsFolderBrowser
            // 
            this.dlgScriptsFolderBrowser.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabelStatus,
                this.toolStripProgressBar,
                this.toolStripLabelCurrentFile
            });
            this.statusStrip1.Location = new System.Drawing.Point(0, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelStatus.Text = "Idle";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripLabelCurrentFile
            // 
            this.toolStripLabelCurrentFile.Name = "toolStripLabelCurrentFile";
            this.toolStripLabelCurrentFile.Size = new System.Drawing.Size(34, 16);
            this.toolStripLabelCurrentFile.Text = "none";
            //this.toolStripLabelCurrentFile.Visible = false;
            // 
            // lblDBHost
            // 
            this.lblDBHost.AutoSize = true;
            this.lblDBHost.Location = new System.Drawing.Point(13, 40);
            this.lblDBHost.Name = "lblDBHost";
            this.lblDBHost.Size = new System.Drawing.Size(47, 13);
            this.lblDBHost.Text = "DB Host";
            // 
            // txtDBHost
            // 
            this.txtDBHost.Location = new System.Drawing.Point(12, 56);
            this.txtDBHost.Name = "txtDBHost";
            this.txtDBHost.Size = new System.Drawing.Size(311, 20);
            this.txtDBHost.TabIndex = 2;
            AutoCompleteStringCollection knownHosts = new AutoCompleteStringCollection();
            knownHosts.AddRange(DBInitter.Configs.KnownHosts.ToArray());
            this.txtDBHost.AutoCompleteCustomSource = knownHosts;
            this.txtDBHost.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtDBHost.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // 
            // lblScriptsFolder
            // 
            this.lblScriptsFolder.AutoSize = true;
            this.lblScriptsFolder.Location = new System.Drawing.Point(13, 88);
            this.lblScriptsFolder.Name = "lblScriptsFolder";
            this.lblScriptsFolder.Size = new System.Drawing.Size(68, 13);
            this.lblScriptsFolder.Text = "Scripts folder";
            // 
            // txtScriptsFolder
            // 
            this.txtScriptsFolder.Location = new System.Drawing.Point(12, 104);
            this.txtScriptsFolder.Name = "txtScriptsFolder";
            this.txtScriptsFolder.Size = new System.Drawing.Size(311, 20);
            this.txtScriptsFolder.TabIndex = 3;
            AutoCompleteStringCollection knownPaths = new AutoCompleteStringCollection();
            knownPaths.AddRange(DBInitter.Configs.KnownPaths.ToArray());
            this.txtScriptsFolder.AutoCompleteCustomSource = knownPaths;
            this.txtScriptsFolder.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtScriptsFolder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // 
            // btnScriptsFolder
            // 
            this.btnScriptsFolder.Location = new System.Drawing.Point(329, 104);
            this.btnScriptsFolder.Name = "btnScriptsFolder";
            this.btnScriptsFolder.Size = new System.Drawing.Size(24, 20);
            this.btnScriptsFolder.TabIndex = 4;
            this.btnScriptsFolder.Text = "...";
            this.btnScriptsFolder.UseVisualStyleBackColor = true;
            this.btnScriptsFolder.Click += new System.EventHandler(this.btnScriptsFolder_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(295, 166);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(137, 56);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 304);
            this.Controls.Add(this.btnScriptsFolder);
            this.Controls.Add(this.lblScriptsFolder);
            this.Controls.Add(this.txtScriptsFolder);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblDBHost);
            this.Controls.Add(this.txtDBHost);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DlgScriptsFolderBrowser_Disposed(object sender, System.EventArgs e)
        {
            this.txtScriptsFolder.Text = this.dlgScriptsFolderBrowser.SelectedPath;
        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog dlgScriptsFolderBrowser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelCurrentFile;
        private System.Windows.Forms.TextBox txtDBHost;
        private System.Windows.Forms.Label lblDBHost;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblScriptsFolder;
        private System.Windows.Forms.TextBox txtScriptsFolder;
        private System.Windows.Forms.Button btnScriptsFolder;
    }
}

