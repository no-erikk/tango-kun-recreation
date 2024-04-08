namespace button_practice
{
    partial class SqlCredentialsForm
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
            host_label = new Label();
            host_data = new TextBox();
            port_data = new TextBox();
            port_label = new Label();
            database_data = new TextBox();
            database_label = new Label();
            user_data = new TextBox();
            user_label = new Label();
            password_data = new TextBox();
            password_label = new Label();
            sql_data_save = new Button();
            table_data = new TextBox();
            table_label = new Label();
            jp_col_data = new TextBox();
            jp_col_label = new Label();
            en_col_data = new TextBox();
            en_col_label = new Label();
            SuspendLayout();
            // 
            // host_label
            // 
            host_label.AutoSize = true;
            host_label.Location = new Point(12, 24);
            host_label.Name = "host_label";
            host_label.Size = new Size(75, 25);
            host_label.TabIndex = 0;
            host_label.Text = "ホスト名";
            // 
            // host_data
            // 
            host_data.Location = new Point(12, 52);
            host_data.Name = "host_data";
            host_data.Size = new Size(236, 31);
            host_data.TabIndex = 0;
            // 
            // port_data
            // 
            port_data.Location = new Point(12, 119);
            port_data.Name = "port_data";
            port_data.Size = new Size(236, 31);
            port_data.TabIndex = 1;
            // 
            // port_label
            // 
            port_label.AutoSize = true;
            port_label.Location = new Point(12, 91);
            port_label.Name = "port_label";
            port_label.Size = new Size(95, 25);
            port_label.TabIndex = 2;
            port_label.Text = "ポート番号";
            // 
            // database_data
            // 
            database_data.Location = new Point(12, 185);
            database_data.Name = "database_data";
            database_data.Size = new Size(236, 31);
            database_data.TabIndex = 2;
            // 
            // database_label
            // 
            database_label.AutoSize = true;
            database_label.Location = new Point(12, 157);
            database_label.Name = "database_label";
            database_label.Size = new Size(123, 25);
            database_label.TabIndex = 4;
            database_label.Text = "データベース名";
            // 
            // user_data
            // 
            user_data.Location = new Point(290, 52);
            user_data.Name = "user_data";
            user_data.Size = new Size(236, 31);
            user_data.TabIndex = 6;
            // 
            // user_label
            // 
            user_label.AutoSize = true;
            user_label.Location = new Point(290, 24);
            user_label.Name = "user_label";
            user_label.Size = new Size(95, 25);
            user_label.TabIndex = 6;
            user_label.Text = "ユーザー名";
            // 
            // password_data
            // 
            password_data.Location = new Point(290, 118);
            password_data.Name = "password_data";
            password_data.Size = new Size(236, 31);
            password_data.TabIndex = 7;
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Location = new Point(290, 90);
            password_label.Name = "password_label";
            password_label.Size = new Size(86, 25);
            password_label.TabIndex = 8;
            password_label.Text = "パスワード";
            // 
            // sql_data_save
            // 
            sql_data_save.Location = new Point(414, 428);
            sql_data_save.Name = "sql_data_save";
            sql_data_save.Size = new Size(112, 34);
            sql_data_save.TabIndex = 8;
            sql_data_save.Text = "保存";
            sql_data_save.UseVisualStyleBackColor = true;
            sql_data_save.Click += Sql_data_save_Click;
            // 
            // table_data
            // 
            table_data.Location = new Point(12, 256);
            table_data.Name = "table_data";
            table_data.Size = new Size(236, 31);
            table_data.TabIndex = 3;
            // 
            // table_label
            // 
            table_label.AutoSize = true;
            table_label.Location = new Point(12, 228);
            table_label.Name = "table_label";
            table_label.Size = new Size(92, 25);
            table_label.TabIndex = 11;
            table_label.Text = "テーブル名";
            // 
            // jp_col_data
            // 
            jp_col_data.Location = new Point(12, 327);
            jp_col_data.Name = "jp_col_data";
            jp_col_data.Size = new Size(236, 31);
            jp_col_data.TabIndex = 4;
            // 
            // jp_col_label
            // 
            jp_col_label.AutoSize = true;
            jp_col_label.Location = new Point(12, 299);
            jp_col_label.Name = "jp_col_label";
            jp_col_label.Size = new Size(123, 25);
            jp_col_label.TabIndex = 13;
            jp_col_label.Text = "日本語の欄名";
            // 
            // en_col_data
            // 
            en_col_data.Location = new Point(12, 390);
            en_col_data.Name = "en_col_data";
            en_col_data.Size = new Size(236, 31);
            en_col_data.TabIndex = 5;
            // 
            // en_col_label
            // 
            en_col_label.AutoSize = true;
            en_col_label.Location = new Point(12, 362);
            en_col_label.Name = "en_col_label";
            en_col_label.Size = new Size(104, 25);
            en_col_label.TabIndex = 15;
            en_col_label.Text = "英語の欄名";
            // 
            // SqlCredentialsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 474);
            Controls.Add(en_col_data);
            Controls.Add(en_col_label);
            Controls.Add(jp_col_data);
            Controls.Add(jp_col_label);
            Controls.Add(table_data);
            Controls.Add(table_label);
            Controls.Add(sql_data_save);
            Controls.Add(password_data);
            Controls.Add(password_label);
            Controls.Add(user_data);
            Controls.Add(user_label);
            Controls.Add(database_data);
            Controls.Add(database_label);
            Controls.Add(port_data);
            Controls.Add(port_label);
            Controls.Add(host_data);
            Controls.Add(host_label);
            Name = "SqlCredentialsForm";
            Text = "SQLサーバー情報";
            Load += SqlCredentialsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label host_label;
        private TextBox host_data;
        private TextBox port_data;
        private Label port_label;
        private TextBox database_data;
        private Label database_label;
        private TextBox user_data;
        private Label user_label;
        private TextBox password_data;
        private Label password_label;
        private Button sql_data_save;
        private TextBox table_data;
        private Label table_label;
        private TextBox jp_col_data;
        private Label jp_col_label;
        private TextBox en_col_data;
        private Label en_col_label;
    }
}