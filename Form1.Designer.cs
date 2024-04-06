namespace button_practice
{
    partial class mainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            submit_btn = new Button();
            reset_btn = new Button();
            answerBox = new TextBox();
            totalLabel = new Label();
            correctLabel = new Label();
            correctPercentageLabel = new Label();
            yesOrNo = new Label();
            questionBox = new Label();
            totalData = new Label();
            correctData = new Label();
            correctPercentData = new Label();
            startLabel = new Label();
            loadFile = new Button();
            loadedFileLabel = new Label();
            skip_btn = new Button();
            SuspendLayout();
            // 
            // submit_btn
            // 
            submit_btn.Location = new Point(294, 229);
            submit_btn.Name = "submit_btn";
            submit_btn.Size = new Size(112, 34);
            submit_btn.TabIndex = 0;
            submit_btn.Text = "回答";
            submit_btn.UseVisualStyleBackColor = true;
            submit_btn.Click += submit_btn_Click;
            // 
            // reset_btn
            // 
            reset_btn.Location = new Point(479, 229);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(112, 34);
            reset_btn.TabIndex = 1;
            reset_btn.Text = "スタート";
            reset_btn.UseVisualStyleBackColor = true;
            reset_btn.Click += reset_btn_Click;
            // 
            // answerBox
            // 
            answerBox.Location = new Point(246, 170);
            answerBox.Name = "answerBox";
            answerBox.Size = new Size(390, 31);
            answerBox.TabIndex = 2;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(57, 92);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(88, 25);
            totalLabel.TabIndex = 3;
            totalLabel.Text = "表示回数";
            totalLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // correctLabel
            // 
            correctLabel.AutoSize = true;
            correctLabel.Location = new Point(57, 170);
            correctLabel.Name = "correctLabel";
            correctLabel.Size = new Size(88, 25);
            correctLabel.TabIndex = 4;
            correctLabel.Text = "正解回数";
            correctLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // correctPercentageLabel
            // 
            correctPercentageLabel.AutoSize = true;
            correctPercentageLabel.Location = new Point(57, 251);
            correctPercentageLabel.Name = "correctPercentageLabel";
            correctPercentageLabel.Size = new Size(88, 25);
            correctPercentageLabel.TabIndex = 5;
            correctPercentageLabel.Text = "正解確率";
            correctPercentageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yesOrNo
            // 
            yesOrNo.AutoSize = true;
            yesOrNo.Location = new Point(642, 173);
            yesOrNo.Name = "yesOrNo";
            yesOrNo.Size = new Size(0, 25);
            yesOrNo.TabIndex = 6;
            // 
            // questionBox
            // 
            questionBox.AutoSize = true;
            questionBox.Location = new Point(246, 125);
            questionBox.Name = "questionBox";
            questionBox.Size = new Size(0, 25);
            questionBox.TabIndex = 7;
            // 
            // totalData
            // 
            totalData.AutoSize = true;
            totalData.Location = new Point(75, 118);
            totalData.Name = "totalData";
            totalData.Size = new Size(0, 25);
            totalData.TabIndex = 8;
            // 
            // correctData
            // 
            correctData.AutoSize = true;
            correctData.Location = new Point(75, 196);
            correctData.Name = "correctData";
            correctData.Size = new Size(0, 25);
            correctData.TabIndex = 9;
            // 
            // correctPercentData
            // 
            correctPercentData.AutoSize = true;
            correctPercentData.Location = new Point(75, 277);
            correctPercentData.Name = "correctPercentData";
            correctPercentData.Size = new Size(0, 25);
            correctPercentData.TabIndex = 10;
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.Location = new Point(339, 34);
            startLabel.Name = "startLabel";
            startLabel.Size = new Size(192, 25);
            startLabel.TabIndex = 11;
            startLabel.Text = "リセットをクリックして開始";
            // 
            // loadFile
            // 
            loadFile.Location = new Point(675, 12);
            loadFile.Name = "loadFile";
            loadFile.Size = new Size(112, 34);
            loadFile.TabIndex = 12;
            loadFile.Text = "ファイル選択";
            loadFile.UseVisualStyleBackColor = true;
            loadFile.Click += loadFile_Click;
            // 
            // loadedFileLabel
            // 
            loadedFileLabel.AutoSize = true;
            loadedFileLabel.Location = new Point(675, 49);
            loadedFileLabel.Name = "loadedFileLabel";
            loadedFileLabel.Size = new Size(0, 25);
            loadedFileLabel.TabIndex = 13;
            // 
            // skip_btn
            // 
            skip_btn.Location = new Point(412, 229);
            skip_btn.Name = "skip_btn";
            skip_btn.Size = new Size(38, 34);
            skip_btn.TabIndex = 14;
            skip_btn.Text = "＞";
            skip_btn.UseVisualStyleBackColor = true;
            skip_btn.Click += skip_btn_Click;
            // 
            // mainWindow
            // 
            AcceptButton = submit_btn;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 389);
            Controls.Add(skip_btn);
            Controls.Add(loadedFileLabel);
            Controls.Add(loadFile);
            Controls.Add(startLabel);
            Controls.Add(correctPercentData);
            Controls.Add(correctData);
            Controls.Add(totalData);
            Controls.Add(questionBox);
            Controls.Add(yesOrNo);
            Controls.Add(correctPercentageLabel);
            Controls.Add(correctLabel);
            Controls.Add(totalLabel);
            Controls.Add(answerBox);
            Controls.Add(reset_btn);
            Controls.Add(submit_btn);
            Name = "mainWindow";
            Text = "単語くん - Reconstruction";
            FormClosing += mainWindow_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submit_btn;
        private Button reset_btn;
        private TextBox answerBox;
        private Label totalLabel;
        private Label correctLabel;
        private Label correctPercentageLabel;
        private Label yesOrNo;
        private Label questionBox;
        private Label totalData;
        private Label correctData;
        private Label correctPercentData;
        private Label startLabel;
        private Button loadFile;
        private Label loadedFileLabel;
        private Button skip_btn;
    }
}
