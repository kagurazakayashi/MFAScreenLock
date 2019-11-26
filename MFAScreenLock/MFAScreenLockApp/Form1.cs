using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
        const uint SPI_GETDESKWALLPAPER = 0x0073;

        private List<FormLockSub> formLockSubList = new List<FormLockSub>();
        private string[] args;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                this.Hide();
            }));
            string programname = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName(programname);//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已经启动，请查看任务栏中的图标。\n在图标上点击右键可以打开菜单。\n如果不需要验证后驻留后台，请添加 -e 参数。","程序已在运行",MessageBoxButtons.OK,MessageBoxIcon.Error);
                notifyIcon1.Visible = false;
                Application.Exit();
            }
            args = Environment.GetCommandLineArgs();
            loadConfig();
        }

        private void loadConfig()
        {
            if (args.Length > 2 && args[1] == "-r" && args[2] == Properties.Settings.Default.RecoveryCode)
            {
                DialogResult result = MessageBox.Show("你使用了一个有效的恢复代码。\n你要清除本程序绑定的验证器吗？\n清除后，本程序将立即清除所有设置并退出。", "恢复模式", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.Reset();
                }
                notifyIcon1.Visible = false;
                Application.Exit();
            }
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
                    if (args.Length > 1 && args[1] == "-e")
                    {
                        notifyIcon1.Visible = false;
                        Application.Exit();
                    }
                    this.BeginInvoke(new Action(() => {
                        this.Hide();
                    }));
                }
                formuser.ws = 0;
            }
            else
            {
                locknow();
            }
        }

        private void locknow()
        {
            Bitmap wallPaperbmp = getwallPaper();
            lockallscreen(true, wallPaperbmp);
            FormLock formlock = new FormLock();
            formlock.wallPaperbmp = wallPaperbmp;
            formlock.ShowDialog();
            formlock.ws = 0;
            lockallscreen(false, wallPaperbmp);
            if (args.Length > 1 && args[1] == "-e")
            {
                notifyIcon1.Visible = false;
                Application.Exit();
            }
        }

        private Bitmap getwallPaper()
        {
            StringBuilder wallPaperPath = new StringBuilder(200);
            if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
            {
                string wallPaper = wallPaperPath.ToString();
                if (wallPaper.Length > 0)
                {
                    Bitmap wallPaperbmp = new Bitmap(wallPaper);
                    return wallPaperbmp;
                }
            }
            return null;
        }

        private void lockallscreen(bool islock = true, Bitmap wallPaperbmp = null)
        {
            if (islock)
            {
                Screen[] screens = Screen.AllScreens;
                foreach (Screen screen in screens)
                {
                    Rectangle area = screen.WorkingArea;
                    FormLockSub locksub = new FormLockSub();
                    locksub.Top = area.Top;
                    locksub.Left = area.Left;
                    locksub.Show();
                    locksub.WindowState = FormWindowState.Maximized;
                    locksub.BackgroundImage = wallPaperbmp;
                    formLockSubList.Add(locksub);
                }
            }
            else
            {
                foreach (FormLockSub locksub in formLockSubList)
                {
                    locksub.Hide();
                }
                formLockSubList.RemoveAll(it => true);
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
                Bitmap wallPaperbmp = getwallPaper();
                lockallscreen(true, wallPaperbmp);
                FormLock formlock = new FormLock();
                formlock.lbl_info.Text = "正在修改绑定设置";
                formlock.wallPaperbmp = wallPaperbmp;
                formlock.ShowDialog();
                lockallscreen(false, wallPaperbmp);
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
            locknow();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap wallPaperbmp = getwallPaper();
            lockallscreen(true, wallPaperbmp);
            FormLock formlock = new FormLock();
            formlock.lbl_info.Text = "正在尝试退出软件";
            formlock.wallPaperbmp = wallPaperbmp;
            formlock.ShowDialog();
            lockallscreen(false, wallPaperbmp);
            if (formlock.ws == 1)
            {
                notifyIcon1.Visible = false;
                Application.Exit();
            }
            formlock.ws = 0;
        }
    }
}
