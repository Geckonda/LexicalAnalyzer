namespace Lab1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            richTextBoxInput = new RichTextBox();
            label4 = new Label();
            richTextBoxMessages = new RichTextBox();
            label6 = new Label();
            buttonAnalyze = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(363, 20);
            label1.TabIndex = 0;
            label1.Text = "Слова первого типа: состоят из 0 или 1 — (011)*001(010)*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(488, 20);
            label2.TabIndex = 1;
            label2.Text = "Слова второго типа: идентификаторы (a|b|c|d)+. Не должно заканчиваться aa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(260, 20);
            label3.TabIndex = 2;
            label3.Text = "Комментарий: многострочный  {  ........  }";
            // 
            // richTextBoxInput
            // 
            richTextBoxInput.Location = new Point(12, 232);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(1154, 300);
            richTextBoxInput.TabIndex = 0;
            richTextBoxInput.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 4;
            label4.Text = "Входной текст:";
            // 
            // richTextBoxMessages
            // 
            richTextBoxMessages.Enabled = false;
            richTextBoxMessages.Location = new Point(12, 633);
            richTextBoxMessages.Name = "richTextBoxMessages";
            richTextBoxMessages.Size = new Size(1154, 99);
            richTextBoxMessages.TabIndex = 7;
            richTextBoxMessages.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 610);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 8;
            label6.Text = "Сообщения";
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Location = new Point(434, 545);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(350, 50);
            buttonAnalyze.TabIndex = 1;
            buttonAnalyze.Text = "Анализировать текст";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1039, 9);
            label5.Name = "label5";
            label5.Size = new Size(127, 100);
            label5.TabIndex = 9;
            label5.Text = "КС-грамматика:\r\nS → A | B\r\nA → AB + | B\r\nB → BC * | C\r\nC → C - | <1> | <2>";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1178, 744);
            Controls.Add(label5);
            Controls.Add(buttonAnalyze);
            Controls.Add(label6);
            Controls.Add(richTextBoxMessages);
            Controls.Add(label4);
            Controls.Add(richTextBoxInput);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Синтаксический анализатор";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBoxInput;
        private Label label4;
        private RichTextBox richTextBoxMessages;
        private Label label6;
        private Button buttonAnalyze;
        private Label label5;
    }
}