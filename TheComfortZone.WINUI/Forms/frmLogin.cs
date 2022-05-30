using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.WINUI.Properties;
using TheComfortZone.WINUI.Service;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Forms
{
    public partial class frmLogin : Form
    {
        UserAPIService userService = new UserAPIService();
        public frmLogin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            CredentialHelper.Username = txtUsername.Text;
            CredentialHelper.Password = txtPassword.Text;

            Cursor = Cursors.WaitCursor;

            try
            {
                string UserRole = await userService.GetUserRole();
                Settings.Default.LoggedInUserType = UserRole;
                this.Hide();
                MDIParent mdiForm = new MDIParent();
                mdiForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }
    }
}
