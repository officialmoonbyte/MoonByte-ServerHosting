using IndieGoat.MaterialFramework.Controls;
using MoonByte.ClientSoftware.ServerHostingClient.MessageBox;
using MoonByte.ClientSoftware.ServerHostingClient.Resources;
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

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text == txt_ConfirmPassword.Text)
            {
                string EncryptedPassword = Encoding.sha256(txt_Password.Text);

                string command = MoonResource.MainClient.ClientSender.SendCommand("userdatabase", new string[] { "adduser", txt_Username.Text, EncryptedPassword });
                if (command == "USRADD_EXIST") { new MaterialMessageBox("User exist", " \n \n Username already exists!").Show(); }
                else if (command == "USRADD_TRUE")
                {
                    string emailCommand = MoonResource.MainClient.ClientSender.SendCommand("userdatabase", new string[] { "EDITUSERSETTING", txt_Username.Text, EncryptedPassword, "USREMAIL", txt_Email.Text });
                    if (emailCommand == "EDTSET_TRUE") { Console.WriteLine("Email setting is setup"); } else { Console.WriteLine("Email setting is not setup"); }

                    MoonResource.IsLoggedin = true;
                    MoonResource.SettingsManager.Username = txt_Username.Text;
                    MoonResource.SettingsManager.Password = EncryptedPassword;
                    new MaterialMessageBox("User created", " \n \n The username was sucessfully created!").Show();
                }
            }
            else
            {
                new MaterialMessageBox("User error", " \n \n Passwords does not match! Please try again.").Show();
            }
        }
    }
}
