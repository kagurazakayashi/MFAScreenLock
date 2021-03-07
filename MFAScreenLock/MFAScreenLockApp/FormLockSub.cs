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
        private bool windowOpen = true;

        public FormLockSub()
        {
            InitializeComponent();
        }

        public void setBackgroundImage(Bitmap wallPaperBmp, Size toSize)
        {
            if (wallPaperBmp != null)
            {
                BackgroundImage = ShareClass.autoScaleBitmap(wallPaperBmp, toSize);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void windowTimer_Tick(object sender, EventArgs e)
        {
            if (windowOpen)
            {
                double newOpacity = Opacity + 0.02;
                if (newOpacity >= 1)
                {
                    newOpacity = 1;
                    windowTimer.Enabled = false;
                }
                Opacity = newOpacity;
            }
            else
            {
                double newOpacity = Opacity - 0.02;
                if (newOpacity <= 0)
                {
                    Opacity = 0;
                    windowTimer.Enabled = false;
                    Close();
                }
                else
                {
                    Opacity = newOpacity;
                }
            }
        }
        public void aClose()
        {
            windowOpen = false;
            windowTimer.Enabled = true;
        }
    }
}
