using IndieGoat.MaterialFramework.Controls;
using MoonByte.ClientSoftware.ServerHostingClient.MessageBox;
using System;

namespace MoonByte.ClientSoftware.ServerHostingClient.Startup
{
    public partial class Login : MaterialForm
    {

        #region Initializing

        public Login()
        {
            InitializeComponent();
            materialTextBox1.Text = "";
            materialTextBox2.Text = "";
            materialTextBox2.UseSystemPasswordChar = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        #endregion Initializing

        private void btn_Log_Click(object sender, EventArgs e)
        {
            new MaterialMessageBox("Wrong User Information", " \n \n The given username and password is incorrect! Please try again.").Show();
        }

        private void lbl_Title_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.MoveFormExternal(true);
            }
        }

        private void lbl_CreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();

            new RegisterU().Show();
        }

        private void materialTextBox2_Load(object sender, EventArgs e)
        {

        }
    }
}
