using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noise_and_Filter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Gaussian_Color.Items.AddRange(new object[] {"單色",
                        "彩色"});
            Gaussian_Color.SelectedItem = "單色";

            Mean_Mask_Size.Items.AddRange(new object[] {"3 x 3",
                        "5 x 5",
                        "7 x 7",
                        "9 x 9",
                        "11 x 11"});
            Mean_Mask_Size.SelectedItem = "3 x 3";
            Media_Mask_Size.Items.AddRange(new object[] {"3 x 3",
                        "5 x 5",
                        "7 x 7",
                        "9 x 9",
                        "11 x 11"});
            Media_Mask_Size.SelectedItem = "3 x 3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap Source_Image = new Bitmap(openFileDialog1.FileName);
                    Source_Image_PictureBox.Image = Source_Image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請開啟圖檔");
                }
            }
        }

        private void Change_SaltAndPepper_NumberLable(object sender, EventArgs e)
        {
            Salt_and_Pepper_Number.Text = trackBar1.Value.ToString() + "%";
        }

        private void Noise_Button_Click(object sender, EventArgs e)
        {
            Bitmap Source_Image = new Bitmap(Source_Image_PictureBox.Image);
            if (Gaussian_Noise_Button.Checked == true)
            {
                double Std_Value;
                try
                {
                    Std_Value = Convert.ToDouble(Standard_Value.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請輸入正確數字");
                    return;
                }
                if (Std_Value < 0)
                {
                    MessageBox.Show("請輸入正確數字");
                    return;
                }
                Gaussian_Noise.Handle(Source_Image, Std_Value, Noise_Result_Image_PictureBox, Gaussian_Color.SelectedItem.ToString());
            }


            if (Salt_and_Pepper.Checked == true)
                Noise_Result_Image_PictureBox.Image = Salt_And_Pepper.Handle(Source_Image, trackBar1.Value);

        }

        private void Filter_Button_Click(object sender, EventArgs e)
        {
            Bitmap Source_Image;
            if (Use_Noise_Result.Checked == true)
            {
                try
                {
                    Source_Image = new Bitmap(Noise_Result_Image_PictureBox.Image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("沒有輸出圖片");
                    return;
                }
            }
            else
            {
                Source_Image = new Bitmap(Source_Image_PictureBox.Image);
            }

            if (Mean_Filter_Button.Checked == true)
            {
                int Mask_Size = Convert.ToInt32(Mean_Mask_Size.SelectedItem.ToString().Split()[0]);
                Filter_Result_Image_PictureBox.Image = Mean_Filter.Handle(Source_Image, Mask_Size);
            }
            else
            {
                int Mask_Size = Convert.ToInt32(Media_Mask_Size.SelectedItem.ToString().Split()[0]);
                Filter_Result_Image_PictureBox.Image = Media.Handle(Source_Image, Mask_Size);
            }
        }
    }
}
