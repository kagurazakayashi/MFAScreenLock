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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUser));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ComName = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_bind = new System.Windows.Forms.Button();
            this.btn_unbind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ComNameB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_UserNameB = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.textBox_ComName.Size = new System.Drawing.Size(271, 26);
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
            this.textBox_UserName.Size = new System.Drawing.Size(271, 26);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 99);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登录信息";
            // 
            // btn_bind
            // 
            this.btn_bind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_bind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_bind.Enabled = false;
            this.btn_bind.Image = global::MFAScreenLockApp.Properties.Resources.ic_blur_on_2x;
            this.btn_bind.Location = new System.Drawing.Point(12, 229);
            this.btn_bind.Name = "btn_bind";
            this.btn_bind.Size = new System.Drawing.Size(197, 72);
            this.btn_bind.TabIndex = 2;
            this.btn_bind.Text = "绑定(&B)";
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
            this.btn_unbind.Location = new System.Drawing.Point(17, 229);
            this.btn_unbind.Name = "btn_unbind";
            this.btn_unbind.Size = new System.Drawing.Size(192, 72);
            this.btn_unbind.TabIndex = 7;
            this.btn_unbind.Text = "解绑(&U)";
            this.btn_unbind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_unbind.UseVisualStyleBackColor = true;
            this.btn_unbind.Visible = false;
            this.btn_unbind.Click += new System.EventHandler(this.btn_unbind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_ComNameB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_UserNameB);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 99);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "绑定信息";
            // 
            // textBox_ComNameB
            // 
            this.textBox_ComNameB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ComNameB.Enabled = false;
            this.textBox_ComNameB.Location = new System.Drawing.Point(134, 25);
            this.textBox_ComNameB.Name = "textBox_ComNameB";
            this.textBox_ComNameB.Size = new System.Drawing.Size(271, 26);
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
            this.textBox_UserNameB.Size = new System.Drawing.Size(271, 26);
            this.textBox_UserNameB.TabIndex = 6;
            this.textBox_UserNameB.Text = "未绑定";
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Image = global::MFAScreenLockApp.Properties.Resources.ic_close_2x;
            this.btn_close.Location = new System.Drawing.Point(226, 229);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(197, 72);
            this.btn_close.TabIndex = 11;
            this.btn_close.Text = "完成(&W)";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // FormUser
            // 
            this.AcceptButton = this.btn_bind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(439, 313);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_bind);
            this.Controls.Add(this.btn_unbind);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户密码管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUser_FormClosing);
            this.Load += new System.EventHandler(this.FormUser_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btn_close;
    }
}