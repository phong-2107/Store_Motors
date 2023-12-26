using DAL.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormHome : DevExpress.XtraEditors.XtraForm
    {
        #region KHAI BAO GIA TRI

        private Form activeForm = null;
        Button currentButton = new Button();
        GunaContextMenuStrip MenuTrip = new GunaContextMenuStrip();
        private Panel botttomBorder;

        private NhanVien dn = new NhanVien();
        public NhanVien Dn { get => dn; set => dn = value; }

        OverlayWindowOptions options = new OverlayWindowOptions(
            backColor: Color.Black,
            opacity: 0.5,
            fadeIn: false,
            fadeOut: false
        );
        #endregion

        #region MAIN

        public FormHome()
        {
            InitializeComponent();
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            btnAccount.Text = Dn.TENNV.ToString();
            pnaccount.Width = 230;
            if (Dn.ANHNV.Length != 0)
            {
                ShowAvatar(Dn.ANHNV);
            }
            FormTongQuan demo = new FormTongQuan();
            openChildForm(demo);
        }

        #endregion

        #region SU LY LOGIC

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowAvatar(string ImageName)
        {
            try
            {
                if (string.IsNullOrEmpty(ImageName))
                {
                    btnAccount.Image = null;
                }
                else
                {
                    string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "Images", ImageName);
                    btnAccount.Image = Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        IOverlaySplashScreenHandle ShowProgressPanel(Control control, OverlayWindowOptions options)
        {
            return SplashScreenManager.ShowOverlayForm(control, options);
        }

        #endregion

        #region GIAO DIEN
        // Button Tài khoản
        private void btnAccount_Click(object sender, EventArgs e)
        {
            account.Show(btnAccount, 10, btnAccount.Height + 3);
        }

        // Button Cài đặt
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Settings.Show(btnCaiDat, btnCaiDat.Location.X - 200, btnCaiDat.Height + 3);
        }
        private void btnSanPhamItems_Click(object sender, EventArgs e)
        {
            openChildForm(new FormSanPham());
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Đăng xuất","Bạn có muốn đăng xuất?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            FormTongQuan demo = new FormTongQuan();
            openChildForm(demo);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormSanPham demo = new FormSanPham();
            openChildForm(demo);
        }
        private void FormBanHang_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormBanHang home = new FormBanHang();
                home.Dn = Dn;
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAccountItem_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.handle = ShowProgressPanel(this, options);
                FormAccount account = new FormAccount();
                account.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnColors_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.handle = ShowProgressPanel(this, options);
                FormColors color = new FormColors();
                color.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPhuTung_Click(object sender, EventArgs e)
        {

        }
    }
}