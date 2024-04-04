namespace button_practice
{
    public partial class mainWindow : Form
    {
        // initialize counters
        // カウンターの初期化
        private int totalQuestions = 0;
        private int correctQuestions = 0;

        // helper func - add 1 to totalQuestions and refresh UI
        // ヘルパー関数 - totalQuestionsに1を追加し、UIをリフレッシュする
        private void updateTotalQues()
        {
            totalQuestions++;
            totalData.Text = totalQuestions.ToString();
        }

        // helper func - add 1 to correctQuestions and refresh UI
        // ヘルパー関数 - correctQuestionsに1を追加し、UIをリフレッシュする
        private void updateCorrectAns()
        {
            correctQuestions++;
            correctData.Text = correctQuestions.ToString(); 
        }

        // helper func - calculate percentCorrect and refresh UI
        // ヘルパー関数 - パーセントコレクトを計算し、UIをリフレッシュする。
        private void updatePercentCorrectAns()
        {
            double percentCorrect = (double)correctQuestions / totalQuestions * 100;
            correctPercentData.Text = percentCorrect + "%";
        }

        public mainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // submit answer button
        //「回答」を押すと
        private void button1_Click(object sender, EventArgs e)
        {
            // test strings - will replace with index numbers when database is iplemented
            // テスト文字列 - データベースの実装時にインデックス番号に置き換える
            string question = questionBox.Text.ToUpper();
            string answer = answerBox.Text.ToUpper();

            // check if answer is not empty
            // 回答が空でないかチェックする
            if (answer.Length > 0 )
            {
                if (question == answer)
                {
                    // if correct
                    // 正解の場合
                    yesOrNo.Text = "〇";
                    updateCorrectAns();
                }
                else
                {
                    // if incorrect
                    //　不正解の場合
                    yesOrNo.Text = "×";
                }

                // run helper functions to update total questions and percentage of correct answers
                //　ヘルパー関数を実行して、問題の合計と正解率を更新する
                updateTotalQues();
                updatePercentCorrectAns();

                // clear answer box
                // アンサーボックスを消去
                answerBox.Text = string.Empty;

            } else 
            {
                // if answer is empty show message box
                // 答えが空ならメッセージボックスを表示
                MessageBox.Show("答えを入力してください。");
            }

            

        }
        // reset button
        //「リセット」を押すと
        private void button2_Click(object sender, EventArgs e)
        {
            // clear answer box and answer indicator
            // アンサーボックスと〇×を消去
            answerBox.Text = string.Empty;
            yesOrNo.Text = string.Empty;
        }

    }
}
