using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Noise_and_Filter
{
    class Gaussian_Noise
    {
        public static void Handle(Bitmap Source_Image, double Std_Value, PictureBox Result_picturebox,string Color_style)
        {
            if (Color_style == "單色")
                Gray(Source_Image, Std_Value, Result_picturebox);
            else
                Color(Source_Image, Std_Value, Result_picturebox);

        }

        private static void Gray(Bitmap Source_Image, double Std, PictureBox Result_picturebox)
        {
            int[,,] Source_Pixel = GetRGBData(Source_Image);
            int Image_Height = Source_Image.Height, Image_Width = Source_Image.Width;
            int[,] RandomNumber = new int[Image_Height, Image_Width];
            Random rnd = new Random();
            for (int i = 0; i < Image_Height; i++)
                for (int j = 0; j < Image_Width; j++)
                    RandomNumber[i, j] = rnd.Next(256);

            double[] SourceHistogram = new double[256];
            for (int i = 0; i < Image_Height; i++)
                for (int j = 0; j < Image_Width; j++)
                    SourceHistogram[RandomNumber[i, j]]++;
            for (int i = 0; i < 256; i++)
                SourceHistogram[i] = SourceHistogram[i] / (Image_Height * Image_Width);

            double[] SourceCDF = new double[256];
            SourceCDF[0] = SourceHistogram[0];
            for (int i = 1; i < 256; i++)
                SourceCDF[i] = SourceCDF[i - 1] + SourceHistogram[i];

            double[] TargetHistogram = new double[256];
            for (int i = 0; i < 256; i++)
                TargetHistogram[i] = (1 / Math.Sqrt((Math.PI * Std * Std))) * Math.Exp(-1 * (i - 127) * (i - 127) / (Std * Std));

            double Total = 0;
            for (int i = 0; i < 256; i++)
                Total += TargetHistogram[i];
            for (int i = 0; i < 256; i++)
                TargetHistogram[i] = TargetHistogram[i] / Total;

            double[] TargetCDF = new double[256];
            TargetCDF[0] = TargetHistogram[0];
            for (int i = 1; i < 256; i++)
                TargetCDF[i] = TargetCDF[i - 1] + TargetHistogram[i];

            int[] Mapping = new int[256];
            for (int i = 0; i < 256; i++)
            {
                int Nearst = 0;
                for (int j = 0; j < 256; j++)
                {
                    if (Math.Abs(SourceCDF[i] - TargetCDF[j]) < Math.Abs(SourceCDF[i] - TargetCDF[Nearst]))
                        Nearst = j;
                }
                Mapping[i] = Nearst;
            }

            Total = 0;
            for (int i = 0; i < Image_Height; i++)
                for (int j = 0; j < Image_Width; j++)
                {
                    RandomNumber[i, j] = Mapping[RandomNumber[i, j]];
                    Total += RandomNumber[i, j];
                }

            int Mean = (int)(Total / (double)(Image_Height * Image_Width));
            for (int i = 0; i < Image_Height; i++)
                for (int j = 0; j < Image_Width; j++)
                    RandomNumber[i, j] = RandomNumber[i, j] - Mean;

            int[,] result = new int[Image_Height, Image_Width];
            for (int i = 0; i < Image_Height; i++)
                for (int j = 0; j < Image_Width; j++)
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                    {
                        if (Source_Pixel[i, j, Index_RGB] + RandomNumber[i, j] > 255)
                            Source_Pixel[i, j, Index_RGB] = 255;
                        else if (Source_Pixel[i, j, Index_RGB] + RandomNumber[i, j] < 0)
                            Source_Pixel[i, j, Index_RGB] = 0;
                        else
                            Source_Pixel[i, j, Index_RGB] = Source_Pixel[i, j, Index_RGB] + RandomNumber[i, j];
                    }
            Bitmap Result = Source_Image.Clone(new Rectangle(0, 0, Image_Width, Image_Height), Source_Image.PixelFormat);
            Result = SetRGBData(Source_Pixel);
            Result_picturebox.Image = Result;
        }
        private static void Color(Bitmap Source_Image, double Std, PictureBox Result_picturebox)
        {
            int[,,] Source_Pixel = GetRGBData(Source_Image);
            int Image_Height = Source_Image.Height, Image_Width = Source_Image.Width;
            for(int Index_RGB = 0;Index_RGB < 3; Index_RGB++)
            {
                int[,] RandomNumber = new int[Image_Height, Image_Width];
                Random rnd = new Random();
                for (int i = 0; i < Image_Height; i++)
                    for (int j = 0; j < Image_Width; j++)
                        RandomNumber[i, j] = rnd.Next(256);

                double[] SourceHistogram = new double[256];
                for (int i = 0; i < Image_Height; i++)
                    for (int j = 0; j < Image_Width; j++)
                        SourceHistogram[RandomNumber[i, j]]++;
                for (int i = 0; i < 256; i++)
                    SourceHistogram[i] = SourceHistogram[i] / (Image_Height * Image_Width);

                double[] SourceCDF = new double[256];
                SourceCDF[0] = SourceHistogram[0];
                for (int i = 1; i < 256; i++)
                    SourceCDF[i] = SourceCDF[i - 1] + SourceHistogram[i];

                double[] TargetHistogram = new double[256];
                for (int i = 0; i < 256; i++)
                    TargetHistogram[i] = (1 / Math.Sqrt((Math.PI * Std * Std))) * Math.Exp(-1 * (i - 127) * (i - 127) / (Std * Std));

                double Total = 0;
                for (int i = 0; i < 256; i++)
                    Total += TargetHistogram[i];
                for (int i = 0; i < 256; i++)
                    TargetHistogram[i] = TargetHistogram[i] / Total;

                double[] TargetCDF = new double[256];
                TargetCDF[0] = TargetHistogram[0];
                for (int i = 1; i < 256; i++)
                    TargetCDF[i] = TargetCDF[i - 1] + TargetHistogram[i];

                int[] Mapping = new int[256];
                for (int i = 0; i < 256; i++)
                {
                    int Nearst = 0;
                    for (int j = 0; j < 256; j++)
                    {
                        if (Math.Abs(SourceCDF[i] - TargetCDF[j]) < Math.Abs(SourceCDF[i] - TargetCDF[Nearst]))
                            Nearst = j;
                    }
                    Mapping[i] = Nearst;
                }

                Total = 0;
                for (int i = 0; i < Image_Height; i++)
                    for (int j = 0; j < Image_Width; j++)
                    {
                        RandomNumber[i, j] = Mapping[RandomNumber[i, j]];
                        Total += RandomNumber[i, j];
                    }

                int Mean = (int)(Total / (double)(Image_Height * Image_Width));
                for (int i = 0; i < Image_Height; i++)
                    for (int j = 0; j < Image_Width; j++)
                        RandomNumber[i, j] = RandomNumber[i, j] - Mean;

                int[,] result = new int[Image_Height, Image_Width];
                for (int i = 0; i < Image_Height; i++)
                    for (int j = 0; j < Image_Width; j++)
                    {
                        if (Source_Pixel[i, j, Index_RGB] + RandomNumber[i, j] > 255)
                            Source_Pixel[i, j, Index_RGB] = 255;
                        else if (Source_Pixel[i, j, Index_RGB] + RandomNumber[i, j] < 0)
                            Source_Pixel[i, j, Index_RGB] = 0;
                        else
                            Source_Pixel[i, j, Index_RGB] = Source_Pixel[i, j, Index_RGB] + RandomNumber[i, j];
                    }
            }
            Bitmap Result = Source_Image.Clone(new Rectangle(0, 0, Image_Width, Image_Height), Source_Image.PixelFormat);
            Result = SetRGBData(Source_Pixel);
            Result_picturebox.Image = Result;
        }
        private static int[,,] GetRGBData(Bitmap bitImg)
        {
            int height = bitImg.Height;
            int width = bitImg.Width;
            //locking
            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // get the starting memory place
            IntPtr imgPtr = bitmapData.Scan0;
            //scan width
            int stride = bitmapData.Stride;
            //scan ectual
            int widthByte = width * 3;
            // the byte num of padding
            int skipByte = stride - widthByte;
            //set the place to save values
            int[,,] rgbData = new int[height, width, 3];
            #region
            unsafe//專案－＞屬性－＞建置－＞容許Unsafe程式碼須選取。
            {
                byte* p = (byte*)(void*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        //B channel
                        rgbData[j, i, 2] = p[0];
                        p++;
                        //g channel
                        rgbData[j, i, 1] = p[0];
                        p++;
                        //R channel
                        rgbData[j, i, 0] = p[0];
                        p++;
                    }
                    p += skipByte;
                }
            }
            bitImg.UnlockBits(bitmapData);
            #endregion
            return rgbData;
        }
        private static Bitmap SetRGBData(int[,,] rgbData)
        {
            //宣告Bitmap變數
            Bitmap bitImg;
            int width = rgbData.GetLength(1);
            int height = rgbData.GetLength(0);

            //依陣列長寬設定Bitmap新的物件
            bitImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            //鎖住Bitmap整個影像內容
            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            //取得影像資料的起始位置
            IntPtr imgPtr = bitmapData.Scan0;
            //影像scan的寬度
            int stride = bitmapData.Stride;
            //影像陣列的實際寬度
            int widthByte = width * 3;
            //所Padding的Byte數
            int skipByte = stride - widthByte;

            #region 設定RGB資料
            //注意C#的GDI+內的影像資料順序為BGR, 非一般熟悉的順序RGB
            //因此我們把順序調回GDI+的設定值, RGB->BGR
            unsafe
            {
                byte* p = (byte*)(void*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        //B Channel
                        p[0] = (byte)rgbData[j, i, 2];
                        p++;
                        //G Channel
                        p[0] = (byte)rgbData[j, i, 1];
                        p++;
                        //B Channel
                        p[0] = (byte)rgbData[j, i, 0];
                        p++;
                    }
                    p += skipByte;
                }
            }

            //解開記憶體鎖
            bitImg.UnlockBits(bitmapData);

            #endregion

            return bitImg;
        }
    }
}
