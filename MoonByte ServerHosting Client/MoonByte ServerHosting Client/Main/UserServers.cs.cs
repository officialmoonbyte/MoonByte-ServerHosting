using IndieGoat.MaterialFramework.Controls;
using MoonByte.ClientSoftware.ServerHostingClient.Controls;
using MoonByte.ClientSoftware.ServerHostingClient.Resources;
using MoonByte.ClientSoftware.ServerHostingClient.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoonByte.ClientSoftware.ServerHostingClient.Main
{
    public partial class UserServers : MaterialForm
    {

        #region Vars

        List<ServerGUI> l_ServerGUI = new List<ServerGUI>();

        #endregion
        public UserServers()
        {
            InitializeComponent();
        }

        private void UserServers_Load(object sender, EventArgs e)
        {
            MoonResource.SettingsManager.SaveAll();
            UpdateResources();

        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            UpdateResources();
        }


        #region Rendering

        private void UserServers_Resize(object sender, EventArgs e)
        {
            DrawControls();
        }

        private void DrawControls()
        {
            int row = 0; int xold = 0; int yold = 0;
            if (l_ServerGUI.Count == 0)
            {
                foreach (string s in MoonResource.UserServers)
                {
                    if (s != "")
                    {
                        ServerGUI serverGUI = new ServerGUI(s);
                        serverGUI.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                        l_ServerGUI.Add(serverGUI);
                    }
                }
            }
            foreach (ServerGUI serverGUI in l_ServerGUI)
            {
                if (row == 0) { serverGUI.Location = new Point(xold, yold); }
                else
                {
                    if (((row + 1) * serverGUI.Width) > (this.Width - 120))
                    {
                        xold = 0; row = 0;
                        yold += (serverGUI.Height) + 32;
                        if(serverGUI.Location != new Point(xold, yold)) { serverGUI.Location = new Point(xold, yold); }
                    }
                    else
                    {
                        xold += (serverGUI.Width) + 32;
                        if (serverGUI.Location != new Point(xold, yold)) { serverGUI.Location = new Point(xold, yold); }
                    }
                }

                if (!usrServers.Controls.Contains(serverGUI)) { usrServers.Controls.Add(serverGUI); }
                row++;

                GC.WaitForPendingFinalizers();
                GC.Collect();

                Application.DoEvents();
            }
        }

        private void UpdateResources()
        {
            if (MoonResource.IsLoggedin == true) { List<string> s = MoonResource.serverModifier.GetUserServers(MoonResource.SettingsManager.Username); MoonResource.UserServers = s; Console.WriteLine("servers : " + string.Join(" ", s)); }
            DrawControls();
        }

        #endregion

        private void UserServers_ResizeEnd(object sender, EventArgs e)
        {
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
