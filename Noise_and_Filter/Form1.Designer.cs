namespace Noise_and_Filter
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Source_Image_PictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Gaussian_Noise_Button = new System.Windows.Forms.RadioButton();
            this.Salt_and_Pepper = new System.Windows.Forms.RadioButton();
            this.Mean_Filter_Button = new System.Windows.Forms.RadioButton();
            this.Media_Filter_Button = new System.Windows.Forms.RadioButton();
            this.Noise_Result_Image_PictureBox = new System.Windows.Forms.PictureBox();
            this.Filter_Result_Image_PictureBox = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Salt_and_Pepper_Number = new System.Windows.Forms.Label();
            this.Use_Noise_Result = new System.Windows.Forms.CheckBox();
            this.Filter_Button = new System.Windows.Forms.Button();
            this.Noise_Button = new System.Windows.Forms.Button();
            this.Mean_Mask_Size = new System.Windows.Forms.ComboBox();
            this.Media_Mask_Size = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Source_Image_PictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Noise_Result_Image_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Result_Image_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "開啟圖檔";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Source_Image_PictureBox
            // 
            this.Source_Image_PictureBox.Location = new System.Drawing.Point(12, 12);
            this.Source_Image_PictureBox.Name = "Source_Image_PictureBox";
            this.Source_Image_PictureBox.Size = new System.Drawing.Size(409, 490);
            this.Source_Image_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Source_Image_PictureBox.TabIndex = 1;
            this.Source_Image_PictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Noise_Button);
            this.groupBox1.Controls.Add(this.Salt_and_Pepper_Number);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.Salt_and_Pepper);
            this.groupBox1.Controls.Add(this.Gaussian_Noise_Button);
            this.groupBox1.Location = new System.Drawing.Point(441, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 462);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "雜訊";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Media_Mask_Size);
            this.groupBox2.Controls.Add(this.Mean_Mask_Size);
            this.groupBox2.Controls.Add(this.Filter_Button);
            this.groupBox2.Controls.Add(this.Use_Noise_Result);
            this.groupBox2.Controls.Add(this.Media_Filter_Button);
            this.groupBox2.Controls.Add(this.Mean_Filter_Button);
            this.groupBox2.Location = new System.Drawing.Point(441, 497);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 145);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "濾波";
            // 
            // Gaussian_Noise_Button
            // 
            this.Gaussian_Noise_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.Gaussian_Noise_Button.AutoSize = true;
            this.Gaussian_Noise_Button.Checked = true;
            this.Gaussian_Noise_Button.Location = new System.Drawing.Point(6, 40);
            this.Gaussian_Noise_Button.Name = "Gaussian_Noise_Button";
            this.Gaussian_Noise_Button.Size = new System.Drawing.Size(93, 16);
            this.Gaussian_Noise_Button.TabIndex = 0;
            this.Gaussian_Noise_Button.TabStop = true;
            this.Gaussian_Noise_Button.Text = "Gaussian Noise";
            this.Gaussian_Noise_Button.UseVisualStyleBackColor = true;
            // 
            // Salt_and_Pepper
            // 
            this.Salt_and_Pepper.AutoSize = true;
            this.Salt_and_Pepper.Location = new System.Drawing.Point(6, 333);
            this.Salt_and_Pepper.Name = "Salt_and_Pepper";
            this.Salt_and_Pepper.Size = new System.Drawing.Size(95, 16);
            this.Salt_and_Pepper.TabIndex = 1;
            this.Salt_and_Pepper.Text = "Salt and Pepper";
            this.Salt_and_Pepper.UseVisualStyleBackColor = true;
            // 
            // Mean_Filter_Button
            // 
            this.Mean_Filter_Button.AutoSize = true;
            this.Mean_Filter_Button.Checked = true;
            this.Mean_Filter_Button.Location = new System.Drawing.Point(6, 21);
            this.Mean_Filter_Button.Name = "Mean_Filter_Button";
            this.Mean_Filter_Button.Size = new System.Drawing.Size(76, 16);
            this.Mean_Filter_Button.TabIndex = 1;
            this.Mean_Filter_Button.TabStop = true;
            this.Mean_Filter_Button.Text = "Mean Filter";
            this.Mean_Filter_Button.UseVisualStyleBackColor = true;
            // 
            // Media_Filter_Button
            // 
            this.Media_Filter_Button.AutoSize = true;
            this.Media_Filter_Button.Location = new System.Drawing.Point(126, 21);
            this.Media_Filter_Button.Name = "Media_Filter_Button";
            this.Media_Filter_Button.Size = new System.Drawing.Size(79, 16);
            this.Media_Filter_Button.TabIndex = 2;
            this.Media_Filter_Button.Text = "Media Filter";
            this.Media_Filter_Button.UseVisualStyleBackColor = true;
            // 
            // Noise_Result_Image_PictureBox
            // 
            this.Noise_Result_Image_PictureBox.Location = new System.Drawing.Point(712, 12);
            this.Noise_Result_Image_PictureBox.Name = "Noise_Result_Image_PictureBox";
            this.Noise_Result_Image_PictureBox.Size = new System.Drawing.Size(316, 312);
            this.Noise_Result_Image_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Noise_Result_Image_PictureBox.TabIndex = 5;
            this.Noise_Result_Image_PictureBox.TabStop = false;
            // 
            // Filter_Result_Image_PictureBox
            // 
            this.Filter_Result_Image_PictureBox.Location = new System.Drawing.Point(712, 330);
            this.Filter_Result_Image_PictureBox.Name = "Filter_Result_Image_PictureBox";
            this.Filter_Result_Image_PictureBox.Size = new System.Drawing.Size(316, 312);
            this.Filter_Result_Image_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Filter_Result_Image_PictureBox.TabIndex = 6;
            this.Filter_Result_Image_PictureBox.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar1.Location = new System.Drawing.Point(7, 363);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(198, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.Change_SaltAndPepper_NumberLable);
            // 
            // Salt_and_Pepper_Number
            // 
            this.Salt_and_Pepper_Number.AutoSize = true;
            this.Salt_and_Pepper_Number.Location = new System.Drawing.Point(87, 396);
            this.Salt_and_Pepper_Number.Name = "Salt_and_Pepper_Number";
            this.Salt_and_Pepper_Number.Size = new System.Drawing.Size(26, 12);
            this.Salt_and_Pepper_Number.TabIndex = 3;
            this.Salt_and_Pepper_Number.Text = "10%";
            // 
            // Use_Noise_Result
            // 
            this.Use_Noise_Result.AutoSize = true;
            this.Use_Noise_Result.Location = new System.Drawing.Point(7, 83);
            this.Use_Noise_Result.Name = "Use_Noise_Result";
            this.Use_Noise_Result.Size = new System.Drawing.Size(144, 16);
            this.Use_Noise_Result.TabIndex = 3;
            this.Use_Noise_Result.Text = "使用雜訊輸出作為輸入";
            this.Use_Noise_Result.UseVisualStyleBackColor = true;
            // 
            // Filter_Button
            // 
            this.Filter_Button.Location = new System.Drawing.Point(65, 105);
            this.Filter_Button.Name = "Filter_Button";
            this.Filter_Button.Size = new System.Drawing.Size(75, 23);
            this.Filter_Button.TabIndex = 4;
            this.Filter_Button.Text = "計算濾波";
            this.Filter_Button.UseVisualStyleBackColor = true;
            this.Filter_Button.Click += new System.EventHandler(this.Filter_Button_Click);
            // 
            // Noise_Button
            // 
            this.Noise_Button.Location = new System.Drawing.Point(65, 433);
            this.Noise_Button.Name = "Noise_Button";
            this.Noise_Button.Size = new System.Drawing.Size(75, 23);
            this.Noise_Button.TabIndex = 5;
            this.Noise_Button.Text = "計算雜訊";
            this.Noise_Button.UseVisualStyleBackColor = true;
            this.Noise_Button.Click += new System.EventHandler(this.Noise_Button_Click);
            // 
            // Mean_Mask_Size
            // 
            this.Mean_Mask_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mean_Mask_Size.FormattingEnabled = true;
            this.Mean_Mask_Size.Location = new System.Drawing.Point(17, 43);
            this.Mean_Mask_Size.Name = "Mean_Mask_Size";
            this.Mean_Mask_Size.Size = new System.Drawing.Size(65, 20);
            this.Mean_Mask_Size.TabIndex = 7;
            // 
            // Media_Mask_Size
            // 
            this.Media_Mask_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Media_Mask_Size.FormattingEnabled = true;
            this.Media_Mask_Size.Location = new System.Drawing.Point(126, 43);
            this.Media_Mask_Size.Name = "Media_Mask_Size";
            this.Media_Mask_Size.Size = new System.Drawing.Size(65, 20);
            this.Media_Mask_Size.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1043, 664);
            this.Controls.Add(this.Filter_Result_Image_PictureBox);
            this.Controls.Add(this.Noise_Result_Image_PictureBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Source_Image_PictureBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Source_Image_PictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Noise_Result_Image_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Result_Image_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox Source_Image_PictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Salt_and_Pepper;
        private System.Windows.Forms.RadioButton Gaussian_Noise_Button;
        private System.Windows.Forms.RadioButton Media_Filter_Button;
        private System.Windows.Forms.RadioButton Mean_Filter_Button;
        private System.Windows.Forms.PictureBox Noise_Result_Image_PictureBox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label Salt_and_Pepper_Number;
        private System.Windows.Forms.Button Filter_Button;
        private System.Windows.Forms.CheckBox Use_Noise_Result;
        private System.Windows.Forms.Button Noise_Button;
        private System.Windows.Forms.ComboBox Mean_Mask_Size;
        private System.Windows.Forms.ComboBox Media_Mask_Size;
        internal System.Windows.Forms.PictureBox Filter_Result_Image_PictureBox;
    }
}

