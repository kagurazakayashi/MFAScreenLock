namespace MFAScreenLockApp
{
    partial class FormUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUser));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ComName = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ComNameB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_UserNameB = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_bind = new System.Windows.Forms.Button();
            this.btn_unbind = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_timeout = new System.Windows.Forms.Label();
            this.prog_timeout = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.num_timeout = new System.Windows.Forms.NumericUpDown();
            this.check_timeoutenable = new System.Windows.Forms.CheckBox();
            this.check_loginstart = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前设备名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前用户：";
            // 
            // textBox_ComName
            // 
            this.textBox_ComName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ComName.Enabled = false;
            this.textBox_ComName.Location = new System.Drawing.Point(134, 25);
            this.textBox_ComName.Name = "textBox_ComName";
            this.textBox_ComName.Size = new System.Drawing.Size(440, 26);
            this.textBox_ComName.TabIndex = 5;
            this.textBox_ComName.Text = "未知";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserName.Enabled = false;
            this.textBox_UserName.Location = new System.Drawing.Point(134, 57);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(440, 26);
            this.textBox_UserName.TabIndex = 6;
            this.textBox_UserName.Text = "未知";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox_ComName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_UserName);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 99);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前系统登录信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_ComNameB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_UserNameB);
            this.groupBox1.Location = new System.Drawing.Point(6, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 99);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已经录的绑定信息";
            // 
            // textBox_ComNameB
            // 
            this.textBox_ComNameB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ComNameB.Enabled = false;
            this.textBox_ComNameB.Location = new System.Drawing.Point(134, 25);
            this.textBox_ComNameB.Name = "textBox_ComNameB";
            this.textBox_ComNameB.Size = new System.Drawing.Size(440, 26);
            this.textBox_ComNameB.TabIndex = 5;
            this.textBox_ComNameB.Text = "未绑定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "已绑定设备：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "已绑定用户：";
            // 
            // textBox_UserNameB
            // 
            this.textBox_UserNameB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserNameB.Enabled = false;
            this.textBox_UserNameB.Location = new System.Drawing.Point(134, 57);
            this.textBox_UserNameB.Name = "textBox_UserNameB";
            this.textBox_UserNameB.Size = new System.Drawing.Size(440, 26);
            this.textBox_UserNameB.TabIndex = 6;
            this.textBox_UserNameB.Text = "未绑定";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 336);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btn_bind);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btn_unbind);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "验证器应用绑定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_bind
            // 
            this.btn_bind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_bind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_bind.Enabled = false;
            this.btn_bind.Image = global::MFAScreenLockApp.Properties.Resources.ic_blur_on_2x;
            this.btn_bind.Location = new System.Drawing.Point(389, 218);
            this.btn_bind.Name = "btn_bind";
            this.btn_bind.Size = new System.Drawing.Size(197, 72);
            this.btn_bind.TabIndex = 2;
            this.btn_bind.Text = "开始进行绑定 (&B)";
            this.btn_bind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_bind.UseVisualStyleBackColor = true;
            this.btn_bind.Visible = false;
            this.btn_bind.Click += new System.EventHandler(this.btn_bind_Click);
            // 
            // btn_unbind
            // 
            this.btn_unbind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_unbind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_unbind.Enabled = false;
            this.btn_unbind.Image = global::MFAScreenLockApp.Properties.Resources.ic_blur_off_2x;
            this.btn_unbind.Location = new System.Drawing.Point(394, 218);
            this.btn_unbind.Name = "btn_unbind";
            this.btn_unbind.Size = new System.Drawing.Size(192, 72);
            this.btn_unbind.TabIndex = 7;
            this.btn_unbind.Text = "解除绑定 (&U)";
            this.btn_unbind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_unbind.UseVisualStyleBackColor = true;
            this.btn_unbind.Visible = false;
            this.btn_unbind.Click += new System.EventHandler(this.btn_unbind_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.check_loginstart);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "自动锁定设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lbl_timeout);
            this.groupBox3.Controls.Add(this.prog_timeout);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.num_timeout);
            this.groupBox3.Controls.Add(this.check_timeoutenable);
            this.groupBox3.Location = new System.Drawing.Point(6, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 154);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "不活动时锁定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "秒";
            // 
            // lbl_timeout
            // 
            this.lbl_timeout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_timeout.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeout.Location = new System.Drawing.Point(86, 68);
            this.lbl_timeout.Name = "lbl_timeout";
            this.lbl_timeout.Size = new System.Drawing.Size(111, 20);
            this.lbl_timeout.TabIndex = 9;
            this.lbl_timeout.Text = "0";
            this.lbl_timeout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // prog_timeout
            // 
            this.prog_timeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prog_timeout.Location = new System.Drawing.Point(19, 107);
            this.prog_timeout.Maximum = 60000;
            this.prog_timeout.Name = "prog_timeout";
            this.prog_timeout.Size = new System.Drawing.Size(542, 23);
            this.prog_timeout.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prog_timeout.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "已空闲：";
            // 
            // num_timeout
            // 
            this.num_timeout.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_timeout.Location = new System.Drawing.Point(75, 30);
            this.num_timeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_timeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_timeout.Name = "num_timeout";
            this.num_timeout.Size = new System.Drawing.Size(44, 24);
            this.num_timeout.TabIndex = 1;
            this.num_timeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_timeout.ValueChanged += new System.EventHandler(this.num_timeout_ValueChanged);
            // 
            // check_timeoutenable
            // 
            this.check_timeoutenable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.check_timeoutenable.Location = new System.Drawing.Point(20, 31);
            this.check_timeoutenable.Name = "check_timeoutenable";
            this.check_timeoutenable.Size = new System.Drawing.Size(554, 25);
            this.check_timeoutenable.TabIndex = 2;
            this.check_timeoutenable.Text = "空闲　　　　分钟后自动锁定 (&A)";
            this.check_timeoutenable.UseVisualStyleBackColor = true;
            this.check_timeoutenable.CheckedChanged += new System.EventHandler(this.check_timeoutenable_CheckedChanged);
            // 
            // check_loginstart
            // 
            this.check_loginstart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.check_loginstart.Location = new System.Drawing.Point(16, 18);
            this.check_loginstart.Name = "check_loginstart";
            this.check_loginstart.Size = new System.Drawing.Size(570, 24);
            this.check_loginstart.TabIndex = 0;
            this.check_loginstart.Text = "跟随 Windows 登录进行锁定（只对当前用户生效）（&L)";
            this.check_loginstart.UseVisualStyleBackColor = true;
            this.check_loginstart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormUser
            // 
            this.AcceptButton = this.btn_bind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 360);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MFAScreenLockApp - 配置 - 自动锁定计时器已暂停";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUser_FormClosing);
            this.Load += new System.EventHandler(this.FormUser_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_timeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_bind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ComName;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Button btn_unbind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_ComNameB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_UserNameB;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox check_loginstart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar prog_timeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_timeout;
        private System.Windows.Forms.CheckBox check_timeoutenable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_timeout;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.TabControl tabControl1;
    }
}