﻿using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if(pnBaomat.Height <= 80 && pnBaomatLon.Height <= 110)
            {
                pnBaomat.Height = 210;
                pnBaomatLon.Height = 240;
                this.Height = 650;
                btnChinhSua.Text = "Đóng";
                btnChinhSua.Location = new Point(625, 21);
                
                btnLuu.Visible = true;
                btnLuu.Location = new Point(710, 21);
            }
            else if(pnBaomat.Height >= 210 && pnBaomatLon.Height >= 240)
            {
                pnBaomat.Height = 80;
                pnBaomatLon.Height = 110;
                this.Height = 580;
                btnChinhSua.Text = "Chỉnh sửa";
                btnChinhSua.Location = new Point(710, 21);
                btnLuu.Visible = false;
                btnLuu.Location = new Point(625, 21);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Commons.handle != null)
            {
                SplashScreenManager.CloseOverlayForm(Commons.handle);
            }
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
