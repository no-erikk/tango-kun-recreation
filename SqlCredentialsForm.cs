namespace button_practice
{
    public partial class SqlCredentialsForm : Form
    {
        public SqlCredentialsForm()
        {
            InitializeComponent();
        }

        private void sql_data_save_Click(object sender, EventArgs e)
        {
            // get input values
            // 入力値を取得する
            string server = host_data.Text;
            string port = port_data.Text;
            string database = database_data.Text;
            string table = table_data.Text;
            string jp_col = jp_col_data.Text;
            string en_col = en_col_data.Text;
            string user = user_data.Text;
            string password = password_data.Text;

            // save input values to .ini file
            // 入力値を.iniファイルで保存する
            SaveCredentialsToIni(server, port, database, table, jp_col, en_col, user, password);

            // close form //　フォームを閉じる
            this.Close();
        }

        private void SaveCredentialsToIni(string server, string port, string database, string table, string jp, string en, string user, string password)
        {
            try
            {
                // Construct the .ini file content // .iniファイル内容作成
                string iniContent = $"[SQLサーバー情報]\nServer={server}\nPort={port}\nDatabase={database}\nTable={table}\nJapanese={jp}\nEnglish={en}\nUser={user}\nPassword={password}";

                System.IO.File.WriteAllText("credentials.ini", iniContent);

                MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
