namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Monitor = new System.Windows.Forms.TextBox();
            this.And = new System.Windows.Forms.Button();
            this.Or = new System.Windows.Forms.Button();
            this.Not = new System.Windows.Forms.Button();
            this.Equal = new System.Windows.Forms.Button();
            this.Enc_2 = new System.Windows.Forms.Button();
            this.c = new System.Windows.Forms.Button();
            this.Enc_16 = new System.Windows.Forms.Button();
            this.Translator = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Monitor
            // 
            this.Monitor.Location = new System.Drawing.Point(251, 36);
            this.Monitor.Name = "Monitor";
            this.Monitor.Size = new System.Drawing.Size(171, 22);
            this.Monitor.TabIndex = 0;
            // 
            // And
            // 
            this.And.Location = new System.Drawing.Point(251, 64);
            this.And.Name = "And";
            this.And.Size = new System.Drawing.Size(40, 23);
            this.And.TabIndex = 1;
            this.And.Text = "и";
            this.And.UseVisualStyleBackColor = true;
            this.And.Click += new System.EventHandler(this.OperationClick);
            // 
            // Or
            // 
            this.Or.Location = new System.Drawing.Point(297, 64);
            this.Or.Name = "Or";
            this.Or.Size = new System.Drawing.Size(60, 23);
            this.Or.TabIndex = 2;
            this.Or.Text = "или";
            this.Or.UseVisualStyleBackColor = true;
            this.Or.Click += new System.EventHandler(this.OperationClick);
            // 
            // Not
            // 
            this.Not.Location = new System.Drawing.Point(363, 64);
            this.Not.Name = "Not";
            this.Not.Size = new System.Drawing.Size(40, 23);
            this.Not.TabIndex = 3;
            this.Not.Text = "~";
            this.Not.UseVisualStyleBackColor = true;
            this.Not.Click += new System.EventHandler(this.OperationClick);
            // 
            // Equal
            // 
            this.Equal.Location = new System.Drawing.Point(428, 35);
            this.Equal.Name = "Equal";
            this.Equal.Size = new System.Drawing.Size(40, 23);
            this.Equal.TabIndex = 4;
            this.Equal.Text = "=";
            this.Equal.UseVisualStyleBackColor = true;
            this.Equal.Click += new System.EventHandler(this.EqualClick);
            // 
            // Enc_2
            // 
            this.Enc_2.Location = new System.Drawing.Point(251, 93);
            this.Enc_2.Name = "Enc_2";
            this.Enc_2.Size = new System.Drawing.Size(40, 23);
            this.Enc_2.TabIndex = 5;
            this.Enc_2.Text = "2";
            this.Enc_2.UseVisualStyleBackColor = true;
            this.Enc_2.Click += new System.EventHandler(this.OperationConvertClick);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(297, 93);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(40, 23);
            this.c.TabIndex = 6;
            this.c.Text = "8";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.OperationConvertClick);
            // 
            // Enc_16
            // 
            this.Enc_16.Location = new System.Drawing.Point(343, 93);
            this.Enc_16.Name = "Enc_16";
            this.Enc_16.Size = new System.Drawing.Size(40, 23);
            this.Enc_16.TabIndex = 7;
            this.Enc_16.Text = "16";
            this.Enc_16.UseVisualStyleBackColor = true;
            this.Enc_16.Click += new System.EventHandler(this.OperationConvertClick);
            // 
            // Translator
            // 
            this.Translator.Location = new System.Drawing.Point(251, 8);
            this.Translator.Name = "Translator";
            this.Translator.Size = new System.Drawing.Size(171, 22);
            this.Translator.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Translator);
            this.Controls.Add(this.Enc_16);
            this.Controls.Add(this.c);
            this.Controls.Add(this.Enc_2);
            this.Controls.Add(this.Equal);
            this.Controls.Add(this.Not);
            this.Controls.Add(this.Or);
            this.Controls.Add(this.And);
            this.Controls.Add(this.Monitor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Monitor;
        private System.Windows.Forms.Button And;
        private System.Windows.Forms.Button Or;
        private System.Windows.Forms.Button Not;
        private System.Windows.Forms.Button Equal;
        private System.Windows.Forms.Button Enc_2;
        private System.Windows.Forms.Button c;
        private System.Windows.Forms.Button Enc_16;
        private System.Windows.Forms.TextBox Translator;
    }
}

