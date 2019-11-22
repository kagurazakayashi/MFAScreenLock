using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using Google.Authenticator;
using MFAScreenLockApp.Properties;

namespace MFAScreenLockApp
{
    public partial class FormLock : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体
        public IntPtr Handle1;

        public int ws = 0;
        private TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
        private HotKeyHandler hook = new HotKeyHandler();
        public Bitmap wallPaperbmp = null;

        public FormLock()
        {
            InitializeComponent();
        }

        private void FormLock_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AccountSecretKey == "")
            {
                ws = 1;
                this.Hide();
                return;
            }
            hook.HookStart();
            Handle1 = this.Handle;
            lbl_user.Text = Environment.UserName;
            updatedate();
            if (wallPaperbmp != null)
            {
                double wallPaperlig = CalculateAverageLightness(wallPaperbmp);
                if (wallPaperlig > 0.5)
                {
                    this.ForeColor = Color.Black;
                    userimage.BackgroundImage = Resources.ic_account_circle_black_48dp;
                }
                this.BackgroundImage = wallPaperbmp;
            }
            txt_pwdcode.Focus();
        }

        private void updatedate()
        {
            lbl_time.Text = DateTime.Now.ToString("t");
            lbl_date.Text = DateTime.Now.ToString("D");
        }

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

            //Luminance (standard, objective): (0.2126*R) + (0.7152*G) + (0.0722*B)
            //Luminance (perceived option 1): (0.299*R + 0.587*G + 0.114*B)
            //Luminance (perceived option 2, slower to calculate): sqrt( 0.241*R^2 + 0.691*G^2 + 0.068*B^2 )
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

        private void label5_Click(object sender, EventArgs e)
        {
            softkeyboard.Visible = !softkeyboard.Visible;
        }

        private void softkeyboardbtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txt_pwdcode.Text += button.Text;
            txt_pwdcode.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string pwdcode = txt_pwdcode.Text;
            txt_pwdcode.Text = pwdcode.Substring(0, pwdcode.Length - 1);
            txt_pwdcode.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txt_pwdcode.Text = "";
            txt_pwdcode.Focus();
        }

        private bool pass(string pwd, string key = "")
        {
            if (Settings.Default.AccountSecretKey.Length == 0) return true;
            if (pwd.Length == 0) return false;
            if (Settings.Default.MachineName != Environment.MachineName) return false;
            if (Settings.Default.UserDomainName != Environment.UserDomainName) return false;
            if (Settings.Default.UserName != Environment.UserName) return false;
            if (key.Length == 0) key = Settings.Default.AccountSecretKey;
            return tfa.ValidateTwoFactorPIN(key, pwd);
        }

        private void txt_pwdcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_pwdcode.Text.Length == 6)
            {
                if (pass(txt_pwdcode.Text))
                {
                    ws = 1;
                    this.Hide();
                }
            }
            else if (txt_pwdcode.Text.Length == txt_pwdcode.MaxLength)
            {
                if (txt_pwdcode.Text == Settings.Default.RecoveryCode)
                {
                    ws = 1;
                    this.Hide();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updatedate();
            this.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (Handle1 != GetForegroundWindow())
            {
                SetForegroundWindow(Handle1);
            }
        }

        private void FormLock_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void FormLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ws != 1)
            {
                e.Cancel = true;
            }
            else
            {
                hook.HookStop();
            }
        }
    }
}
