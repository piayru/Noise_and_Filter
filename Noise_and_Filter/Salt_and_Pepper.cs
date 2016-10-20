using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Noise_and_Filter
{
    class Salt_And_Pepper
    {
        public static Bitmap Handle(Bitmap Source_Image,int Percent)
        {
            int[,,] Source_Pixel = GetRGBData(Source_Image);
            int Image_Height = Source_Image.Height, Image_Width = Source_Image.Width;
            int Percent_Number = (Percent * Image_Height * Image_Width / 100);
            Random RD = new Random(Guid.NewGuid().GetHashCode());
            int[,] RD_Site = new int[Image_Height, Image_Width];
            int RD_num = 0;
            while(RD_num!= Percent_Number)
            {
                int Rand_Height = RD.Next(0, Image_Height), Rand_Width = RD.Next(0, Image_Width);
                if(RD_Site[Rand_Height, Rand_Width] == 0)
                {
                    RD_num++;
                    RD_Site[Rand_Height, Rand_Width] = RD_num;
                }
                if (RD_num == Percent_Number)
                    break;
            }
            for(int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
            {
                for (int Index_Height = 0; Index_Height < Image_Height; Index_Height++)
                {
                    if (RD_Site[Index_Height, Index_Width] == 0)
                        continue;
                    int This_Color = (RD_Site[Index_Height, Index_Width] % 2) * 255;

                    Source_Pixel[Index_Height, Index_Width, 0] = This_Color;
                    Source_Pixel[Index_Height, Index_Width, 1] = This_Color;
                    Source_Pixel[Index_Height, Index_Width, 2] = This_Color;
                }
            }

            Bitmap Result = Source_Image.Clone(new Rectangle(0, 0, Image_Width, Image_Height), Source_Image.PixelFormat);
            Result = SetRGBData(Source_Pixel);
            return Result;
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
