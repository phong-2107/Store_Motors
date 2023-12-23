﻿using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDangNhap : Form
    {
        
        private readonly NhanVienService nhanVienService = new NhanVienService();
        private readonly LoginService loginService = new LoginService();

        public FormDangNhap()
        {
            InitializeComponent();
            
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtID.Focus();
        }
        private void btnQuanli_Click(object sender, EventArgs e)
        {
            try
            {
                checkInput(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int i = 0;
        private void picEyes_Click(object sender, EventArgs e)
        {
            if(txtPass.PasswordChar == '●')
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '●';
            }
        }


        private void btnRecovery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormKhoiPhucPass home = new FormKhoiPhucPass();
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.BorderColor = Color.FromArgb(26, 120, 254);
        }

        private void btnBanhang_Click(object sender, EventArgs e)
        {
            try
            {
                checkInput(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void checkInput(int n)
        {
            var listNhanVien = nhanVienService.GetAll();
            NhanVien nv = new NhanVien();
            Boolean check = false;
            if (txtID.Text != "" && txtPass.Text != "")
            {
                foreach (var item in listNhanVien)
                {
                    if (txtID.Text == item.TaiKhoanLogin.TENTAIKHOAN.Trim() && txtPass.Text == item.TaiKhoanLogin.MATKHAU.Trim())
                    {
                        nv = item;
                        check = true;
                    }
                }

                if (check == true)
                {
                    if(n == 1)
                    {
                        this.Hide();
                        FormHome home = new FormHome();
                        home.Dn = nv;
                        home.Closed += (s, args) => this.Close();
                        home.Show();
                    }
                    else if(n == 0)
                    {
                        this.Hide();
                        FormBanHang home = new FormBanHang();
                        home.Dn = nv;
                        home.Closed += (s, args) => this.Close();
                        home.Show();
                    }
                }
                else
                {
                    //MessageBox.Show("Account or password is incorrect", "Sign in", MessageBoxButtons.OK);
                    pnError.Visible = true;
                    txtError.Text = "Account or password is incorrect";
                    txtID.BorderColor = Color.FromArgb(239, 64, 64);
                    txtPass.BorderColor = Color.FromArgb(239, 64, 64);
                }
            }
            else
            {
                if (txtID.Text == "")
                {
                    pnError.Visible = true;
                    txtError.Text = "You haven't filled in your account";
                    txtID.BorderColor = Color.FromArgb(239, 64, 64);
                }
                    
                else if (txtPass.Text == "")
                {
                    pnError.Visible = true;
                    txtError.Text = "You haven't filled in your Password";
                    txtPass.BorderColor = Color.FromArgb(239, 64, 64);
                }
                txtID.Focus();
            }
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_Click(object sender, EventArgs e)
        {
            txtID.BorderColor = Color.FromArgb(26, 120, 254);
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
                e.Handled = true;
            }
        }
    }
}
