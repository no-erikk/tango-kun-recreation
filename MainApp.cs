using System.Data;

namespace button_practice
{
    public partial class MainWindow : Form
    {

        private bool isFileLoaded;
        private bool questionMode;
        private string currentQuestion;
        private int totalQuestions = 0;
        private int correctQuestions = 0;

        private DataTable dataTable;

        public MainWindow()
        {
            InitializeComponent();
        }

        // select .csv file // .csvを選ぶ
        private void SelectFile()
        {
            // prepare file retrieval constraints
            // ファイル検索制約を準備する
            OpenFileDialog openFileDialog = new();
            OpenFileDialog ofd = openFileDialog;
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;

            // load .csv data to datatable
            // 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string csvFilePath = ofd.FileName;

                dataTable = CsvProcessor.ReadCsv(csvFilePath);

                // change file state // ファイルの状態を変更する
                isFileLoaded = true;
                loadedFileLabel.Text = Path.GetFileName(csvFilePath);
            }
        }

        // helper func - randomly select a row from the datatable
        // ヘルパー関数 - データテーブルからランダムに行を選ぶ
        private DataRow RandomRow()
        {
            // generate a random index
            // ランダムインデックスを生成する
            Random random = new();
            int randomIndex = random.Next(0, dataTable.Rows.Count);

            // select the "Japanese" word matching the random index
            // ランダムインデックスに一致する"Japanese"を選ぶ
            return dataTable.Rows[randomIndex];
        }

        // helper func - get answer to current question and compare it to user input
        // ヘルパー関数 - 現在の質問に対する答えを取得し、ユーザー入力と比較する
        private void CheckAnswer(string userAns)
        {
            DataRow questionRow = null;

            // select question from row of data
            // データの行から質問を選ぶ
            foreach (DataRow row in dataTable.Rows)
            {
                if (row[0].ToString() == currentQuestion)
                {
                    questionRow = row;
                    break;
                }
            }

            string answer = questionRow[1].ToString().ToUpper();

            // check if user input matches the "English" answer
            // ユーザー入力が "English "答えにマッチするかチェックする
            if (answer == userAns)
            {
                // if correct // 正解の場合
                yesOrNo.Text = "〇";
                UpdateCorrectAnswers();

                // select new question // 新しい質問を選ぶ
                GenerateNewQuestion();
            }
            else
            {
                // if incorrect // 不正解の場合
                yesOrNo.Text = "×";
            }
        }

        // helper func - generates a new question and assigns it to currentQuestion
        // ヘルパー関数 - 新しい質問を生成し、currentQuestionに代入する
        private void GenerateNewQuestion()
        {
            DataRow getCurrentQuestion = RandomRow();
            currentQuestion = getCurrentQuestion[0].ToString();
            questionBox.Text = currentQuestion;
        }

        // helper func - add 1 the total number of questions and refresh UI
        // ヘルパー関数 - 質問総数に1を加え、UIをリフレッシュする
        private void UpdateTotalQuestions()
        {
            totalQuestions++;
            totalData.Text = totalQuestions.ToString();
        }

        // helper func - add 1 to the number of correct answers and refresh UI
        // ヘルパー関数 - 正解数に1を加え、UIをリフレッシュする
        private void UpdateCorrectAnswers()
        {
            correctQuestions++;
            correctData.Text = correctQuestions.ToString();
        }

        // helper func - calculate percentCorrect and refresh UI
        // ヘルパー関数 - percentCorrectを計算し、UIをリフレッシュする
        private void UpdatePercentCorrectAnswers()
        {
            double percentCorrect = (double)correctQuestions / totalQuestions * 100;
            correctPercentData.Text = Math.Round(percentCorrect, 2) + "%";
        }

        // load file if no other files are loaded
        // 他のファイルが読み込んでない場合、ファイルを読み込む
        private void LoadFile_Click(object sender, EventArgs e)
        {
            if (isFileLoaded)
            {
                MessageBox.Show("別のファイルがすでに読み込まれています。リセットして再試行してください。");
            }
            else // default state // 標準状態
            {
                SelectFile();
            }
        }

        // submit answer button //「回答」を押すと
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            if (questionMode)
            {
                string userAnswer = answerBox.Text.ToUpper();

                // check if answer is not empty
                // 回答が空でないかチェックする
                if (userAnswer.Length > 0)
                {
                    // if not empty
                    // 回答がからじゃないなら
                    CheckAnswer(userAnswer);

                    // run helper functions to update total questions and percentage of correct answers
                    // ヘルパー関数を実行して、問題の合計と正解率を更新する
                    UpdateTotalQuestions();
                    UpdatePercentCorrectAnswers();

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
        private void Skip_btn_Click(object sender, EventArgs e)
        {
            if (questionMode)
            {
                UpdateTotalQuestions();
                UpdatePercentCorrectAnswers();
                GenerateNewQuestion();
                yesOrNo.Text = "";
            }
        }

        // start/reset button // 「スタート」・「リセット」を押すと
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // initialize new question if there is no current question
                // 現在の質問がない場合、新しい質問を初期化する
                if (questionBox.Text.Length > 0 && startLabel.Visible == false)
                {
                    startLabel.Show();
                    Reset();

                    // change button text // ボタンテクストを変更する
                    reset_btn.Text = "スタート";
                    questionMode = false;
                }
                else // default state // 標準状態
                {
                    if (isFileLoaded)
                    {
                        startLabel.Hide();
                        GenerateNewQuestion();

                        // change button text // ボタンテクストを変更する
                        reset_btn.Text = "リセット";
                        questionMode = true;
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

        private void Reset()
        {
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
            UpdatePercentCorrectAnswers();
            correctPercentData.Text = string.Empty;

            // change file state // ファイルの状態を変更する
            isFileLoaded = false;
            loadedFileLabel.Text = string.Empty;
        }

    }
}
