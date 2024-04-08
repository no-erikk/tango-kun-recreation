using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            // 
            string server = host_data.Text;
            string port = port_data.Text;
            string database = database_data.Text;
            string table = table_data.Text;
            string jp_col = jp_col_data.Text;
            string en_col = en_col_data.Text;
            string user = user_data.Text;
            string password = password_data.Text;

            // save input values to ini file
            // 
            SaveCredentialsToIni(server, port, database, table, jp_col, en_col, user, password);

            // close form //
            this.Close();
        }

        private void SaveCredentialsToIni(string server, string port, string database, string table, string jp, string en, string user, string password)
        {
            try
            {
                // Construct the INI file content
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
