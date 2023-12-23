﻿using DAL.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraBars.Docking2010.Views.BaseRegistrator;

namespace GUI
{
    public partial class FormBanHang : DevExpress.XtraEditors.XtraForm
    {
        public FormBanHang()
        {
            InitializeComponent();
        }


        private NhanVien dn = new NhanVien();
        public NhanVien Dn { get => dn; set => dn = value; }


        OverlayWindowOptions options = new OverlayWindowOptions(
            backColor: Color.Black,
            opacity: 0.5,
            fadeIn: false,
            fadeOut: false
        );

        IOverlaySplashScreenHandle ShowProgressPanel(Control control, OverlayWindowOptions options)
        {
            return SplashScreenManager.ShowOverlayForm(control, options);
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu.Show(btnMenu, btnMenu.Location.X - 210, btnMenu.Height);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.handle = ShowProgressPanel(this, options);
                FormThemKhachHang ThemHang = new FormThemKhachHang();
                ThemHang.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }/*
        private void Create_FormClosed(object sender, FormClosedEventArgs e)
        {
            create = null;
            Xe = XuatIDXe();
            showInforMotor(Xe);
        }*/
        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Đăng xuất", "Bạn có muốn đăng xuất?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Hide();
                    FormDangNhap home = new FormDangNhap();
                    home.Closed += (s, args) => this.Close();
                    home.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormHome home = new FormHome();
                home.Dn = Dn;
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}