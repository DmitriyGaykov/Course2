namespace lab3.Search
{
    partial class Search
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
            this.lableSearchMader = new System.Windows.Forms.Label();
            this.SearchMaderTB = new System.Windows.Forms.TextBox();
            this.LableSearchYear = new System.Windows.Forms.Label();
            this.SearchYearTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FromNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ToNum = new System.Windows.Forms.NumericUpDown();
            this.DatasTo = new System.Windows.Forms.ListBox();
            this.Save = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FromNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNum)).BeginInit();
            this.SuspendLayout();
            // 
            // lableSearchMader
            // 
            this.lableSearchMader.AutoSize = true;
            this.lableSearchMader.Location = new System.Drawing.Point(12, 9);
            this.lableSearchMader.Name = "lableSearchMader";
            this.lableSearchMader.Size = new System.Drawing.Size(194, 23);
            this.lableSearchMader.TabIndex = 0;
            this.lableSearchMader.Text = "Поиск по издательству:";
            // 
            // SearchMaderTB
            // 
            this.SearchMaderTB.Location = new System.Drawing.Point(212, 9);
            this.SearchMaderTB.Name = "SearchMaderTB";
            this.SearchMaderTB.Size = new System.Drawing.Size(162, 30);
            this.SearchMaderTB.TabIndex = 1;
            this.SearchMaderTB.TextChanged += new System.EventHandler(this.ChangedText);
            // 
            // LableSearchYear
            // 
            this.LableSearchYear.AutoSize = true;
            this.LableSearchYear.Location = new System.Drawing.Point(401, 9);
            this.LableSearchYear.Name = "LableSearchYear";
            this.LableSearchYear.Size = new System.Drawing.Size(126, 23);
            this.LableSearchYear.TabIndex = 2;
            this.LableSearchYear.Text = "Поиск по году:";
            // 
            // SearchYearTB
            // 
            this.SearchYearTB.Location = new System.Drawing.Point(533, 9);
            this.SearchYearTB.Name = "SearchYearTB";
            this.SearchYearTB.Size = new System.Drawing.Size(162, 30);
            this.SearchYearTB.TabIndex = 3;
            this.SearchYearTB.TextChanged += new System.EventHandler(this.ChangedText);
            this.SearchYearTB.TextChanged += new EventHandler(this.CheckOfNumbers);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "От:";
            // 
            // FromNum
            // 
            this.FromNum.Location = new System.Drawing.Point(52, 61);
            this.FromNum.Name = "FromNum";
            this.FromNum.Size = new System.Drawing.Size(76, 30);
            this.FromNum.TabIndex = 5;
            this.FromNum.ValueChanged += new System.EventHandler(this.ChangedText);
            this.FromNum.AutoSizeChanged += new System.EventHandler(this.ChangedText);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "До:";
            // 
            // ToNum
            // 
            this.ToNum.Location = new System.Drawing.Point(196, 61);
            this.ToNum.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.ToNum.Name = "ToNum";
            this.ToNum.Size = new System.Drawing.Size(76, 30);
            this.ToNum.TabIndex = 7;
            this.ToNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ToNum.ValueChanged += new System.EventHandler(this.ChangedText);
            this.ToNum.AutoSizeChanged += new System.EventHandler(this.ChangedText);
            // 
            // DatasTo
            // 
            this.DatasTo.FormattingEnabled = true;
            this.DatasTo.ItemHeight = 23;
            this.DatasTo.Location = new System.Drawing.Point(12, 147);
            this.DatasTo.Name = "DatasTo";
            this.DatasTo.Size = new System.Drawing.Size(781, 303);
            this.DatasTo.TabIndex = 8;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Save.Location = new System.Drawing.Point(614, 98);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(179, 43);
            this.Save.TabIndex = 9;
            this.Save.Text = "Сохранить данные";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.SaveInfo);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(701, 10);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(30, 29);
            this.Back.TabIndex = 10;
            this.Back.Text = "<";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.ClickOnBack);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(737, 10);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(30, 29);
            this.Next.TabIndex = 11;
            this.Next.Text = ">";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.ClickOnNext);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DatasTo);
            this.Controls.Add(this.ToNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FromNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SearchYearTB);
            this.Controls.Add(this.LableSearchYear);
            this.Controls.Add(this.SearchMaderTB);
            this.Controls.Add(this.lableSearchMader);
            this.Name = "Search";
            this.Text = "Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FromNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lableSearchMader;
        private TextBox SearchMaderTB;
        private Label LableSearchYear;
        private TextBox SearchYearTB;
        private Label label3;
        private NumericUpDown FromNum;
        private Label label4;
        private NumericUpDown ToNum;
        private ListBox DatasTo;
        private Button Save;
        private Button Back;
        private Button Next;
    }
}