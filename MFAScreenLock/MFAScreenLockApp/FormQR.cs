using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.Authenticator;
using QRCodeEncoderLibrary;


namespace MFAScreenLockApp
{
    public partial class FormQR : Form
    {
        private string secretKey = "";
        private TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

        public FormQR()
        {
            InitializeComponent();
        }

        private void FormQR_Load(object sender, EventArgs e)
        {
            string totpSecretKey = Guid.NewGuid().ToString("N").Substring(0, 10);
            var tfa = new TwoFactorAuthenticator();
            string computername = Environment.MachineName;
            string username = Environment.UserName;
            var setupInfo = tfa.GenerateSetupCode(computername, username, totpSecretKey, 380, 380);
            string otpauth = "otpauth://totp/"+ Environment.UserDomainName + ":" + setupInfo.Account + "?secret=" + setupInfo.ManualEntryKey + "&issuer=" + computername;
            //string url = setupInfo.QrCodeSetupImageUrl;
            //string[] urlarr = url.Split('=');
            //url = urlarr[urlarr.Length - 1];
            //url = System.Web.HttpUtility.UrlDecode(url);
            lbl_EntryKey.Text = setupInfo.ManualEntryKey;
            secretKey = setupInfo.AccountSecretKey;
            img_qr.Image = qrcode(otpauth);
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
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tfa.ValidateTwoFactorPIN(secretKey, txt_code.Text))
            {
                Properties.Settings.Default.MachineName = Environment.MachineName;
                Properties.Settings.Default.UserDomainName = Environment.UserDomainName;
                Properties.Settings.Default.UserName = Environment.UserName;
                Properties.Settings.Default.AccountSecretKey = secretKey;
                Properties.Settings.Default.Date = DateTime.Now;
                string recoveryCode = GenerateRandom(30);
                DialogResult result = MessageBox.Show("以下是您的恢复代码，如果手机遗失或故障，可以用此代码进行恢复。\n请妥善保存此代码，在无法输入动态密码时将可以用此代码解锁。\n\n" + recoveryCode + "\n\n「是」：将此代码复制到剪贴板\n「否」：不要复制到剪贴板并继续\n「取消」：我不需要此代码（请多加小心）", "恢复代码", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                bool isok = false;
                if (result == DialogResult.Yes)
                {
                    Clipboard.SetDataObject(recoveryCode);
                    isok = true;
                }
                else if (result == DialogResult.No)
                {
                    isok = true;
                }
                if (isok)
                {
                    Properties.Settings.Default.RecoveryCode = recoveryCode;
                    Properties.Settings.Default.Save();
                }
                secretKey = "";
                this.Hide();
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
    }
}
