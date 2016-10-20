using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Noise_and_Filter
{
    class Media
    {
        public static Bitmap Handle(Bitmap Source_Image, int Mask_Size)
        {
            int[,,] Source_Pixel = GetRGBData(Source_Image);
            int Image_Height = Source_Image.Height, Image_Width = Source_Image.Width;
            int Edge_Size = (Mask_Size - 1) / 2;
            int[,,] Padding_pixel = Padding_Image(Source_Pixel, Image_Height, Image_Width, Edge_Size);
            for (int Index_Height = 0; Index_Height < Image_Height; Index_Height++)
            {
                for (int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
                {
                    Count_Media(Padding_pixel, Source_Pixel, Index_Height, Index_Width, Mask_Size);
                }
            }
            Bitmap Result = Source_Image.Clone(new Rectangle(0, 0, Image_Width, Image_Height), Source_Image.PixelFormat);
            Result = SetRGBData(Source_Pixel);
            return Result;
        }
        private static void Count_Media(int[,,] Padding_Pixel, int[,,] Source_Pixel, int Image_Height, int Image_Width, int Mask_Size)
        {
            int Edge_Size = (Mask_Size - 1) / 2;
            for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
            {
                int[] Mask_Array = new int[Mask_Size* Mask_Size];
                int Array_Number = 0;
                for (int Index_Mask_Width = 0; Index_Mask_Width < Mask_Size; Index_Mask_Width++)
                    for (int Index_Mask_Hieght = 0; Index_Mask_Hieght < Mask_Size; Index_Mask_Hieght++)
                    {
                        Mask_Array[Array_Number] = Padding_Pixel[Image_Height + Index_Mask_Hieght, Image_Width + Index_Mask_Width, Index_RGB];
                        Array_Number++;
                    }
                Array.Sort(Mask_Array);
                Source_Pixel[Image_Height, Image_Width, Index_RGB] = Mask_Array[(Mask_Size* Mask_Size) /2];
            }
        }
        private static int[,,] Padding_Image(int[,,] Source_Pixel, int Image_Height, int Image_Width, int Edge)
        {
            int[,,] New_Pixel = new int[Image_Height + (Edge * 2), Image_Width + (Edge * 2), 3];
            //Copy source pixel in New_pixel center.
            for (int Index_Height = 0; Index_Height < Image_Height; Index_Height++)
                for (int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                        New_Pixel[Index_Height + Edge, Index_Width + Edge, Index_RGB] = Source_Pixel[Index_Height, Index_Width, Index_RGB];
            //Padding
            for (int Index_Level = 1; Index_Level <= Edge; Index_Level++)
            {
                for (int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
                {
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                    {
                        New_Pixel[Edge - Index_Level, Index_Width + Edge, Index_RGB] = Source_Pixel[0, Index_Width, Index_RGB];
                        New_Pixel[Index_Level + Image_Height, Index_Width + Edge, Index_RGB] = Source_Pixel[Image_Height - 1, Index_Width, Index_RGB];
                    }
                }
                for (int Index_Height = 0; Index_Height < Image_Height; Index_Height++)
                {
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                    {
                        New_Pixel[Edge + Index_Height, Edge - Index_Level, Index_RGB] = Source_Pixel[Index_Height, 0, Index_RGB];
                        New_Pixel[Index_Level + Index_Height, Image_Width + Edge, Index_RGB] = Source_Pixel[Index_Height, Image_Width - 1, Index_RGB];
                    }
                }
            }
            for (int Height_Edge = 0; Height_Edge < Edge; Height_Edge++)
            {
                for (int Width_Edge = 0; Width_Edge < Edge; Width_Edge++)
                {
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                    {
                        New_Pixel[Height_Edge, Width_Edge, Index_RGB] = Source_Pixel[0, 0, Index_RGB];
                        New_Pixel[Height_Edge, Width_Edge + Image_Width, Index_RGB] = Source_Pixel[0, Image_Width - 1, Index_RGB];
                        New_Pixel[Height_Edge + Image_Height, Width_Edge, Index_RGB] = Source_Pixel[Image_Height - 1, 0, Index_RGB];
                        New_Pixel[Height_Edge + Image_Height, Width_Edge + Image_Width, Index_RGB] = Source_Pixel[Image_Height - 1, Image_Width - 1, Index_RGB];
                    }
                }
            }
            return New_Pixel;
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
