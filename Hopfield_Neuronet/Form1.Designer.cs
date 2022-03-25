namespace NetworkofHopfild
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
            this.damagePic = new System.Windows.Forms.PictureBox();
            this.listPictures = new System.Windows.Forms.ListBox();
            this.recoverPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recoverButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureArrow = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.damagePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoverPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // damagePic
            // 
            this.damagePic.Location = new System.Drawing.Point(11, 24);
            this.damagePic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.damagePic.Name = "damagePic";
            this.damagePic.Size = new System.Drawing.Size(151, 151);
            this.damagePic.TabIndex = 0;
            this.damagePic.TabStop = false;
            // 
            // listPictures
            // 
            this.listPictures.FormattingEnabled = true;
            this.listPictures.Location = new System.Drawing.Point(166, 24);
            this.listPictures.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listPictures.Name = "listPictures";
            this.listPictures.Size = new System.Drawing.Size(90, 147);
            this.listPictures.TabIndex = 1;
            this.listPictures.SelectedIndexChanged += new System.EventHandler(this.listPictures_SelectedIndexChanged);
            // 
            // recoverPic
            // 
            this.recoverPic.Location = new System.Drawing.Point(11, 192);
            this.recoverPic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.recoverPic.Name = "recoverPic";
            this.recoverPic.Size = new System.Drawing.Size(151, 151);
            this.recoverPic.TabIndex = 2;
            this.recoverPic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Искаженный образ";
            // 
            // recoverButton
            // 
            this.recoverButton.Location = new System.Drawing.Point(166, 175);
            this.recoverButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.recoverButton.Name = "recoverButton";
            this.recoverButton.Size = new System.Drawing.Size(90, 39);
            this.recoverButton.TabIndex = 4;
            this.recoverButton.Text = "Восстановить";
            this.recoverButton.UseVisualStyleBackColor = true;
            this.recoverButton.Click += new System.EventHandler(this.recoverButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Восстановленный образ";
            // 
            // pictureArrow
            // 
            this.pictureArrow.Location = new System.Drawing.Point(166, 218);
            this.pictureArrow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureArrow.Name = "pictureArrow";
            this.pictureArrow.Size = new System.Drawing.Size(44, 41);
            this.pictureArrow.TabIndex = 6;
            this.pictureArrow.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            this.label3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 352);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureArrow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recoverButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recoverPic);
            this.Controls.Add(this.listPictures);
            this.Controls.Add(this.damagePic);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.damagePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recoverPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox damagePic;
        private System.Windows.Forms.ListBox listPictures;
        private System.Windows.Forms.PictureBox recoverPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button recoverButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureArrow;
        private System.Windows.Forms.Label label3;
    }
}

