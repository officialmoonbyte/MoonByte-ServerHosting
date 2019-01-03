using IndieGoat.MaterialFramework.Controls;
using MoonByte.ClientSoftware.ServerHostingClient.Networking;
using MoonByte.ClientSoftware.ServerHostingClient.Overlay;
using MoonByte.ClientSoftware.ServerHostingClient.Resources;
using System;

namespace MoonByte.ClientSoftware.ServerHostingClient.Main
{
    public partial class ServerSettings : MaterialForm
    {
        ConsoleOverlay consoleOverlay;
        ServerModifier serverModifier = new ServerModifier(MoonResource.ServerIP, MoonResource.ServerPort);

        #region Vars

        string ServerName;
        string Username;

        string StartFile;
        string ServerArgs;

        bool IsServerOnline = false;

        #endregion

        #region OnStartup

        public ServerSettings(string ServerName, MaterialForm childForm)
        {

            consoleOverlay = new ConsoleOverlay(ServerName);
            consoleOverlay.OnReceiveConsoleInfo += OnOverlayRequest;

            this.ServerName = ServerName;
            this.Username = MoonResource.SettingsManager.Username;

            string s = serverModifier.IsOnline(Username, ServerName);

            //Start File
            string startFile_Request = serverModifier.CheckSetting(Username, ServerName, "STARTFILE");
            if (startFile_Request == "true") { StartFile = serverModifier.ReadSetting(Username, ServerName, "STARTFILE"); }

            //Server Args
            string ServerArgs_Request = serverModifier.CheckSetting(Username, ServerName, "SERVERARGS");
            if (ServerArgs_Request == "true") { ServerArgs = serverModifier.ReadSetting(Username, ServerName, "SERVERARGS"); }

            materialTextBox1.Text = ServerArgs;
            materialTextBox2.Text = StartFile;

            InitializeComponent();
        }

        #endregion

        #region Console Window Update

        private void OnOverlayRequest(object sender, EventArgs e)
        {
            if (this.InvokeRequired) this.Invoke(new Action(() =>
            {
                consoleText.Text = string.Join(Environment.NewLine, consoleOverlay.GetConsoleInformation());
            }));
        }

        #endregion

        #region Start Server

        private void serverPower_Click(object sender, EventArgs e)
        {
            if (IsServerOnline)
            {
                string s = serverModifier.StopServer(Username, ServerName);
                if (s == "true") { IsServerOnline = false; consoleOverlay.IsOnline = false; }
                else { IsServerOnline = true; consoleOverlay.IsOnline = true; }
            }
            else
            {
                string s = serverModifier.StartServer(Username, ServerName, StartFile, ServerArgs);
                if (s == "true") { IsServerOnline = true; consoleOverlay.IsOnline = true; }
                else { IsServerOnline = false; consoleOverlay.IsOnline = false; }
            }
        }

        #endregion

        private void ServerSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
