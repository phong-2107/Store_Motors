using BUS;
using DAL.Entities;
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

namespace GUI
{
    public partial class FormColors : Form
    {
        private readonly MauSacService mauSacService = new MauSacService();

        public FormColors()
        {
            InitializeComponent();
        }

        private void BindGrid(List<MauSac> list)
        {
            dgvMauSac.Rows.Clear();
            foreach (var x in list)
            {
                if (x.ACTIVE == true)
                {
                    int index = dgvMauSac.Rows.Add();
                    dgvMauSac.Rows[index].Cells[0].Value = x.IDMAU;
                    dgvMauSac.Rows[index].Cells[1].Value = x.TENMAU;

                }

            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }

        private void FormColors_Load(object sender, EventArgs e)
        {
            BindGrid(mauSacService.GetAll());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Commons.handle != null)
            {
                SplashScreenManager.CloseOverlayForm(Commons.handle);
            }
            this.Close();
        }
    }
}
