using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DBInitter.Substitutions;
using Newtonsoft.Json;

namespace DBInitter
{
    internal static class DBInitter
    {
        internal static Configuration Configs { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            IDictionary<string, string> repss = new Dictionary<string, string>();
            repss.Add("a", "aa");
            repss.Add("b", "bb");
            Configuration ssss = new Configuration() { Replacements = repss };
            string json = JsonConvert.SerializeObject(ssss);

            if (!Directory.Exists("Resources"))
            {
                Directory.CreateDirectory("Resources");
            }
            string fs = File.ReadAllText("Resources/conf.json", Encoding.UTF8);
            if (fs.Length > 0)
            {
                Configs = JsonConvert.DeserializeObject<Configuration>(fs);                
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string lastConfig = JsonConvert.SerializeObject(Configs);
            File.WriteAllText("Resources/conf.json", lastConfig, Encoding.UTF8);
        }
    }
}