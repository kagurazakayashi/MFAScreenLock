using MFAScreenLockApp.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    public partial class FormUser : Form
    {
        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO Dummy);
        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
        const uint SPI_GETDESKWALLPAPER = 0x0073;
        private FormLock formlock = null;

        public int ws = 0;

        public FormUser()
        {
            InitializeComponent();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            isbind();
            check_loginstart.Checked = Settings.Default.LoginStart;
            int timeouts = Settings.Default.Timeout;
            num_timeout.Value = timeouts / 60;
            prog_timeout.Value = 0;
            prog_timeout.Maximum = timeouts * 1000;
            check_timeoutenable.Checked = Settings.Default.TimeoutEnable;
        }

        private bool isbind()
        {
            textBox_ComName.Text = Environment.MachineName;
            textBox_UserName.Text = Environment.UserDomainName + "\\" + Environment.UserName;
            textBox_ComNameB.Text = Settings.Default.MachineName.Length == 0 ? "未绑定" : Settings.Default.MachineName;
            textBox_UserNameB.Text = Settings.Default.UserDomainName + "\\" + Settings.Default.UserName;
            if (textBox_UserNameB.Text == "\\") textBox_UserNameB.Text = "未绑定";
            if (Settings.Default.MachineName.Length == 0)
            {
                btn_bind.Enabled = true;
                btn_bind.Visible = true;
                btn_unbind.Enabled = false;
                btn_unbind.Visible = false;
                return false;
            }
            else
            {
                btn_bind.Enabled = false;
                btn_bind.Visible = false;
                btn_unbind.Enabled = true;
                btn_unbind.Visible = true;
                return true;
            }
        }

        private void btn_bind_Click(object sender, EventArgs e)
        {
            btn_bind.Enabled = false;
            FormQR formqr = new FormQR();
            formqr.ShowDialog();
            isbind();
            btn_bind.Enabled = true;
        }

        private void Restart()
        {
            Process ps = new Process();
            ps.StartInfo.FileName = Application.ExecutablePath.ToString();
            ps.Start();
            Application.Exit();
        }

        private void btn_unbind_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要解绑验证器吗？", "解绑验证器", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Settings.Default.Reset();
                loaddata();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formlock != null)
            {
                formlock.fClose();
            }
            Settings.Default.Save();
            if (!isbind())
            {
                this.ws = 1;
            }
        }

        private void autoStart(bool isAuto)
        {
            try
            {
                if (isAuto == true)
                {
                    //RegistryKey R_local = Registry.LocalMachine;
                    RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue("MFAScreenLock", Application.ExecutablePath);
                    R_run.Close();
                    R_local.Close();
                }
                else
                {
                    //RegistryKey R_local = Registry.LocalMachine;
                    RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue("MFAScreenLock", false);
                    R_run.Close();
                    R_local.Close();
                }
                Settings.Default.LoginStart = check_loginstart.Checked;
            }
            catch (Exception)
            {
                MessageBox.Show("请将本程序退出，然后右键选择「以管理员方式运行」，再修改此设置。", "访问被拒绝",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        private static uint GetIdleTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)Marshal.SizeOf(LastUserAction);
            GetLastInputInfo(ref LastUserAction);
            return ((uint)Environment.TickCount - LastUserAction.dwTime);
        }

        private static long GetTickCount()
        {
            return Environment.TickCount;
        }

        private static long GetLastInputTime()
        {
            LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
            LastUserAction.cbSize = (uint)Marshal.SizeOf(LastUserAction);
            if (!GetLastInputInfo(ref LastUserAction))
            {
                throw new Exception(GetLastError().ToString());
            }

            return LastUserAction.dwTime;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            autoStart(check_loginstart.Checked);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double idles = GetIdleTime();
            lbl_timeout.Text = (idles / 1000.0).ToString();
            if (idles <= prog_timeout.Maximum)
            {
                prog_timeout.Value = (int)idles;
            }
            else
            {
                prog_timeout.Value = prog_timeout.Maximum;
            }
        }

        private void check_timeoutenable_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.TimeoutEnable = check_timeoutenable.Checked;
        }

        private void num_timeout_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.Timeout = (Convert.ToInt32(num_timeout.Value) * 60);
        }

        private void showPreview()
        {
            formlock = new FormLock();
            formlock.Text = "锁屏效果预览";
            formlock.lbl_info.Text = formlock.Text;
            StringBuilder wallPaperPath = new StringBuilder(200);
            if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
            {
                string wallPaper = wallPaperPath.ToString();
                if (wallPaper.Length > 0)
                {
                    formlock.wallPaperBmp = new Bitmap(wallPaper);
                }
            }
            formlock.previewMode = true;
            formlock.FormBorderStyle = FormBorderStyle.Fixed3D;
            formlock.ControlBox = true;
            formlock.TopMost = false;
            TopMost = true;
            formlock.Show();
            this.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                showPreview();
            }
            else
            {
                TopMost = false;
                if (formlock != null)
                {
                    formlock.fClose();
                }
            }
        }
    }
}
