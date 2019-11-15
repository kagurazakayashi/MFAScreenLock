namespace MFAScreenLockApp
{
    partial class FormQR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQR));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.img_qr = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_EntryKey = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_codeisok = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_qr)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.img_qr);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用验证器扫描二维码";
            // 
            // img_qr
            // 
            this.img_qr.BackColor = System.Drawing.Color.White;
            this.img_qr.Location = new System.Drawing.Point(19, 25);
            this.img_qr.Name = "img_qr";
            this.img_qr.Size = new System.Drawing.Size(380, 380);
            this.img_qr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_qr.TabIndex = 0;
            this.img_qr.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_EntryKey);
            this.groupBox2.Location = new System.Drawing.Point(435, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "或手工输入密钥绑定";
            // 
            // lbl_EntryKey
            // 
            this.lbl_EntryKey.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EntryKey.Location = new System.Drawing.Point(6, 22);
            this.lbl_EntryKey.Name = "lbl_EntryKey";
            this.lbl_EntryKey.Size = new System.Drawing.Size(348, 75);
            this.lbl_EntryKey.TabIndex = 0;
            this.lbl_EntryKey.Text = "--";
            this.lbl_EntryKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_codeisok);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txt_code);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(435, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 153);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输入验证器上显示的密码";
            // 
            // lbl_codeisok
            // 
            this.lbl_codeisok.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_codeisok.Location = new System.Drawing.Point(215, 25);
            this.lbl_codeisok.Name = "lbl_codeisok";
            this.lbl_codeisok.Size = new System.Drawing.Size(139, 39);
            this.lbl_codeisok.TabIndex = 6;
            this.lbl_codeisok.Text = "6 位数字";
            this.lbl_codeisok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Image = global::MFAScreenLockApp.Properties.Resources.ic_close_2x;
            this.button2.Location = new System.Drawing.Point(215, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 72);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_code
            // 
            this.txt_code.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.Location = new System.Drawing.Point(12, 25);
            this.txt_code.MaxLength = 6;
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(197, 39);
            this.txt_code.TabIndex = 4;
            this.txt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_code.TextChanged += new System.EventHandler(this.txt_code_TextChanged);
            // 
            // button1
            // 
            this.button1.Image = global::MFAScreenLockApp.Properties.Resources.ic_blur_on_2x;
            this.button1.Location = new System.Drawing.Point(12, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 72);
            this.button1.TabIndex = 3;
            this.button1.Text = "完成绑定";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 124);
            this.label2.TabIndex = 3;
            this.label2.Text = "· 进行绑定后，不要修改用户名、网域和计算机名称，这会导致无法通过验证，无法登录！\r\n· 不要将安装后的文件夹直接拷贝，可能会泄露您的 Key 造成密码风险，同时" +
    "可能将他人电脑直接所动。\r\n· 请设置好本软件的设置文件权限，防止被其他用户访问到本程序的设置文件而泄露 Key 。";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(435, 277);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 149);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "注意事项";
            // 
            // FormQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 441);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "绑定和验证";
            this.Load += new System.EventHandler(this.FormQR_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_qr)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox img_qr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_EntryKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_codeisok;
    }
}