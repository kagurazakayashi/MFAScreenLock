using MFAScreenLockApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
        const uint SPI_GETDESKWALLPAPER = 0x0073;

        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO Dummy);
        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();
        private Bitmap wallPaperBmp;
        private List<FormLockSub> formLockSubList = new List<FormLockSub>();
        private string[] args;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                Hide();
            }));
            版本ToolStripMenuItem.Text = "版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string programname = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName(programname);//获取指定的进程名   
            Thread.Sleep(500);
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已经启动，请查看任务栏中的图标。\n在图标上点击右键可以打开菜单。\n如果不需要验证后驻留后台，请添加 -e 参数。","程序已在运行",MessageBoxButtons.OK,MessageBoxIcon.Error);
                notifyIcon1.Visible = false;
                Application.Exit();
            }
            getwallPaper();
            args = Environment.GetCommandLineArgs();
            loadConfig();
            if (Settings.Default.Timeout >= 60)
            {
                timer_lock.Enabled = true;
            }
        }

        private void loadConfig()
        {
            if (args.Length > 2 && args[1] == "-r" && args[2] == Settings.Default.RecoveryCode)
            {
                DialogResult result = MessageBox.Show("你使用了一个有效的恢复代码。\n你要清除本程序绑定的验证器吗？\n清除后，本程序将立即清除所有设置并退出。", "恢复模式", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Settings.Default.Reset();
                }
                notifyIcon1.Visible = false;
                Application.Exit();
            }
            if (Settings.Default.MachineName == "")
            {
                timer_lock.Enabled = false;
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
                        Close();
                    }));
                }
                formuser.ws = 0;
                timer_lock.Enabled = true;
            }
            else
            {
                locknow();
            }
        }

        private void locknow()
        {
            timer_lock.Enabled = false;
            lockallscreen(true, wallPaperBmp);
            FormLock formlock = new FormLock();
            formlock.wallPaperBmp = wallPaperBmp;
            formlock.ShowDialog();
            formlock.ws = 0;
            lockallscreen(false, wallPaperBmp);
            if (args.Length > 1 && args[1] == "-e")
            {
                notifyIcon1.Visible = false;
                Application.Exit();
            }
            else
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            timer_lock.Enabled = true;
        }

        private void getwallPaper()
        {
            StringBuilder wallPaperPath = new StringBuilder(200);
            if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
            {
                string wallPaper = wallPaperPath.ToString();
                if (wallPaper.Length > 0)
                {
                    wallPaperBmp = new Bitmap(wallPaper);
                }
            }
        }

        private void lockallscreen(bool islock = true, Bitmap wallPaperBmp = null)
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
                    locksub.wallPaperBmp = wallPaperBmp;
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
            openconfig(1);
        }

        private void openconfig(Int16 tabindex = 0)
        {
            if (Settings.Default.MachineName == "")
            {
                timer_lock.Enabled = false;
                FormUser formuser = new FormUser();
                formuser.tabControl1.SelectedIndex = tabindex;
                formuser.ShowDialog();
                formuser.ws = 0;
                timer_lock.Enabled = true;
            }
            else
            {
                lockallscreen(true, wallPaperBmp);
                timer_lock.Enabled = false;
                FormLock formlock = new FormLock();
                formlock.lbl_info.Text = "正在修改绑定设置";
                formlock.wallPaperBmp = wallPaperBmp;
                formlock.ShowDialog();
                lockallscreen(false, wallPaperBmp);
                if (formlock.ws == 1)
                {
                    timer_lock.Enabled = false;
                    FormUser formuser = new FormUser();
                    formuser.tabControl1.SelectedIndex = tabindex;
                    formuser.ShowDialog();
                    formuser.ws = 0;
                }
                timer_lock.Enabled = true;
                formlock.ws = 0;
            }
        }

        private void 立即锁定LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Restart();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lockallscreen(true, wallPaperBmp);
            timer_lock.Enabled = false;
            FormLock formlock = new FormLock();
            formlock.lbl_info.Text = "正在尝试退出软件";
            formlock.wallPaperBmp = wallPaperBmp;
            formlock.ShowDialog();
            lockallscreen(false, wallPaperBmp);
            if (formlock.ws == 1)
            {
                notifyIcon1.Visible = false;
                Application.Exit();
            }
            formlock.ws = 0;
            timer_lock.Enabled = true;
        }

        private void Restart()
        {
            Process ps = new Process();
            ps.StartInfo.FileName = Application.ExecutablePath.ToString();
            ps.Start();
            Application.Exit();
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

        private void timer_lock_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.TimeoutEnable == false)
            {
                timer_lock.Enabled = false;
                return;
            }
            int timeoutcfg = Settings.Default.Timeout;
            if (timeoutcfg >= 60 && GetIdleTime() > Settings.Default.Timeout * 1000.0)
            {
                notifyIcon1.Visible = false;
                Restart();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openconfig(0);
        }

        private void 帮助和关于HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("将打开默认浏览器，访问位于 Github 上的仓库页面。是否继续？", "将打开网页", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://github.com/kagurazakayashi/MFAScreenLock");
            }
        }
    }
}
