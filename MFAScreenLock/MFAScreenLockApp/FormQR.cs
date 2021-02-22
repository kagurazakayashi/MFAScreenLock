using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.Authenticator;
using MFAScreenLockApp.Properties;
using QRCodeEncoderLibrary;


namespace MFAScreenLockApp
{
    public partial class FormQR : Form
    {
        private string secretKey = "";
        private TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
        private bool isinit = false;

        public FormQR()
        {
            InitializeComponent();
        }

        private void FormQR_Load(object sender, EventArgs e)
        {
        }

        private Bitmap qrcode(string url)
        {
            QREncoder Encoder = new QREncoder();
            Encoder.ErrorCorrection = ErrorCorrection.Q;
            Encoder.ModuleSize = 4;
            Encoder.QuietZone = 16;
            Encoder.Encode(url);
            Bitmap bitmap = Encoder.CreateQRCodeBitmap();
            return bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tfa.ValidateTwoFactorPIN(secretKey, txt_code.Text))
            {
                string recoveryCode = GenerateRandom(30);
                DialogResult result = MessageBox.Show("以下是您的恢复代码，如果手机遗失或故障，可以用此代码进行恢复。\n请妥善保存此代码，在无法输入动态密码时将可以用此代码解锁。\n\n" + recoveryCode + "\n\n「是」：创建此代码并复制到剪贴板，可以用此代码进行恢复。\n「否」：我不需要此代码，一旦卸载APP或设备丢失将无法解锁", "恢复代码", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Clipboard.SetDataObject(recoveryCode);
                }
                if (result != DialogResult.Cancel)
                {
                    Settings.Default.MachineName = Environment.MachineName;
                    Settings.Default.UserDomainName = Environment.UserDomainName;
                    Settings.Default.UserName = Environment.UserName;
                    Settings.Default.AccountSecretKey = secretKey;
                    Settings.Default.Date = DateTime.Now;
                    Settings.Default.RecoveryCode = recoveryCode;
                    Settings.Default.Save();
                }
                secretKey = "";
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("输入的动态密码不匹配。\n「重试」：重新输入一次\n「取消」：退回到上一画面，重头开始\n", "校验失败", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    secretKey = "";
                    this.Hide();
                }
            }
        }

        private string GenerateRandom(int Length)
        {
            char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            StringBuilder newRandom = new StringBuilder(constant.Length);
            Random rd = new Random();
            int unit = 0;
            for (int i = 0; i < Length; i++)
            {
                unit++;
                System.Threading.Thread.Sleep(10);
                newRandom.Append(constant[rd.Next(constant.Length)]);
                if (unit > 4 && i < Length - 1)
                {
                    newRandom.Append('-');
                    unit = 0;
                }
            }
            return newRandom.ToString();
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            if (txt_code.Text.Length == 6) {
                if (tfa.ValidateTwoFactorPIN(secretKey, txt_code.Text))
                {
                    lbl_codeisok.Text = "正确！";
                }
                else
                {
                    lbl_codeisok.Text = "不正确";
                }
            }
            else
            {
                lbl_codeisok.Text = "6 位数字";
            }
        }

        private string numLen2(int num)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            if (num < 10)
            {
                return "0" + Convert.ToString(num, nfi);
            }
            return Convert.ToString(num, nfi);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isinit)
            {
                string totpSecretKey = Guid.NewGuid().ToString("N").Substring(0, 10);
                var tfa = new TwoFactorAuthenticator();
                string computername = Environment.MachineName;
                string username = Environment.UserName;
                var setupInfo = tfa.GenerateSetupCode(username, computername, totpSecretKey, false, 380);
                string otpauth = "otpauth://totp/" + Environment.UserDomainName + ":" + setupInfo.Account + "?secret=" + setupInfo.ManualEntryKey + "&issuer=" + computername;
                lbl_EntryKey.Text = setupInfo.ManualEntryKey;
                secretKey = totpSecretKey;
                img_qr.Image = qrcode(otpauth);
                img_qr.Visible = true;
                txt_code.Enabled = true;
                button1.Enabled = true;
                isinit = true;
                UseWaitCursor = false;
            }
            DateTime now = DateTime.Now;
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(now).Hours;
            string sign = "";
            if (offset > 0)
            {
                sign = "+";
            }
            string zone = "GMT" + sign + offset;
            string date = now.Year + " 年 " + numLen2(now.Month) + " 月 " + numLen2(now.Day) + " 日 ";
            string time = numLen2(now.Hour) + " 时 " + numLen2(now.Minute) + " 分 " + numLen2(now.Second) + " 秒 ";
            lbl_info.Text = "日期：" + date + "\n时间：" + time + "\n时区：" + zone + " 区";
        }
    }
}
