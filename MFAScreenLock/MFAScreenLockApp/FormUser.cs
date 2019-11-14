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
        public FormUser()
        {
            InitializeComponent();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="version">版本 1 ~ 40</param>
        /// <param name="pixel">像素点大小</param>
        /// <param name="icon_path">图标路径</param>
        /// <param name="icon_size">图标尺寸</param>
        /// <param name="icon_border">图标边框厚度</param>
        /// <param name="white_edge">二维码白边</param>
        /// <returns>位图</returns>
        public static Bitmap code(string msg, int version=5, int pixel=7, string icon_path=null, int icon_size=20, int icon_border=5, bool white_edge=true)
        {
            QRCoder.QRCodeGenerator code_generator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData code_data = code_generator.CreateQrCode(msg, QRCoder.QRCodeGenerator.ECCLevel.M/* 这里设置容错率的一个级别 */, true, true, QRCoder.QRCodeGenerator.EciMode.Utf8, version);
            QRCoder.QRCode code = new QRCoder.QRCode(code_data);
            
            Bitmap bmp = null;
            if (icon_path != null)
            {
                Bitmap icon = new Bitmap(icon_path);
                bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, icon_size, icon_border, white_edge);
            }
            else
            {
                bmp = code.GetGraphic(pixel, Color.Black, Color.White, white_edge);
            }
            return bmp;
        }
    }
}
