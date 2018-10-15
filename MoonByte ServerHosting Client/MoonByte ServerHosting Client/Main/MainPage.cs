using IndieGoat.MaterialFramework.Controls;
using System;
using System.Drawing;
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
            PanelStartup();
            SetPanelEvents();
        }

        private void lbl_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.MoveFormExternal(true);
        }

        #region Server and User panel button's

        #region MouseEvents



        #endregion

        #region Panel Startup

        private void PanelStartup()
        {
            Image profileImage = new Bitmap(Application.StartupPath + @"\img\userIcon.png");
            Image serverIcon = new Bitmap(Application.StartupPath + @"\img\serverIcon.png");

            pnl_User.BackgroundImage = profileImage;
            pnl_Server.BackgroundImage = serverIcon;
        }

        #endregion 

        #region Setting Events

        private void SetPanelEvents()
        {
            pnl_MainUser.Click += PanelUser_Click;
            pnl_mainServer.Click += PanelServer_Click;

            foreach (Control control in pnl_MainUser.Controls)
            {
                control.Click += PanelUser_Click;
            }
            foreach (Control control in pnl_mainServer.Controls)
            {
                control.Click += PanelServer_Click;
            }
        }

        #endregion

        #region Click Event

        private void PanelUser_Click(object server, EventArgs e)
        {
            Console.WriteLine(true);
        }

        private void PanelServer_Click(object sender, EventArgs e)
        {
            Console.WriteLine(true);
        }

        #endregion

        #endregion

    }
}
