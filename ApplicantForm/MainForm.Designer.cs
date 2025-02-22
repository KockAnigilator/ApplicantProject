namespace ApplicantForm
{
    partial class MainForm
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
            this.btnAddApplicant = new System.Windows.Forms.Button();
            this.btnShowRanking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddApplicant
            // 
            this.btnAddApplicant.Location = new System.Drawing.Point(199, 160);
            this.btnAddApplicant.Name = "btnAddApplicant";
            this.btnAddApplicant.Size = new System.Drawing.Size(167, 69);
            this.btnAddApplicant.TabIndex = 0;
            this.btnAddApplicant.Text = "Добавить абитуриента";
            this.btnAddApplicant.UseVisualStyleBackColor = true;
            // 
            // btnShowRanking
            // 
            this.btnShowRanking.Location = new System.Drawing.Point(411, 160);
            this.btnShowRanking.Name = "btnShowRanking";
            this.btnShowRanking.Size = new System.Drawing.Size(167, 69);
            this.btnShowRanking.TabIndex = 1;
            this.btnShowRanking.Text = "Показать рейтинг";
            this.btnShowRanking.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnShowRanking);
            this.Controls.Add(this.btnAddApplicant);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddApplicant;
        private System.Windows.Forms.Button btnShowRanking;
    }
}

