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
        private static extern IntPtr GetForegroundWindow(); //获得本窗体的句柄
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体
        private IntPtr Handle1;

        public int ws = 0;
        private TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
        private HotKeyHandler hook = new HotKeyHandler();
        public Bitmap wallPaperBmp;
        private Image wallPaperImg;
        private double wallPaperlig = -1;

        public FormLock()
        {
            InitializeComponent();
            //tableLayoutPanel2.BackColor = Color.FromArgb(0, tableLayoutPanel2.BackColor);
        }

        private void FormLock_Load(object sender, EventArgs e)
        {
            if (Settings.Default.AccountSecretKey == "")
            {
                ws = 1;
                Close();
                return;
            }
            hook.HookStart();
            Handle1 = this.Handle;
            lbl_user.Text = Environment.UserName;
            updatedate();
            if (wallPaperBmp != null)
            {
                if (wallPaperlig == -1)
                {
                    wallPaperlig = ImageControl.CalculateAverageLightness(wallPaperBmp);
                }
                if (wallPaperlig > 0.5)
                {
                    this.ForeColor = Color.Black;
                    userimage.BackgroundImage = Resources.ic_account_circle_black_48dp;
                }
                wallPaperImg = ImageControl.scaleBitmap(wallPaperBmp, Size.Width, Size.Height);
                BackgroundImage = wallPaperImg;
            }
            txt_pwdcode.Focus();
        }

        private void updatedate()
        {
            DateTime now = DateTime.Now;
            lbl_time.Text = now.Hour.ToString().PadLeft(2, '0') + ":" + now.Minute.ToString().PadLeft(2, '0') + ":" + now.Second.ToString().PadLeft(2, '0');
            lbl_date.Text = now.Year.ToString() + " 年 " + now.Month.ToString() + " 月 " + now.Day.ToString() + " 日 ";
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
                    Close();
                }
            }
            else if (txt_pwdcode.Text.Length == txt_pwdcode.MaxLength)
            {
                if (txt_pwdcode.Text == Settings.Default.RecoveryCode)
                {
                    ws = 1;
                    Close();
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

        ~FormLock()
        {
            if (wallPaperBmp != null) wallPaperBmp.Dispose();
            if (wallPaperImg != null) wallPaperImg.Dispose();
            Dispose();
        }
    }
}
