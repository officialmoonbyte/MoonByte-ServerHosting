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
        public UserServers()
        {
            InitializeComponent();
        }

        private void UserServers_Load(object sender, EventArgs e)
        {
            MoonResource.SettingsManager.SaveAll();
            DrawControls();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            UpdateResources();
        }
        
        private void DrawControls()
        {
            usrServers.Controls.Clear();

            int row = 0; int xold = 0; int yold = 0;
            foreach (string s in MoonResource.UserServers)
            {
                ServerGUI serverGUI = new ServerGUI(s);

                if (row == 0) { serverGUI.Location = new Point(xold, yold); } else
                {
                    if (((row + 1) * serverGUI.Width) > (this.Width - 120))
                    {
                        xold = 0; row = 0;
                        yold += (serverGUI.Height) + 32;
                        serverGUI.Location = new Point(xold, yold);
                    }
                    else
                    {
                        xold += (serverGUI.Width) + 32;
                        serverGUI.Location = new Point(xold, yold);
                    }
                }

                row++;
                usrServers.Controls.Add(serverGUI);
            }
        }

        private void UpdateResources()
        {
            if(MoonResource.IsLoggedin == true) { List<string> s = MoonResource.serverModifier.GetUserServers(MoonResource.SettingsManager.Username); MoonResource.UserServers = s; Console.WriteLine("servers : " + string.Join(" ", s)); }
            DrawControls();
        }

        private void UserServers_ResizeEnd(object sender, EventArgs e)
        {
            DrawControls();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
