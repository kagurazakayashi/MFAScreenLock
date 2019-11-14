using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.Authenticator;

namespace MFAScreenLockApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                this.Hide();
            }));

            /*
            string totpSecretKey = Guid.NewGuid().ToString("N").Substring(0, 10);
            var tfa = new TwoFactorAuthenticator();
            string qrweb = "computer";
            string qruser = "yashi";
            var setupInfo = tfa.GenerateSetupCode(qrweb, qruser, totpSecretKey, 300, 300);
            string otpauth = "otpauth://totp/" + setupInfo.Account + "?secret=" + setupInfo.ManualEntryKey + "&issuer=" + qrweb;
            Console.WriteLine(setupInfo.AccountSecretKey);
            */
        }
    }
}
