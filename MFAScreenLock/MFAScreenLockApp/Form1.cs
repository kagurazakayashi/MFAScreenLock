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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                //this.Hide();
            }));
            loadConfig();
        }

        private void loadConfig()
        {
            //Properties.Settings.Default.Reset();
            //bool one = Properties.Settings.Default.one;
            if (Properties.Settings.Default.MachineName == "")
            {
                FormUser formuser = new FormUser();
                formuser.ShowDialog();
                if (formuser.ws == 1)
                {
                    notifyIcon1.Visible = false;
                    Application.Exit();
                }
                else
                {
                    this.BeginInvoke(new Action(() => {
                        this.Hide();
                    }));
                }
                formuser.ws = 0;
            }
            else
            {
                FormLock formlock = new FormLock();
                formlock.ShowDialog();
                formlock.ws = 0;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("请稍候", new Font(FontFamily.GenericSansSerif, 20), Brushes.Crimson, 30, 30);
        }

        private void 账户管理UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MachineName == "")
            {
                FormUser formuser = new FormUser();
                formuser.ShowDialog();
                formuser.ws = 0;
            }
            else
            {
                FormLock formlock = new FormLock();
                formlock.ShowDialog();
                if (formlock.ws == 1)
                {
                    FormUser formuser = new FormUser();
                    formuser.ShowDialog();
                    formuser.ws = 0;
                }
                formlock.ws = 0;
            }
        }

        private void 立即锁定LToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
