using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    public partial class FormLockSub : Form
    {
        public Bitmap wallPaperBmp = null;
        private Image wallPaperImg = null;

        public FormLockSub()
        {
            InitializeComponent();
        }

        private void FormLockSub_Load(object sender, EventArgs e)
        {
            if (wallPaperBmp != null)
            {
                wallPaperImg = ImageControl.scaleBitmap(wallPaperBmp, Size.Width, Size.Height);
                BackgroundImage = wallPaperImg;
            }
        }

        ~FormLockSub()
        {
            if (wallPaperBmp != null) wallPaperBmp.Dispose();
            if (wallPaperImg != null) wallPaperImg.Dispose();
            Dispose();
        }
    }
}
