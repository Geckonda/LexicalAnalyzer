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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            richTextBoxInput = new RichTextBox();
            label4 = new Label();
            dataGridViewRecognizedTokens = new DataGridView();
            Number = new DataGridViewTextBoxColumn();
            Token = new DataGridViewTextBoxColumn();
            TokenType = new DataGridViewTextBoxColumn();
            LineIndex = new DataGridViewTextBoxColumn();
            SymbolIndex = new DataGridViewTextBoxColumn();
            label5 = new Label();
            richTextBoxMessages = new RichTextBox();
            label6 = new Label();
            buttonAnalyze = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecognizedTokens).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(821, 29);
            label1.TabIndex = 0;
            label1.Text = "Слова первого типа: числа (целые и вещественные), например  43,  5.2,  1,  23.1,  45.234";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(1099, 29);
            label2.TabIndex = 1;
            label2.Text = "Слова второго типа: идентификаторы (состоят из букв, цифр и символов подчеркивания), например  x,  MyFunc_1,  z0,";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(422, 29);
            label3.TabIndex = 2;
            label3.Text = "Комментарий: многострочный  %~  ........  ~%";
            // 
            // richTextBoxInput
            // 
            richTextBoxInput.Location = new Point(12, 232);
            richTextBoxInput.Name = "richTextBoxInput";
            richTextBoxInput.Size = new Size(500, 300);
            richTextBoxInput.TabIndex = 0;
            richTextBoxInput.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(149, 29);
            label4.TabIndex = 4;
            label4.Text = "Входной текст:";
            // 
            // dataGridViewRecognizedTokens
            // 
            dataGridViewRecognizedTokens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRecognizedTokens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecognizedTokens.Columns.AddRange(new DataGridViewColumn[] { Number, Token, TokenType, LineIndex, SymbolIndex });
            dataGridViewRecognizedTokens.Location = new Point(566, 232);
            dataGridViewRecognizedTokens.Name = "dataGridViewRecognizedTokens";
            dataGridViewRecognizedTokens.RowHeadersWidth = 62;
            dataGridViewRecognizedTokens.Size = new Size(600, 444);
            dataGridViewRecognizedTokens.TabIndex = 5;
            // 
            // Number
            // 
            Number.HeaderText = "№";
            Number.MinimumWidth = 8;
            Number.Name = "Number";
            Number.ReadOnly = true;
            // 
            // Token
            // 
            Token.HeaderText = "Token";
            Token.MinimumWidth = 8;
            Token.Name = "Token";
            // 
            // TokenType
            // 
            TokenType.HeaderText = "Тип токена";
            TokenType.MinimumWidth = 8;
            TokenType.Name = "TokenType";
            // 
            // LineIndex
            // 
            LineIndex.HeaderText = "Индекс строки";
            LineIndex.MinimumWidth = 8;
            LineIndex.Name = "LineIndex";
            // 
            // SymbolIndex
            // 
            SymbolIndex.HeaderText = "Индекс символа";
            SymbolIndex.MinimumWidth = 8;
            SymbolIndex.Name = "SymbolIndex";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(566, 200);
            label5.Name = "label5";
            label5.Size = new Size(224, 29);
            label5.TabIndex = 6;
            label5.Text = "Распознанные токены:";
            // 
            // richTextBoxMessages
            // 
            richTextBoxMessages.Enabled = false;
            richTextBoxMessages.Location = new Point(12, 607);
            richTextBoxMessages.Name = "richTextBoxMessages";
            richTextBoxMessages.Size = new Size(500, 125);
            richTextBoxMessages.TabIndex = 7;
            richTextBoxMessages.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 575);
            label6.Name = "label6";
            label6.Size = new Size(120, 29);
            label6.TabIndex = 8;
            label6.Text = "Сообщения";
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Location = new Point(816, 682);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(350, 50);
            buttonAnalyze.TabIndex = 1;
            buttonAnalyze.Text = "Анализировать текст";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1178, 744);
            Controls.Add(buttonAnalyze);
            Controls.Add(label6);
            Controls.Add(richTextBoxMessages);
            Controls.Add(label5);
            Controls.Add(dataGridViewRecognizedTokens);
            Controls.Add(label4);
            Controls.Add(richTextBoxInput);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecognizedTokens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBoxInput;
        private Label label4;
        private DataGridView dataGridViewRecognizedTokens;
        private Label label5;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Token;
        private DataGridViewTextBoxColumn TokenType;
        private DataGridViewTextBoxColumn LineIndex;
        private DataGridViewTextBoxColumn SymbolIndex;
        private RichTextBox richTextBoxMessages;
        private Label label6;
        private Button buttonAnalyze;
    }
}