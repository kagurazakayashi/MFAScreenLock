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
using System.IO;

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
        private Bitmap wallPaperBmp;
        private double wallPaperlig = -1;
        public bool previewMode = false;
        private int pwdEnableTime = 0;
        private int pwdEnableNow = 0;
        public bool debugMode = false;
        private bool windowOpen = true;

        public FormLock()
        {
            InitializeComponent();
            btn_enter.Width = txt_pwdcode.Height;
            btn_enter.Height = txt_pwdcode.Height;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

        public void setBackgroundImage(Bitmap newWallPaperBmp)
        {
            if (newWallPaperBmp != null)
            {
                Size toSize = SystemInformation.PrimaryMonitorSize;
                BackgroundImage = ShareClass.autoScaleBitmap(newWallPaperBmp, toSize);
            }
            BackgroundImageLayout = ShareClass.imageLayout();
        }

        private void FormLock_Load(object sender, EventArgs e)
        {
            if (!previewMode && Settings.Default.AccountSecretKey == "")
            {
                ws = 1;
                aClose();
                return;
            }
            loadFonts();
            hook.HookStart();
            Handle1 = this.Handle;
            lbl_user.Text = Environment.UserName;
            updatedate();
            txt_pwdcode.Focus();
        }

        private void updatedate()
        {
            DateTime now = DateTime.Now;
            lbl_time.Text = now.Hour.ToString().PadLeft(2, '0') + ":" + now.Minute.ToString().PadLeft(2, '0') + ":" + now.Second.ToString().PadLeft(2, '0');
            lbl_date.Text = now.Year.ToString() + " 年 " + now.Month.ToString() + " 月 " + now.Day.ToString() + " 日 ";
        }

        public void stopTimer()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
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
            if (pwdcode.Length > 0)
            {
                txt_pwdcode.Text = pwdcode.Substring(0, pwdcode.Length - 1);
            }
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

        public void fClose()
        {
            ws = 1;
            Close();
        }

        private void enter()
        {
            if (debugMode)
            {
                ws = 1;
                aClose();
            }
            if (previewMode)
            {
                return;
            }
            if (txt_pwdcode.Text.Length == 6)
            {
                if (pass(txt_pwdcode.Text))
                {
                    ws = 1;
                    aClose();
                }
            }
            else if (txt_pwdcode.Text.Length == txt_pwdcode.MaxLength)
            {
                if (txt_pwdcode.Text == Settings.Default.RecoveryCode)
                {
                    ws = 1;
                    aClose();
                }
            }
            if (ws != 1)
            {
                passwordError();
            }
        }

        private void txt_pwdcode_TextChanged(object sender, EventArgs e)
        {
            //enter();
        }

        private Color gColor()
        {
            if (wallPaperlig == -1)
            {
                wallPaperlig = ImageControl.CalculateAverageLightness(wallPaperBmp);
            }
            if (wallPaperlig > 0.5)
            {
                return Color.Black;
            }
            return Color.White;
        }
        public void loadFonts()
        {
            if (Settings.Default.FontTime != null)
            {
                lbl_time.Font = Settings.Default.FontTime;
            }
            if (Settings.Default.FontDate != null)
            {
                lbl_date.Font = Settings.Default.FontDate;
            }
            if (Settings.Default.FontUser != null)
            {
                lbl_user.Font = Settings.Default.FontUser;
            }
            if (Settings.Default.FontMenu != null)
            {
                Font = Settings.Default.FontMenu;
            }
            if (Settings.Default.FontInfo != null)
            {
                lbl_info.Font = Settings.Default.FontInfo;
            }
            if (Settings.Default.FontInput != null)
            {
                txt_pwdcode.Font = Settings.Default.FontInput;
            }

            bool nc = !Settings.Default.ColorAuto;
            if (nc && Settings.Default.ColorTime != null)
            {
                lbl_time.ForeColor = Settings.Default.ColorTime;
            }
            else
            {
                lbl_time.ForeColor = gColor();
            }
            if (nc && Settings.Default.ColorDate != null)
            {
                lbl_date.ForeColor = Settings.Default.ColorDate;
            }
            else
            {
                lbl_date.ForeColor = gColor();
            }
            if (nc && Settings.Default.ColorUser != null)
            {
                lbl_user.ForeColor = Settings.Default.ColorUser;
            }
            else
            {
                lbl_user.ForeColor = gColor();
            }
            if (nc && Settings.Default.ColorInfo != null)
            {
                lbl_info.ForeColor = Settings.Default.ColorInfo;
                btn_enter.ForeColor = Settings.Default.ColorInfo;
            }
            else
            {
                lbl_info.ForeColor = gColor();
                btn_enter.ForeColor = lbl_info.ForeColor;
            }
            //if (nc && Settings.Default.ColorInput != null)
            //{
            //    txt_pwdcode.ForeColor = Settings.Default.ColorInput;
            //}
            //else
            //{
            //    txt_pwdcode.ForeColor = gColor();
            //}
            if (nc && Settings.Default.ColorMenu != null)
            {
                ForeColor = Settings.Default.ColorMenu;
            }
            else
            {
                ForeColor = gColor();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updatedate();
            if (previewMode) return;
            this.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (previewMode) return;
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
            Dispose();
        }

        private void txt_pwdcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                enter();
            }
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            enter();
        }

        private void passwordError()
        {
            txt_pwdcode.Font = new Font(this.Font.FontFamily, 20);
            txt_pwdcode.UseSystemPasswordChar = false;
            txt_pwdcode.Text = "密码不正确";
            txt_pwdcode.BackColor = Color.Tomato;
            txt_pwdcode.ForeColor = Color.Black;
            btn_enter.Text = "";
            txt_pwdcode.Enabled = btn_enter.Enabled = label5.Enabled = softkeyboard.Visible = false;
            pwdEnableTime = Settings.Default.ErrLock;
            pwdEnableNow = Settings.Default.ErrLock;
            timer_err.Enabled = true;
        }

        private void timer_err_Tick(object sender, EventArgs e)
        {
            pwdEnableNow--;
            if (pwdEnableNow < 0)
            {
                txt_pwdcode.Font = new Font("Consolas", 20);
                txt_pwdcode.UseSystemPasswordChar = true;
                txt_pwdcode.Text = "";
                txt_pwdcode.BackColor = SystemColors.Window;
                txt_pwdcode.ForeColor = SystemColors.WindowText;
                txt_pwdcode.Enabled = btn_enter.Enabled = label5.Enabled = true;
                btn_enter.Text = "→";
                timer_err.Enabled = false;
                pwdEnableNow = 0;
                txt_pwdcode.Focus();
            }
            else
            {
                txt_pwdcode.Text = "密码不正确 (" + pwdEnableNow.ToString() + ")";
            }
        }

        private void txt_pwdcode_SizeChanged(object sender, EventArgs e)
        {
            btn_enter.Width = txt_pwdcode.Height;
            btn_enter.Height = txt_pwdcode.Height;
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

        private void aClose()
        {
            txt_pwdcode.Enabled = btn_enter.Enabled = false;
            windowOpen = false;
            windowTimer.Enabled = true;
        }
    }
}
