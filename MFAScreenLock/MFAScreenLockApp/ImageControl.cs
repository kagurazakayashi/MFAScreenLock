using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFAScreenLockApp
{
    class ImageControl
    {
        public static double CalculateAverageLightness(Bitmap bm)
        {
            double lum = 0;
            var tmpBmp = new Bitmap(bm);
            var width = bm.Width;
            var height = bm.Height;
            var bppModifier = bm.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;

            var srcData = tmpBmp.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
            var stride = srcData.Stride;
            var scan0 = srcData.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int idx = (y * stride) + x * bppModifier;
                        lum += (0.299 * p[idx + 2] + 0.587 * p[idx + 1] + 0.114 * p[idx]);
                    }
                }
            }
            tmpBmp.UnlockBits(srcData);
            tmpBmp.Dispose();
            var avgLum = lum / (width * height);
            return avgLum / 255.0;
        }

        public static Bitmap scaleBitmap(Bitmap bitmap, float w, float h)
        {
            float width = bitmap.Width;
            float height = bitmap.Height;
            float x = 0, y = 0, scaleWidth = width, scaleHeight = height;
            if (w > h)
            {//比例宽度大于高度的情况
                float scale = w / h;
                float tempH = width / scale;
                if (height > tempH)
                {//
                    x = 0;
                    y = (height - tempH) / 2;
                    scaleWidth = width;
                    scaleHeight = tempH;
                }
                else
                {
                    scaleWidth = height * scale;
                    x = (width - scaleWidth) / 2;
                    y = 0;
                }
            }
            else if (w < h)
            {//比例宽度小于高度的情况
                float scale = h / w;
                float tempW = height / scale;
                if (width > tempW)
                {
                    y = 0;
                    x = (width - tempW) / 2;
                    scaleWidth = tempW;
                    scaleHeight = height;
                }
                else
                {
                    scaleHeight = width * scale;
                    y = (height - scaleHeight) / 2;
                    x = 0;
                    scaleWidth = width;
                }

            }
            else
            {//比例宽高相等的情况
                if (width > height)
                {
                    x = (width - height) / 2;
                    y = 0;
                    scaleHeight = height;
                    scaleWidth = height;
                }
                else
                {
                    y = (height - width) / 2;
                    x = 0;
                    scaleHeight = width;
                    scaleWidth = width;
                }
            }
            Rectangle cropArea = new Rectangle((int)x, (int)y, (int)scaleWidth, (int)scaleHeight);
            Bitmap bmpCrop = bitmap.Clone(cropArea, bitmap.PixelFormat);
            return bmpCrop;
        }
    }
}
