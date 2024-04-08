namespace button_practice
{
    public partial class SqlCredentialsForm : Form
    {
        private IniController _controller;

        public SqlCredentialsForm()
        {
            InitializeComponent();
        }

        private void SqlCredentialsForm_Load(object sender, EventArgs e)
        {
            // load values from .ini //
            _controller = new IniController("credentials.ini");
            host_data.Text = _controller.GetValue("Server");
            port_data.Text = _controller.GetValue("Port");
            database_data.Text = _controller.GetValue("Database");
            table_data.Text = _controller.GetValue("Table");
            jp_col_data.Text = _controller.GetValue("Japanese");
            en_col_data.Text = _controller.GetValue("English");
            user_data.Text = _controller.GetValue("User");
            password_data.Text = _controller.GetValue("Password");
        }

        private void Sql_data_save_Click(object sender, EventArgs e)
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

            // load values to main app
            // 
            MainWindow mainWindow = new();
            mainWindow.SetSqlVariables();

            // close form //　フォームを閉じる
            this.Close();
        }

        private static void SaveCredentialsToIni(string server, string port, string database, string table, string jp, string en, string user, string password)
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
