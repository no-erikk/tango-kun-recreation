namespace button_practice
{
    internal class IniController
    {
        private readonly Dictionary<string, string> settings;

        public IniController(string fileName)
        {
            settings = [];
            LoadSettings(fileName);
        }

        private void LoadSettings(string filePath)
        {
            try
            {
                // read all lines of .ini file
                // .iniファイルのすべての行を読む
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // split each line by '=' to get key-value pairs
                    // 各行を'='で分割し、キーと値のペアを取得する
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        // add key-value pair to settings dictionary
                        // 設定辞書にキーと値のペアを追加する
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
            if (settings.TryGetValue(key, out string? value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

    }
}
