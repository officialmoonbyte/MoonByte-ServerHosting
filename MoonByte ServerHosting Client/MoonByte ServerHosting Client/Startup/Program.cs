using IndieGoat.Net.Updater;
using MoonByte.ClientSoftware.ServerHostingClient.Main;
using MoonByte.ClientSoftware.ServerHostingClient.Resources;
using MoonByte.ClientSoftware.ServerHostingClient.Settings;
using System;
using System.Net;
using System.Windows.Forms;


namespace MoonByte.ClientSoftware.ServerHostingClient.Startup
{
    static class Program
    {

        public static Form login;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Timer domainTimer = new Timer();
            domainTimer.Tick += Domain_Tick;
            domainTimer.Start();

            InitializeServerConnections();

            login = new MainPage();

            Application.Run(login);
        }

        #region DomainTick
        static void Domain_Tick(object sender, EventArgs e) { FormCollection forms = Application.OpenForms; if (forms.Count == 0) { MoonResource.SettingsManager.SaveAll(); Application.Exit(); } }
        #endregion

        #region Initializing Connections

        public static void InitializeServerConnections()
        {
            MoonResource.SettingsManager.LoadAll();

            string ServerIP = "indiegoat.us";

            string ExternalIP = GetExternalIP();
            string RawServerIP = GetRawIP();

            if (ExternalIP.Contains(RawServerIP)) ServerIP = "192.168.0.16";

            MoonResource.FileManager = new Net.Plugins.RemoteFileManagement(ServerIP, 4543);
            MoonResource.MainClient.ConnectToRemoteServer(ServerIP, 4543);

            MoonResource.ClientUpdater = new UniversalServiceUpdater();
            while (true)
            {
                if (MoonResource.ClientUpdater.CheckUniversalAPI()) break;
            }

            MoonResource.ClientUpdater.CheckUpdate(ServerIP, 4543);

            if(MoonResource.SettingsManager.Username != null)
            {
                string ServerResponse = MoonResource.MainClient.ClientSender.SendCommand("UserDatabase", new string[] { "LOGINUSER", MoonResource.SettingsManager.Username, MoonResource.SettingsManager.Password });

                if (ServerResponse == "USRLOG_TRUE")
                {
                    MoonResource.IsLoggedin = true;


                } else if (ServerResponse == "USRLOG_WRONG")
                {
                    MoonResource.SettingsManager.Username = null;
                    MoonResource.SettingsManager.Password = null;
                } else if (ServerResponse == "USRLOG_DOESNOTEXIST")
                {
                    MoonResource.SettingsManager.Username = null;
                    MoonResource.SettingsManager.Password = null;
                }
            }
        }

        public static string GetExternalIP() { return new WebClient().DownloadString("http://icanhazip.com"); }
        public static string GetRawIP() { return Dns.GetHostEntry("indiegoat.us").AddressList[0].ToString(); }

        #endregion
    }
}
