using MFAScreenLockApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    public partial class FormUser : Form
    {
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
        }

        private bool isbind()
        {
            textBox_ComName.Text = Environment.MachineName;
            textBox_UserName.Text = Environment.UserDomainName + "\\" + Environment.UserName;
            textBox_ComNameB.Text = Settings.Default.MachineName == "" ? "未绑定" : Settings.Default.MachineName;
            textBox_UserNameB.Text = Settings.Default.UserDomainName + "\\" + Settings.Default.UserName;
            if (textBox_UserNameB.Text == "\\") textBox_UserNameB.Text = "未绑定";
            if (Settings.Default.MachineName == "")
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
            FormQR formqr = new FormQR();
            formqr.ShowDialog();
            isbind();
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
            if (!isbind())
            {
                this.ws = 1;
            }
        }
    }
}
