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
        #region #KHAI BAO GIA TRI

        #endregion

        #region #MAIN
        public FormThemHang()
        {
            InitializeComponent();
        }
        #endregion

        #region #SU LY LOGIC
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

        private void RangBuoc()
        {
            
        }
        #endregion

        #region #GIAO DIEN
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            
            SplashScreenManager.CloseOverlayForm(Commons.handle);
            
        }
        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var isNumeric = int.TryParse(txtSL.Text, out _);
                if(txtSL.Text == "")
                {
                    txtSL.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                    txtSL.BorderColor = Color.FromArgb(94, 148, 255);
                }
                else if(isNumeric)
                {
                    btnCT.Visible = true;
                    txtError.Visible = false;
                    txtSL.FocusedState.BorderColor = Color.Green;
                    txtSL.BorderColor = Color.Green;
                }
                else if(isNumeric == false &&  txtSL.Text != "")
                {
                    txtError.Visible = true;
                    txtError.Text = "Giá trị nhập phải là số";
                    txtSL.Text = "";
                    txtSL.Focus();
                    txtSL.FocusedState.BorderColor = Color.Red;
                    txtSL.BorderColor = Color.Red;
                    btnCT.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnCT_Click(object sender, EventArgs e)
        {
            try
            {
                common2.handle = ShowProgressPanel(this, options);
                FormThemChiTietXe ThemCT = new FormThemChiTietXe();
                ThemCT.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
