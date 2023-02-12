namespace Lab1
{
    partial class Form1
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
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            this.LableType = new System.Windows.Forms.Label();
            this.LabelSize = new System.Windows.Forms.Label();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.LableTitle = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MaderTextBox = new System.Windows.Forms.TextBox();
            this.LableMader = new System.Windows.Forms.Label();
            this.CountListsNumeric = new System.Windows.Forms.NumericUpDown();
            this.LableCountLists = new System.Windows.Forms.Label();
            this.MadeDateTime = new System.Windows.Forms.DateTimePicker();
            this.LableDateMaded = new System.Windows.Forms.Label();
            this.LabelAuthor = new System.Windows.Forms.Label();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.LabelLoudDate = new System.Windows.Forms.Label();
            this.LoudDateDateTime = new System.Windows.Forms.DateTimePicker();
            this.LableName = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.LableCountry = new System.Windows.Forms.Label();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.LableSex = new System.Windows.Forms.Label();
            this.RadioMale = new System.Windows.Forms.RadioButton();
            this.RadioWoman = new System.Windows.Forms.RadioButton();
            this.Sender = new System.Windows.Forms.Button();
            this.AgreeCheckbox = new System.Windows.Forms.CheckBox();
            this.DirectionListBox = new System.Windows.Forms.ListBox();
            this.LableDirection = new System.Windows.Forms.Label();
            this.ProgressBarOfReg = new System.Windows.Forms.ProgressBar();
            this.Getter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CountListsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TypeTextBox.ForeColor = System.Drawing.Color.Black;
            this.TypeTextBox.Location = new System.Drawing.Point(172, 94);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Size = new System.Drawing.Size(214, 30);
            this.TypeTextBox.TabIndex = 0;
            this.TypeTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            // 
            // LableType
            // 
            this.LableType.Location = new System.Drawing.Point(12, 97);
            this.LableType.Name = "LableType";
            this.LableType.Size = new System.Drawing.Size(154, 23);
            this.LableType.TabIndex = 1;
            this.LableType.Text = "Тип:";
            // 
            // LabelSize
            // 
            this.LabelSize.Location = new System.Drawing.Point(12, 138);
            this.LabelSize.Name = "LabelSize";
            this.LabelSize.Size = new System.Drawing.Size(154, 23);
            this.LabelSize.TabIndex = 2;
            this.LabelSize.Text = "Размер в мб:";
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SizeTextBox.ForeColor = System.Drawing.Color.Black;
            this.SizeTextBox.Location = new System.Drawing.Point(172, 135);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(214, 30);
            this.SizeTextBox.TabIndex = 3;
            this.SizeTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            this.SizeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckOnNumber);
            // 
            // LableTitle
            // 
            this.LableTitle.Location = new System.Drawing.Point(12, 180);
            this.LableTitle.Name = "LableTitle";
            this.LableTitle.Size = new System.Drawing.Size(154, 23);
            this.LableTitle.TabIndex = 4;
            this.LableTitle.Text = "Название:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TitleTextBox.ForeColor = System.Drawing.Color.Black;
            this.TitleTextBox.Location = new System.Drawing.Point(172, 177);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(214, 30);
            this.TitleTextBox.TabIndex = 5;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            // 
            // MaderTextBox
            // 
            this.MaderTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MaderTextBox.ForeColor = System.Drawing.Color.Black;
            this.MaderTextBox.Location = new System.Drawing.Point(172, 222);
            this.MaderTextBox.Name = "MaderTextBox";
            this.MaderTextBox.Size = new System.Drawing.Size(214, 30);
            this.MaderTextBox.TabIndex = 6;
            this.MaderTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            // 
            // LableMader
            // 
            this.LableMader.Location = new System.Drawing.Point(12, 225);
            this.LableMader.Name = "LableMader";
            this.LableMader.Size = new System.Drawing.Size(154, 23);
            this.LableMader.TabIndex = 7;
            this.LableMader.Text = "Издательство:";
            // 
            // CountListsNumeric
            // 
            this.CountListsNumeric.Location = new System.Drawing.Point(172, 267);
            this.CountListsNumeric.Name = "CountListsNumeric";
            this.CountListsNumeric.Size = new System.Drawing.Size(214, 30);
            this.CountListsNumeric.TabIndex = 8;
            this.CountListsNumeric.ValueChanged += new System.EventHandler(this.ClickOnNumericUpDown);
            // 
            // LableCountLists
            // 
            this.LableCountLists.Location = new System.Drawing.Point(12, 269);
            this.LableCountLists.Name = "LableCountLists";
            this.LableCountLists.Size = new System.Drawing.Size(154, 23);
            this.LableCountLists.TabIndex = 9;
            this.LableCountLists.Text = "Кол-во страниц:";
            // 
            // MadeDateTime
            // 
            this.MadeDateTime.Location = new System.Drawing.Point(172, 313);
            this.MadeDateTime.Name = "MadeDateTime";
            this.MadeDateTime.Size = new System.Drawing.Size(214, 30);
            this.MadeDateTime.TabIndex = 10;
            // 
            // LableDateMaded
            // 
            this.LableDateMaded.Location = new System.Drawing.Point(12, 319);
            this.LableDateMaded.Name = "LableDateMaded";
            this.LableDateMaded.Size = new System.Drawing.Size(154, 23);
            this.LableDateMaded.TabIndex = 11;
            this.LableDateMaded.Text = "Дата основания:";
            // 
            // LabelAuthor
            // 
            this.LabelAuthor.Location = new System.Drawing.Point(12, 360);
            this.LabelAuthor.Name = "LabelAuthor";
            this.LabelAuthor.Size = new System.Drawing.Size(154, 23);
            this.LabelAuthor.TabIndex = 13;
            this.LabelAuthor.Text = "Список авторов:";
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AuthorTextBox.ForeColor = System.Drawing.Color.Black;
            this.AuthorTextBox.Location = new System.Drawing.Point(172, 357);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(214, 30);
            this.AuthorTextBox.TabIndex = 14;
            this.AuthorTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            // 
            // LabelLoudDate
            // 
            this.LabelLoudDate.Location = new System.Drawing.Point(12, 405);
            this.LabelLoudDate.Name = "LabelLoudDate";
            this.LabelLoudDate.Size = new System.Drawing.Size(154, 23);
            this.LabelLoudDate.TabIndex = 15;
            this.LabelLoudDate.Text = "Дата загрузки:";
            // 
            // LoudDateDateTime
            // 
            this.LoudDateDateTime.Location = new System.Drawing.Point(172, 399);
            this.LoudDateDateTime.Name = "LoudDateDateTime";
            this.LoudDateDateTime.Size = new System.Drawing.Size(214, 30);
            this.LoudDateDateTime.TabIndex = 16;
            // 
            // LableName
            // 
            this.LableName.Location = new System.Drawing.Point(566, 97);
            this.LableName.Name = "LableName";
            this.LableName.Size = new System.Drawing.Size(154, 23);
            this.LableName.TabIndex = 17;
            this.LableName.Text = "Имя загрузчика:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.Location = new System.Drawing.Point(726, 94);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(214, 30);
            this.NameTextBox.TabIndex = 18;
            this.NameTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            // 
            // LableCountry
            // 
            this.LableCountry.Location = new System.Drawing.Point(566, 138);
            this.LableCountry.Name = "LableCountry";
            this.LableCountry.Size = new System.Drawing.Size(154, 23);
            this.LableCountry.TabIndex = 19;
            this.LableCountry.Text = "Страна:";
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CountryTextBox.ForeColor = System.Drawing.Color.Black;
            this.CountryTextBox.Location = new System.Drawing.Point(726, 138);
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(214, 30);
            this.CountryTextBox.TabIndex = 20;
            this.CountryTextBox.TextChanged += new System.EventHandler(this.ClickTextBox);
            // 
            // LableSex
            // 
            this.LableSex.Location = new System.Drawing.Point(566, 184);
            this.LableSex.Name = "LableSex";
            this.LableSex.Size = new System.Drawing.Size(154, 23);
            this.LableSex.TabIndex = 21;
            this.LableSex.Text = "Пол:";
            // 
            // RadioMale
            // 
            this.RadioMale.AutoSize = true;
            this.RadioMale.Location = new System.Drawing.Point(726, 184);
            this.RadioMale.Name = "RadioMale";
            this.RadioMale.Size = new System.Drawing.Size(68, 27);
            this.RadioMale.TabIndex = 22;
            this.RadioMale.TabStop = true;
            this.RadioMale.Text = "муж.";
            this.RadioMale.UseVisualStyleBackColor = true;
            this.RadioMale.CheckedChanged += new System.EventHandler(this.ClickOnRadio);
            // 
            // RadioWoman
            // 
            this.RadioWoman.AutoSize = true;
            this.RadioWoman.Location = new System.Drawing.Point(823, 184);
            this.RadioWoman.Name = "RadioWoman";
            this.RadioWoman.Size = new System.Drawing.Size(67, 27);
            this.RadioWoman.TabIndex = 23;
            this.RadioWoman.TabStop = true;
            this.RadioWoman.Text = "жен.";
            this.RadioWoman.UseVisualStyleBackColor = true;
            this.RadioWoman.CheckedChanged += new System.EventHandler(this.ClickOnRadio);
            // 
            // Sender
            // 
            this.Sender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Sender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sender.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Sender.Location = new System.Drawing.Point(566, 390);
            this.Sender.Margin = new System.Windows.Forms.Padding(0);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(178, 38);
            this.Sender.TabIndex = 24;
            this.Sender.Text = "Отправить";
            this.Sender.UseVisualStyleBackColor = false;
            this.Sender.Click += new System.EventHandler(this.ClickOnSender);
            // 
            // AgreeCheckbox
            // 
            this.AgreeCheckbox.AutoSize = true;
            this.AgreeCheckbox.Location = new System.Drawing.Point(566, 356);
            this.AgreeCheckbox.Name = "AgreeCheckbox";
            this.AgreeCheckbox.Size = new System.Drawing.Size(339, 27);
            this.AgreeCheckbox.TabIndex = 25;
            this.AgreeCheckbox.Text = "Согласны ли вы с нашими условиями?";
            this.AgreeCheckbox.UseVisualStyleBackColor = true;
            this.AgreeCheckbox.CheckedChanged += new System.EventHandler(this.ClickOnCheckBox);
            // 
            // DirectionListBox
            // 
            this.DirectionListBox.FormattingEnabled = true;
            this.DirectionListBox.ItemHeight = 23;
            this.DirectionListBox.Items.AddRange(new object[] {
            "Драматург",
            "Публицист",
            "Романтик",
            "Критик",
            "Поэт"});
            this.DirectionListBox.Location = new System.Drawing.Point(726, 225);
            this.DirectionListBox.Name = "DirectionListBox";
            this.DirectionListBox.Size = new System.Drawing.Size(214, 27);
            this.DirectionListBox.TabIndex = 26;
            // 
            // LableDirection
            // 
            this.LableDirection.Location = new System.Drawing.Point(566, 225);
            this.LableDirection.Name = "LableDirection";
            this.LableDirection.Size = new System.Drawing.Size(154, 23);
            this.LableDirection.TabIndex = 27;
            this.LableDirection.Text = "Направление:";
            // 
            // ProgressBarOfReg
            // 
            this.ProgressBarOfReg.Location = new System.Drawing.Point(417, 28);
            this.ProgressBarOfReg.Name = "ProgressBarOfReg";
            this.ProgressBarOfReg.Size = new System.Drawing.Size(125, 29);
            this.ProgressBarOfReg.TabIndex = 28;
            // 
            // Getter
            // 
            this.Getter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Getter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Getter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Getter.Location = new System.Drawing.Point(810, 390);
            this.Getter.Margin = new System.Windows.Forms.Padding(0);
            this.Getter.Name = "Getter";
            this.Getter.Size = new System.Drawing.Size(178, 70);
            this.Getter.TabIndex = 29;
            this.Getter.Text = "Получить книгу из файла";
            this.Getter.UseVisualStyleBackColor = false;
            this.Getter.Click += new System.EventHandler(this.ClickGetter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 525);
            this.Controls.Add(this.Getter);
            this.Controls.Add(this.ProgressBarOfReg);
            this.Controls.Add(this.LableDirection);
            this.Controls.Add(this.DirectionListBox);
            this.Controls.Add(this.AgreeCheckbox);
            this.Controls.Add(this.Sender);
            this.Controls.Add(this.RadioWoman);
            this.Controls.Add(this.RadioMale);
            this.Controls.Add(this.LableSex);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.LableCountry);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.LableName);
            this.Controls.Add(this.LoudDateDateTime);
            this.Controls.Add(this.LabelLoudDate);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.LabelAuthor);
            this.Controls.Add(this.LableDateMaded);
            this.Controls.Add(this.MadeDateTime);
            this.Controls.Add(this.LableCountLists);
            this.Controls.Add(this.CountListsNumeric);
            this.Controls.Add(this.LableMader);
            this.Controls.Add(this.MaderTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.LableTitle);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.LabelSize);
            this.Controls.Add(this.LableType);
            this.Controls.Add(this.TypeTextBox);
            this.Name = "Form1";
            this.Text = "2";
            ((System.ComponentModel.ISupportInitialize)(this.CountListsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TypeTextBox;
        private Label LableType;
        private Label LabelSize;
        private TextBox SizeTextBox;
        private Label LableTitle;
        private TextBox TitleTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox MaderTextBox;
        private Label LableMader;
        private NumericUpDown CountListsNumeric;
        private Label LableCountLists;
        private DateTimePicker MadeDateTime;
        private Label LableDateMaded;
        private Label LabelAuthor;
        private TextBox AuthorTextBox;
        private Label LabelLoudDate;
        private DateTimePicker LoudDateDateTime;
        private Label LableName;
        private TextBox NameTextBox;
        private Label LableCountry;
        private TextBox CountryTextBox;
        private Label LableSex;
        private RadioButton RadioMale;
        private RadioButton RadioWoman;
        private Button Sender;
        private CheckBox AgreeCheckbox;
        private ListBox DirectionListBox;
        private Label LableDirection;
        private ProgressBar ProgressBarOfReg;
        private Button Getter;
    }
}