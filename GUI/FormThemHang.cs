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
    public partial class FormThemHang : Form
    {
        public FormThemHang()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(Commons.handle != null)
            {
                SplashScreenManager.CloseOverlayForm(Commons.handle);
            }

            this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel13_Click(object sender, EventArgs e)
        {

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var isNumeric = int.TryParse(txtSL.Text, out _);
                if(isNumeric)
                {
                    btnCT.Visible = true;
                }
                else if(isNumeric == false &&  txtSL.Text != "")
                {
                    MessageBox.Show("Giá trị nhập phải là số");
                    btnCT.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
