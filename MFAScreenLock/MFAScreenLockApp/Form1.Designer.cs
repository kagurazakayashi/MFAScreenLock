namespace MFAScreenLockApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.立即锁定LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.账户管理UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.帮助和关于HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_lock = new System.Windows.Forms.Timer(this.components);
            this.版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.雅诗MFA动态密码锁定器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Yashi MFA Screen Lock";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.雅诗MFA动态密码锁定器ToolStripMenuItem,
            this.版本ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.立即锁定LToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.账户管理UToolStripMenuItem,
            this.toolStripMenuItem1,
            this.帮助和关于HToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 198);
            // 
            // 立即锁定LToolStripMenuItem
            // 
            this.立即锁定LToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_lock_2x;
            this.立即锁定LToolStripMenuItem.Name = "立即锁定LToolStripMenuItem";
            this.立即锁定LToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.立即锁定LToolStripMenuItem.Text = "立即锁定 (&L)";
            this.立即锁定LToolStripMenuItem.Click += new System.EventHandler(this.立即锁定LToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::MFAScreenLockApp.Properties.Resources.ic_perm_identity_2x;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItem2.Text = "验证器应用绑定 (&U)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 账户管理UToolStripMenuItem
            // 
            this.账户管理UToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_settings_2x;
            this.账户管理UToolStripMenuItem.Name = "账户管理UToolStripMenuItem";
            this.账户管理UToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.账户管理UToolStripMenuItem.Text = "自动锁定设置 (&A)";
            this.账户管理UToolStripMenuItem.Click += new System.EventHandler(this.账户管理UToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 6);
            // 
            // 帮助和关于HToolStripMenuItem
            // 
            this.帮助和关于HToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_blur_on_2x;
            this.帮助和关于HToolStripMenuItem.Name = "帮助和关于HToolStripMenuItem";
            this.帮助和关于HToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.帮助和关于HToolStripMenuItem.Text = "帮助和关于 (&H)";
            this.帮助和关于HToolStripMenuItem.Click += new System.EventHandler(this.帮助和关于HToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_close_2x;
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.退出EToolStripMenuItem.Text = "退出 (&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // timer_lock
            // 
            this.timer_lock.Interval = 1000;
            this.timer_lock.Tick += new System.EventHandler(this.timer_lock_Tick);
            // 
            // 版本ToolStripMenuItem
            // 
            this.版本ToolStripMenuItem.Enabled = false;
            this.版本ToolStripMenuItem.Name = "版本ToolStripMenuItem";
            this.版本ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.版本ToolStripMenuItem.Text = "版本：";
            // 
            // 雅诗MFA动态密码锁定器ToolStripMenuItem
            // 
            this.雅诗MFA动态密码锁定器ToolStripMenuItem.Enabled = false;
            this.雅诗MFA动态密码锁定器ToolStripMenuItem.Name = "雅诗MFA动态密码锁定器ToolStripMenuItem";
            this.雅诗MFA动态密码锁定器ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.雅诗MFA动态密码锁定器ToolStripMenuItem.Text = "雅诗MFA动态密码锁定器";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(207, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 89);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Yashi MFA Screen Lock";
            this.UseWaitCursor = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 立即锁定LToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账户管理UToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.Timer timer_lock;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 帮助和关于HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 雅诗MFA动态密码锁定器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}

