using MySql.Data.MySqlClient;
using System.Data;

namespace button_practice
{
    public partial class mainWindow : Form
    {
        private string server;
        private string port;
        private string database;
        private string user;
        private string password;
        private string table;
        private string jpCol;
        private string enCol;

        // initialize all SQL values from ini file
        // 
        public void setSqlVariables()
        {
            IniController iniController = new IniController("credentials.ini");
            // connection information //
            server = iniController.GetValue("Server");
            port = iniController.GetValue("Port");
            database = iniController.GetValue("Database");
            user = iniController.GetValue("User");
            password = iniController.GetValue("Password");

            // table and column information // 
            table = iniController.GetValue("Table");
            jpCol = iniController.GetValue("Japanese");
            enCol = iniController.GetValue("English");
        }

        // initialize MySQL connection
        // MySQL接続の初期化
        private MySqlConnection _connection;
        private void initializeDatabase()
        {
            // get sql information // SQL情報を取得する
            setSqlVariables();

            string connectionString = $"server={server}; port={port}; database={database}; user={user}; password={password}; charset=utf8";
            _connection = new MySqlConnection(connectionString);
        }

        // select CSV file // CSVを選ぶ
        private bool isFileLoaded;
        private void selectFile()
        {
            // prepare file retrieval constraints
            // ファイル検索制約を準備する
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // show name of loaded file
                    // 読み込んでるファイル名を表示する
                    string fileName = Path.GetFileName(ofd.FileName);
                    loadedFileLabel.Text = fileName;

                    // read loaded file
                    // 読み込んでるファイルを読む
                    string[] lines = File.ReadAllLines(ofd.FileName);

                    _connection.Open();

                    // batch insert all questions and answers from CSV into database
                    // すべての質問と回答をCSVからデータベースに一括挿入する
                    using (MySqlTransaction transaction = _connection.BeginTransaction())
                    {
                        try
                        {
                            List<MySqlCommand> commands = new List<MySqlCommand>();
                            foreach (string line in lines)
                            {
                                // divide values via delimiter
                                // 区切り文字で値を分割する
                                string[] values = line.Split(',');
                                // prepare batch of questions and answers to be inserted into database
                                // データベースに挿入する質問と回答のバッチを準備する
                                string query = $"INSERT INTO {table} ({jpCol}, {enCol}) VALUES (@japanese, @english)";
                                MySqlCommand command = new MySqlCommand(query, _connection, transaction);
                                command.Parameters.AddWithValue("@japanese", values[0]);
                                command.Parameters.AddWithValue("@english", values[1]);

                                commands.Add(command);
                            }

                            // execute all commands in the batch
                            // バッチ内の全コマンドを実行する
                            foreach (MySqlCommand command in commands)
                            {
                                command.ExecuteNonQuery();
                            }

                            // commit to database
                            // データベースにコミットする
                            transaction.Commit();

                            // change file state // ファイルの状態を変更する
                            isFileLoaded = true;

                            MessageBox.Show("ファイルは正常にロードされた。");
                        }
                        catch (Exception ex)
                        {
                            // rollback in case of failure
                            // 失敗時のロールバック
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        // delete values from database
        // データベースから値を削除する
        private void deleteValuesFromDatabase()
        {
            try
            {
                _connection.Open();

                using (MySqlTransaction transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        // delete values　// 値の削除
                        string deleteQuery = "DELETE FROM user_terms";
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, _connection, transaction);
                        deleteCommand.ExecuteNonQuery();

                        // reset index　// インデックスの再設定
                        string resetQuery = "ALTER TABLE user_terms AUTO_INCREMENT = 1";
                        MySqlCommand resetCommand = new MySqlCommand(resetQuery, _connection, transaction);
                        resetCommand.ExecuteNonQuery();

                        // commit to database // データベースにコミットする
                        transaction.Commit();

                        // change file state // ファイルの状態を変更する
                        isFileLoaded = false;

                    }
                    catch (Exception ex)
                    {
                        // rollback in case of failure
                        // 失敗時のロールバック
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        // fill datatable with values from database
        // データベースからの値でデータテーブルを満たす
        private DataTable dataTable;
        private void initializeDataTable()
        {
            dataTable = new DataTable();

            try
            {
                _connection.Open();

                // select all values from datatable
                // データテーブルからすべての値を選ぶ
                string query = "SELECT * FROM user_terms";
                MySqlCommand command = new MySqlCommand(query, _connection);

                // fill datatable with values from database
                // データベースからの値でデータテーブルを満たす
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // connection is closed in selectFile()
            // selectFile()で接続を閉じる
        }

        // helper func - randomly select a row from the datatable
        // ヘルパー関数 - データテーブルからランダムに行を選ぶ
        private DataRow randomRow()
        {
            // generate a random index
            // ランダムインデックスを生成する
            Random random = new Random();
            int randomIndex = random.Next(0, dataTable.Rows.Count);

            // select the "Japanese" word matching the random index
            // ランダムインデックスに一致する"Japanese"を選ぶ
            return dataTable.Rows[randomIndex];
        }

        // helper func - get answer to current question and compare it to user input
        // ヘルパー関数 - 現在の質問に対する答えを取得し、ユーザー入力と比較する
        private string currentQuestion;
        private void checkAnswer(string userAns)
        {
            // select question from row of data
            // データの行から質問を選ぶ
            DataRow[] rows = dataTable.Select($"user_terms_jp = '{currentQuestion}'");
            DataRow row = rows[0];

            string answer = row[2].ToString().ToUpper();

            // check if user input matches the "English" answer
            // ユーザー入力が "English "答えにマッチするかチェックする
            if (answer == userAns)
            {
                // if correct // 正解の場合
                yesOrNo.Text = "〇";
                updateCorrectAnswers();

                // select new question // 新しい質問を選ぶ
                generateNewQuestion();
            }
            else
            {
                // if incorrect // 不正解の場合
                yesOrNo.Text = "×";
            }
        }

        // helper func - generates a new question and assigns it to currentQuestion
        // ヘルパー関数 - 新しい質問を生成し、currentQuestionに代入する
        private void generateNewQuestion()
        {
            DataRow getCurrentQuestion = randomRow();
            currentQuestion = getCurrentQuestion[1].ToString();
            questionBox.Text = currentQuestion;
        }

        // helper func - add 1 the total number of questions and refresh UI
        // ヘルパー関数 - 質問総数に1を加え、UIをリフレッシュする
        private int totalQuestions = 0;
        private void updateTotalQuestions()
        {
            totalQuestions++;
            totalData.Text = totalQuestions.ToString();
        }

        // helper func - add 1 to the number of correct answers and refresh UI
        // ヘルパー関数 - 正解数に1を加え、UIをリフレッシュする
        private int correctQuestions = 0;
        private void updateCorrectAnswers()
        {
            correctQuestions++;
            correctData.Text = correctQuestions.ToString();
        }

        // helper func - calculate percentCorrect and refresh UI
        // ヘルパー関数 - percentCorrectを計算し、UIをリフレッシュする
        private void updatePercentCorrectAnswers()
        {
            double percentCorrect = (double)correctQuestions / totalQuestions * 100;
            correctPercentData.Text = Math.Round(percentCorrect, 2) + "%";
        }

        public mainWindow()
        {
            InitializeComponent();
            initializeDatabase();
        }

        // load file if no other files are loaded
        // 他のファイルが読み込んでない場合、ファイルを読み込む
        private void loadFile_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                MessageBox.Show("別のファイルがすでに読み込まれています。リセットして再試行してください。");
            }
            else // default state // 標準状態
            {
                selectFile();
                initializeDataTable();
            }
        }

        // submit answer button //「回答」を押すと
        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                string userAnswer = answerBox.Text.ToUpper();

                // check if answer is not empty
                // 回答が空でないかチェックする
                if (userAnswer.Length > 0)
                {
                    // if not empty
                    // 回答がからじゃないなら
                    checkAnswer(userAnswer);

                    // run helper functions to update total questions and percentage of correct answers
                    // ヘルパー関数を実行して、問題の合計と正解率を更新する
                    updateTotalQuestions();
                    updatePercentCorrectAnswers();

                    // clear answer box
                    // アンサーボックスを消去する
                    answerBox.Text = string.Empty;
                }
                else
                {
                    // if answer is empty show message box
                    // 回答が空ならメッセージボックスを表示する
                    MessageBox.Show("答えを入力してください。");
                }
            }
        }

        // skip current question
        // 現在の質問を飛ばす
        private void skip_btn_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                updateTotalQuestions();
                updatePercentCorrectAnswers();
                generateNewQuestion();
                yesOrNo.Text = "";
            }
        }

        // start/reset button // 「スタート」・「リセット」を押すと
        private void reset_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // initialize new question if there is no current question
                // 現在の質問がない場合、新しい質問を初期化する
                if (questionBox.Text.Length > 0 && startLabel.Visible == false)
                {
                    startLabel.Show();
                    reset();

                    // change button text // ボタンテクストを変更する
                    reset_btn.Text = "スタート";
                }
                else // default state // 標準状態
                {
                    if (isFileLoaded)
                    {
                        startLabel.Hide();
                        generateNewQuestion();

                        // change button text // ボタンテクストを変更する
                        reset_btn.Text = "リセット";

                    }
                    else
                    {
                        MessageBox.Show("ファイルを選択して再試行してください。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void reset()
        {
            // ensure connection is closed // 接続を確実に閉じる
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            // clear question // 質問を消去する
            questionBox.Text = string.Empty;

            // clear answer box and answer indicator
            // アンサーボックスと〇×を消去する
            answerBox.Text = string.Empty;
            yesOrNo.Text = string.Empty;

            // clear total questions and reset counter
            // 表示回数を消去し、カウンターをリセットする
            totalQuestions = 0;
            totalData.Text = string.Empty;

            // clear total correct questions and reset counter
            // 正解回数を消去し、カウンターをリセットする
            correctQuestions = 0;
            correctData.Text = string.Empty;

            // clear percent of correct answers and reset counter
            // 正解率を消去し、カウンターをリセットする
            updatePercentCorrectAnswers();
            correctPercentData.Text = string.Empty;

            // clear loaded file and values from database
            // 読み込んだファイルと値をデータベースから消去する
            deleteValuesFromDatabase();
            loadedFileLabel.Text = string.Empty;

            // change file state // ファイルの状態を変更する
            isFileLoaded = false;
        }

        // clear database when application is closed
        // アプリケーション終了時にデータベースを消去する
        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Close();
            deleteValuesFromDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlCredentialsForm form = new SqlCredentialsForm())
            {
                form.ShowDialog();
            }
        }
    }
}
