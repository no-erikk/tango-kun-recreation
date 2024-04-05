using System.Data;

namespace button_practice
{
    public partial class mainWindow : Form
    {
        // create small datatable to facilitate low-level tests
        // 簡単テストを容易にするために、小さなデータテーブルを作成する

        private DataTable dataTable;
        private string currentQuestion;
        private void initializeTestData()
        {
            dataTable = new DataTable();

            dataTable.Columns.Add("Index", typeof(int));
            dataTable.Columns.Add("Japanese", typeof(string));
            dataTable.Columns.Add("English", typeof(string));

            dataTable.Rows.Add(1, "慣例", "custom");
            dataTable.Rows.Add(2, "寛容", "tolerance");
            dataTable.Rows.Add(3, "関与", "participation");
            dataTable.Rows.Add(4, "勧誘", "invitation");
            dataTable.Rows.Add(5, "観覧", "viewing");
        }

        // helper func - randomly select a row from the datatable
        // ヘルパー関数 - データテーブルからランダムに行を選択する
        private DataRow randomRow()
        {
            // generate a random index
            // ランダムインデックスを生成する
            Random random = new Random();
            int randomIndex = random.Next(0, dataTable.Rows.Count);

            // select the "Japanese" word matching the random index
            // ランダムインデックスに一致する"Japanese"を選択する
            return dataTable.Rows[randomIndex];
        }

        // helper func - get answer to current question and compare it to user input
        // ヘルパー関数 - 現在の質問に対する答えを取得し、ユーザー入力と比較する
        private void checkAnswer(string userAns)
        {
            DataRow[] rows = dataTable.Select($"Japanese = '{currentQuestion}'");
            DataRow row = rows[0];

            string answer = row[2].ToString().ToUpper();

            // check if user input matches the "English" answer
            // ユーザー入力が "English "答えにマッチするかチェックする
            if (answer == userAns)
            {
                // if correct
                // 正解の場合
                yesOrNo.Text = "〇";
                updateCorrectAnswers();
                // select new question
                // 新しい質問を選択する
                generateNewQuestion();
            }
            else
            {
                // if incorrect
                // 不正解の場合
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

        // initialize counters
        // カウンターの初期化
        private int totalQuestions = 0;
        private int correctQuestions = 0;

        // helper func - add 1 the total number of questions and refresh UI
        // ヘルパー関数 - 質問総数に1を加え、UIをリフレッシュする
        private void updateTotalQuestions()
        {
            totalQuestions++;
            totalData.Text = totalQuestions.ToString();
        }

        // helper func - add 1 to the number of correct answers and refresh UI
        // ヘルパー関数 - 正解数に1を加え、UIをリフレッシュする
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
            initializeTestData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // submit answer button
        //「回答」を押すと
        private void button1_Click(object sender, EventArgs e)
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
                //　ヘルパー関数を実行して、問題の合計と正解率を更新する
                updateTotalQuestions();
                updatePercentCorrectAnswers();

                // clear answer box
                // アンサーボックスを消去
                answerBox.Text = string.Empty;

            }
            else
            {
                // if answer is empty show message box
                // 回答が空ならメッセージボックスを表示
                MessageBox.Show("答えを入力してください。");
            }

        }
        // reset button
        //「リセット」を押すと
        private void button2_Click(object sender, EventArgs e)
        {
            // initialize new question if there is no current question
            // 現在の質問がない場合、新しい質問を初期化する
            if (questionBox.Text.Length > 0)
            {
                startLabel.Show();
                reset();
            }
            else
            {
                startLabel.Hide();
                generateNewQuestion();
            }

        }

        private void reset()
        {
            // clear question
            // 質問を消去
            questionBox.Text = string.Empty;

            // clear answer box and answer indicator
            // アンサーボックスと〇×を消去
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
        }

    }
}
