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

namespace MoonByte.ClientSoftware.ServerHostingClient.MessageBox
{
    public partial class MaterialMessageBox : MaterialForm
    {
        public MaterialMessageBox(string Title, string Text)
        {
            InitializeComponent();

            this.Text = Title; materialLabel1.Text = Text;
        }

        private void AccountInformationWrong_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
