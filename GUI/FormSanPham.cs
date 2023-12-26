using BUS;
using DAL.Entities;
using DevExpress.Charts.Sankey.Native;
using Guna.UI.WinForms;
using DevExpress.XtraSplashForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class FormSanPham : Form
    {
        #region KHAI BÁO GIÁ TRI

        private Form activeForm = null;
        private const bool V = true;
        private readonly MauXeService mauXeService = new MauXeService();
        #endregion

        #region MAIN
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {

            BindGrid(mauXeService.GetAll());
        }
        #endregion

        #region XỬ LÝ LOGIC 

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
        private void BindGrid(List<MauXe> list)
        {
            dgvMotorcycles.Rows.Clear();
            foreach (var x in list)
            {
                if (x.ACTIVE == true)
                {
                    int index = dgvMotorcycles.Rows.Add();
                    dgvMotorcycles.Rows[index].Cells[0].Value = x.IDMAUXE;
                    dgvMotorcycles.Rows[index].Cells[1].Value = x.TENMAUXE;
                    dgvMotorcycles.Rows[index].Cells[2].Value = x.PHANKHOI;
                    dgvMotorcycles.Rows[index].Cells[3].Value = x.LOAICON;
                    dgvMotorcycles.Rows[index].Cells[4].Value = x.SOLUONG;
                    dgvMotorcycles.Rows[index].Cells[5].Value = x.GIANHAP.ToString() + " VND";
                    dgvMotorcycles.Rows[index].Cells[6].Value = x.GIABAN.ToString() + " VND";

                }

            }
        }
        private void Search(string s)
        {
            try
            {
                var listanPham = mauXeService.GetAll();
                var listKHHD = listanPham.Where(p => p.ACTIVE == true).ToList();
                var listSeach = listKHHD.Where(x =>
                                        (x.IDMAUXE.Trim().ToLower().Contains(s))
                                        || (x.TENMAUXE.Trim().ToLower().Contains(s))
                                        ).ToList();
                BindGrid(listSeach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowPanel(Panel pn)
        {
            if (pn.Height >= 220)
            {
                pn.Height = 82;
            }
            else if (pn.Height >= 82)
            {
                pn.Height = 220;
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region GIAO DIEN
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            ThemMoi.Show(btnAddnew, 0, btnAddnew.Height);
        }

        private void btnDFTime_Click(object sender, EventArgs e)
        {
            if (timePickerDf.Visible == true)
            {
                timePickerDf.Visible = false;
            }
            else
            {
                timePickerDf.Visible = true;
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            Import.Show(btImport, 0, btImport.Height);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Find.Show(pnSearch, 0, pnSearch.Height);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            var list = txtSearch.Text.Trim().Split('\0').ToList();
            foreach (var x in list)
            {
                if (x != " ")
                    Search(x);
            }
            //Search(txtSearch.Text.Trim());
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                Commons.handle = ShowProgressPanel(this, options);
                FormThemHang ThemHang = new FormThemHang();
                ThemHang.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        private void btnShowHang_Click(object sender, EventArgs e)
        {
            ShowPanel(pnHangXe);
        }

        private void btnShowTonKho_Click(object sender, EventArgs e)
        {
            ShowPanel(pnTonKho);
        }

        private void btnShowTime_Click(object sender, EventArgs e)
        {
            ShowPanel(pnTime);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormTongQuan demo = new FormTongQuan();
            openChildForm(demo);
        }
    }
}
 