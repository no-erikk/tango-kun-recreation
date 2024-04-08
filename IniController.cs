using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace button_practice
{
    internal class IniController
    {
        private Dictionary<string, string> settings;

        public IniController(string fileName)
        {
            settings = new Dictionary<string, string>();
            LoadSettings(fileName);
        }

        private void LoadSettings(string filePath)
        {
            try
            {
                // read all lines of ini file
                // 
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // split each line by '=' to get key-value pairs
                    // 
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        // add key-value pair to settings dictionary
                        //
                        settings.Add(parts[0], parts[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GetValue(string key) 
        {
            if (settings.ContainsKey(key))
            {
                return settings[key];
            }
            else
            {
                return null;
            }
        }

    }
}
