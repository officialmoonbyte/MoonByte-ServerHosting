using IndieGoat.MaterialFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoonByte.ClientSoftware.ServerHostingClient.Startup
{
    public partial class RegisterU : MaterialForm
    {

        #region Initialization

        public RegisterU()
        {
            InitializeComponent();
        }

        private void RegisterU_Load(object sender, EventArgs e)
        {
            this.FormClosing += RegisterU_FormClosing;

            txt_ConfirmPassword.Text = "";
            txt_Password.Text = "";
            txt_Email.Text = "";
            txt_Username.Text = "";

            txt_ConfirmPassword.UseSystemPasswordChar = true;
            txt_Password.UseSystemPasswordChar = true;
        }

        #endregion

        #region FormClosing Event

        private void RegisterU_FormClosing(object sender, EventArgs e)
        {
            Program.login.Close();
        }

        #endregion

        #region Checkbox

        private void chk_ShowPassword_CheckChange(object sender, EventArgs e)
        {
            if (chk_ShowPassword.Checked) { txt_Password.UseSystemPasswordChar = false; } else { txt_Password.UseSystemPasswordChar = true; }
        }

        #endregion

        private void materialLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.MoveFormExternal(true);
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

    }
}
