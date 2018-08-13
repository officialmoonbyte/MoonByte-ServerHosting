using IndieGoat.MaterialFramework.Controls;
using System;
using System.Windows.Forms;

namespace MoonByte.ClientSoftware.ServerHostingClient.Main
{
    public partial class MainPage : MaterialForm
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void lbl_Title_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.MoveFormExternal(true);
        }
    }
}
