namespace lab3.Sorting
{
    partial class Sorting
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
            this.ByTitle = new System.Windows.Forms.RadioButton();
            this.ByDateLoud = new System.Windows.Forms.RadioButton();
            this.DatasTo = new System.Windows.Forms.ListBox();
            this.Save = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ByTitle
            // 
            this.ByTitle.AutoSize = true;
            this.ByTitle.Location = new System.Drawing.Point(29, 29);
            this.ByTitle.Name = "ByTitle";
            this.ByTitle.Size = new System.Drawing.Size(132, 27);
            this.ByTitle.TabIndex = 0;
            this.ByTitle.TabStop = true;
            this.ByTitle.Text = "По название";
            this.ByTitle.UseVisualStyleBackColor = true;
            this.ByTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickRadio);
            // 
            // ByDateLoud
            // 
            this.ByDateLoud.AutoSize = true;
            this.ByDateLoud.Location = new System.Drawing.Point(197, 29);
            this.ByDateLoud.Name = "ByDateLoud";
            this.ByDateLoud.Size = new System.Drawing.Size(165, 27);
            this.ByDateLoud.TabIndex = 1;
            this.ByDateLoud.TabStop = true;
            this.ByDateLoud.Text = "По дате загрузки";
            this.ByDateLoud.UseVisualStyleBackColor = true;
            this.ByDateLoud.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickRadio);
            // 
            // DatasTo
            // 
            this.DatasTo.FormattingEnabled = true;
            this.DatasTo.ItemHeight = 23;
            this.DatasTo.Location = new System.Drawing.Point(15, 78);
            this.DatasTo.Name = "DatasTo";
            this.DatasTo.Size = new System.Drawing.Size(1066, 763);
            this.DatasTo.TabIndex = 2;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Save.Location = new System.Drawing.Point(902, 29);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(179, 43);
            this.Save.TabIndex = 10;
            this.Save.Text = "Сохранить данные";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.SaveInfo);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(694, 27);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(30, 29);
            this.Back.TabIndex = 11;
            this.Back.Text = "<";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new EventHandler(this.ClickOnBack);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(730, 28);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(30, 29);
            this.Next.TabIndex = 12;
            this.Next.Text = ">";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new EventHandler(this.ClickOnNext);
            // 
            // Sorting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 600);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DatasTo);
            this.Controls.Add(this.ByDateLoud);
            this.Controls.Add(this.ByTitle);
            this.Name = "Sorting";
            this.Text = "Sorting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton ByTitle;
        private RadioButton ByDateLoud;
        private ListBox DatasTo;
        private Button Save;
        private Button Back;
        private Button Next;
    }
}