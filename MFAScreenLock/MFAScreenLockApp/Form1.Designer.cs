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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.立即锁定LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账户管理UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.立即锁定LToolStripMenuItem,
            this.账户管理UToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出EToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 6);
            // 
            // 立即锁定LToolStripMenuItem
            // 
            this.立即锁定LToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_lock_2x;
            this.立即锁定LToolStripMenuItem.Name = "立即锁定LToolStripMenuItem";
            this.立即锁定LToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.立即锁定LToolStripMenuItem.Text = "立即锁定(&L)";
            // 
            // 账户管理UToolStripMenuItem
            // 
            this.账户管理UToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_perm_identity_2x;
            this.账户管理UToolStripMenuItem.Name = "账户管理UToolStripMenuItem";
            this.账户管理UToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.账户管理UToolStripMenuItem.Text = "账户管理(&U)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Image = global::MFAScreenLockApp.Properties.Resources.ic_close_2x;
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 120);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Yashi MFA Screen Lock";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

