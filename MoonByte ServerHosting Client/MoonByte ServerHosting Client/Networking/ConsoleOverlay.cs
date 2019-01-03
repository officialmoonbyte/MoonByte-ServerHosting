using MoonByte.ClientSoftware.ServerHostingClient.Overlay;
using MoonByte.ClientSoftware.ServerHostingClient.Resources;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MoonByte.ClientSoftware.ServerHostingClient.Networking
{
    public class ConsoleOverlay
    {

        #region Vars

        // Vars used for networking commands
        string Username;
        string ServerName;

        public bool IsOnline = false;

        //Network overlay for UniversalClient
        ServerModifier serverModifier = new ServerModifier(MoonResource.ServerIP, MoonResource.ServerPort);

        //All the console information
        List<string> consoleInfo = new List<string>();

        //Events
        public event EventHandler OnReceiveConsoleInfo;

        #endregion

        #region OnStartup

        /// <summary>
        /// Initializes ConsoleOverlay
        /// </summary>
        /// <param name="ServerName">Server name of the user</param>
        public ConsoleOverlay(string ServerName)
        {
            this.ServerName = ServerName;
            this.Username = MoonResource.SettingsManager.Username;

            StartThread();
        }

        #endregion

        #region GetConsoleInformation

        public List<string> GetConsoleInformation() { return consoleInfo; }

        #endregion

        #region Thread

        private void StartThread()
        {
            new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (IsOnline)
                    {
                        List<string> tmpConsole = serverModifier.GetConsoleInfo(Username, ServerName);
                        if (tmpConsole != consoleInfo)
                        {
                            consoleInfo = tmpConsole;
                            OnReceiveConsoleInfo?.Invoke(this, new EventArgs());
                        }
                    }
                }
            })).Start();
        }

        #endregion
    }
}
