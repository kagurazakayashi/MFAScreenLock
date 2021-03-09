using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFAScreenLockApp
{
    public partial class About : Form
    {
        public Bitmap wallPaperBmp;
        private double wallPaperlig = -1;
        private List<string> formLockSubList = new List<string>();
        private string[] github = { "将打开默认浏览器，访问位于 Github 上的仓库页面。是否继续？", "将打开网页", "https://github.com/kagurazakayashi/MFAScreenLock" };
        private bool windowOpen = true;

        public About()
        {
            InitializeComponent();
        }

        private void gColor()
        {
            if (wallPaperlig == -1)
            {
                wallPaperlig = ImageControl.CalculateAverageLightness(wallPaperBmp);
            }
            if (wallPaperlig > 0.5)
            {
                ForeColor = groupBox1.ForeColor = Color.Black;
                BackColor = Color.White;
            }
            else
            {
                ForeColor = groupBox1.ForeColor = Color.White;
                BackColor = Color.Black;
            }
        }

        private void About_Load(object sender, EventArgs e)
        {
            if (wallPaperBmp != null)
            {
                BackgroundImage = ShareClass.autoScaleBitmap(wallPaperBmp, Size);
            }
            gColor();
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lbl_var.Text = string.Format("版本 {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision.ToString("0000"));

            formLockSubList.Add("计算机: " + SystemInformation.ComputerName + " ( " + Environment.MachineName + " )");
            formLockSubList.Add("操作系统: " + Environment.OSVersion.Platform + " ( " + Environment.OSVersion.VersionString + " )");
            string ubit = "32位";
            if (Environment.Is64BitOperatingSystem)
            {
                ubit = "64位";
            }
            formLockSubList.Add("处理器: " + ubit + " x " + Environment.ProcessorCount.ToString());
            formLockSubList.Add("系统内存: " + Environment.SystemPageSize.ToString());
            formLockSubList.Add("启动模式: " + SystemInformation.BootMode.ToString());
            formLockSubList.Add("系统目录: " + Environment.SystemDirectory);
            formLockSubList.Add("主显示器分辨率: " + SystemInformation.PrimaryMonitorSize.Width.ToString() + " x " + SystemInformation.PrimaryMonitorSize.Height.ToString() + " (可用区域 " + SystemInformation.PrimaryMonitorMaximizedWindowSize.Width.ToString() + " x " + SystemInformation.PrimaryMonitorMaximizedWindowSize.Height.ToString() + " )");
            formLockSubList.Add("显示器 ( " + SystemInformation.MonitorCount.ToString() + " ):");
            Screen[] screens = Screen.AllScreens;
            uint screenI = 1;
            foreach (Screen screen in screens)
            {
                Rectangle area = screen.WorkingArea;
                Rectangle bound = screen.Bounds;
                FormLockSub locksub = new FormLockSub();
                string primary = "";
                if (screen.Primary)
                {
                    primary = "(主显示器)";
                }
                formLockSubList.Add("显示器 " + (screenI++).ToString() + " " + primary + ":　位置 " + bound.Top.ToString() + " , " + bound.Left.ToString() + "　区域位置 " + area.Top.ToString() + " , " + area.Left.ToString() + "　分辨率 " + bound.Size.Width.ToString() + " x " + bound.Size.Height.ToString() + "　区域 " + area.Size.Width.ToString() + " x " + area.Size.Height.ToString());
            }
            foreach (string line in formLockSubList)
            {
                lbl_sysinfo.Text += line + Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(github[0], github[1], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(github[2] + "#readme");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(github[0], github[1], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(github[2] + "/blob/master/LICENSE");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(github[0], github[1], MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(github[2]);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                BackgroundImage = null;
            }
            else if (wallPaperBmp != null)
            {
                BackgroundImage = ShareClass.autoScaleBitmap(wallPaperBmp, Size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            aClose();
        }

        public void aClose()
        {
            windowOpen = false;
            windowTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (windowOpen)
            {
                aClose();
                e.Cancel = true;
            }
        }
    }
}
