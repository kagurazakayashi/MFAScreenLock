﻿using MFAScreenLockApp.Properties;
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
        private FormLock formlock = null;
        private Font[] fontSet = new Font[6];

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
                Settings.Default.AccountSecretKey = "";
                Settings.Default.MachineName = "";
                Settings.Default.UserDomainName = "";
                Settings.Default.UserName = "";
                Settings.Default.Date = new DateTime();
                Settings.Default.RecoveryCode = "";
                Settings.Default.TimeoutEnable = false;
                Settings.Default.LoginStart = false;
                autoStart(false);
                Settings.Default.Save();
                Restart();
            }
        }

        private void btn_rmsetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("将会解绑验证器并删除所有设置！确定要这样做吗？", "恢复出厂设置", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                autoStart(false);
                Settings.Default.Reset();
                Restart();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            autoStart(check_loginstart.Checked);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double idles = SysLink.GetIdleTime();
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
            formlock.wallPaperBmp = ShareClass.gWallPaperBmp();
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
                loadFonts();
            }
            else
            {
                if (combo_font.Items.Count > 0)
                {
                    combo_font.Items.Clear();
                }
                TopMost = false;
                if (formlock != null)
                {
                    formlock.fClose();
                }
            }
        }

        private void loadFonts()
        {
            if (combo_font.Items.Count > 0)
            {
                combo_font.Items.Clear();
            }
            combo_font.Items.Add("时间字体：" + formlock.lbl_time.Font.ToString());
            combo_font.Items.Add("日期字体：" + formlock.lbl_date.Font.ToString());
            combo_font.Items.Add("用户名字体：" + formlock.lbl_user.Font.ToString());
            combo_font.Items.Add("提示信息字体：" + formlock.lbl_info.Font.ToString());
            combo_font.Items.Add("密码输入框字体：" + formlock.txt_pwdcode.Font.ToString());
            combo_font.Items.Add("其他字体：" + formlock.Font.ToString());
        }

        private void btn_font_Click(object sender, EventArgs e)
        {
            // combo_font
            fontDialog1.ShowDialog();

            if (Settings.Default.FontTime != null)
            {
                formlock.lbl_time.Font.ToString();
            }
            if (Settings.Default.FontDate != null)
            {
                formlock.lbl_date.Font.ToString();
            }
            if (Settings.Default.FontUser != null)
            {
                formlock.lbl_user.Font.ToString();
            }
            if (Settings.Default.FontMenu != null)
            {
                formlock.Font.ToString();
            }
            if (Settings.Default.FontInfo != null)
            {
                formlock.lbl_info.Font.ToString();
            }
            if (Settings.Default.FontInput != null)
            {
                formlock.txt_pwdcode.Font.ToString();
            }
        }
    }
}
