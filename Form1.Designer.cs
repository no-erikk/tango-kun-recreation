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
            submit = new Button();
            cancel = new Button();
            answerBox = new TextBox();
            totalLabel = new Label();
            correctLabel = new Label();
            correctPercentageLabel = new Label();
            yesOrNo = new Label();
            questionBox = new Label();
            totalData = new Label();
            correctData = new Label();
            correctPercentData = new Label();
            SuspendLayout();
            // 
            // submit
            // 
            submit.Location = new Point(312, 229);
            submit.Name = "submit";
            submit.Size = new Size(112, 34);
            submit.TabIndex = 0;
            submit.Text = "回答";
            submit.UseVisualStyleBackColor = true;
            submit.Click += button1_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(447, 229);
            cancel.Name = "cancel";
            cancel.Size = new Size(112, 34);
            cancel.TabIndex = 1;
            cancel.Text = "リセット";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += button2_Click;
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
            questionBox.Size = new Size(59, 25);
            questionBox.TabIndex = 7;
            questionBox.Text = "label1";
            // 
            // totalData
            // 
            totalData.AutoSize = true;
            totalData.Location = new Point(70, 117);
            totalData.Name = "totalData";
            totalData.Size = new Size(0, 25);
            totalData.TabIndex = 8;
            // 
            // correctData
            // 
            correctData.AutoSize = true;
            correctData.Location = new Point(70, 195);
            correctData.Name = "correctData";
            correctData.Size = new Size(0, 25);
            correctData.TabIndex = 9;
            // 
            // correctPercentData
            // 
            correctPercentData.AutoSize = true;
            correctPercentData.Location = new Point(70, 276);
            correctPercentData.Name = "correctPercentData";
            correctPercentData.Size = new Size(0, 25);
            correctPercentData.TabIndex = 10;
            // 
            // mainWindow
            // 
            AcceptButton = submit;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 389);
            Controls.Add(correctPercentData);
            Controls.Add(correctData);
            Controls.Add(totalData);
            Controls.Add(questionBox);
            Controls.Add(yesOrNo);
            Controls.Add(correctPercentageLabel);
            Controls.Add(correctLabel);
            Controls.Add(totalLabel);
            Controls.Add(answerBox);
            Controls.Add(cancel);
            Controls.Add(submit);
            Name = "mainWindow";
            Text = "単語くん";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submit;
        private Button cancel;
        private TextBox answerBox;
        private Label totalLabel;
        private Label correctLabel;
        private Label correctPercentageLabel;
        private Label yesOrNo;
        private Label questionBox;
        private Label totalData;
        private Label correctData;
        private Label correctPercentData;
    }
}
