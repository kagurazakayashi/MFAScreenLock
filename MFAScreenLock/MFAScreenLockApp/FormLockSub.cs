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
        public FormLockSub()
        {
            InitializeComponent();
        }

        public void setBackgroundImage(Bitmap wallPaperBmp)
        {
            if (wallPaperBmp != null)
            {
                BackgroundImage = ShareClass.autoScaleBitmap(wallPaperBmp, Size);
            }
            BackgroundImageLayout = ShareClass.imageLayout();
        }

        private void FormLockSub_Load(object sender, EventArgs e)
        {
            
        }

        ~FormLockSub()
        {
            Dispose();
        }
    }
}
