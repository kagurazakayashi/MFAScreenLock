using MFAScreenLockApp.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    class ShareClass
    {
        public static Bitmap gWallPaperBmp()
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + Settings.Default.Background;
            if (Settings.Default.Background.Length > 0)
            {
                if (File.Exists(Settings.Default.Background))
                {
                    FileStream fileStream = File.OpenRead(Settings.Default.Background);
                    Int32 filelength = 0;
                    filelength = (int)fileStream.Length;
                    Byte[] image = new Byte[filelength];
                    fileStream.Read(image, 0, filelength);
                    Image result = Image.FromStream(fileStream);
                    fileStream.Close();
                    return new Bitmap(result);
                }
            }
            return SysLink.GetwallPaper();
        }

        public static Image autoScaleBitmap(Bitmap wallPaperBmp, Size size)
        {
            if (Settings.Default.Scale == 0)
            {
                return null;
            }
            else if (Settings.Default.Scale == 5)
            {
                return ImageControl.scaleBitmap(wallPaperBmp, size.Width, size.Height);
            }
            return wallPaperBmp;
        }

        public static ImageLayout imageLayout()
        {
            switch (Settings.Default.Scale)
            {
                case 0:
                    return ImageLayout.None;
                case 1:
                    return ImageLayout.None;
                case 2:
                    return ImageLayout.Center;
                case 3:
                    return ImageLayout.Stretch;
                case 4:
                    return ImageLayout.Zoom;
                default:
                    return ImageLayout.Stretch;
            }
        }
    }
}
