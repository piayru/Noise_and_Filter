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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap Source_Image = new Bitmap(openFileDialog1.FileName);
                Source_Image_PictureBox.Image = Source_Image;
            }
        }
        private void Change_SaltAndPepper_NumberLable(object sender, EventArgs e)
        {
            Salt_and_Pepper_Number.Text = trackBar1.Value.ToString() + "%";
        }
    }
}
