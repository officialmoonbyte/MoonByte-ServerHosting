using IndieGoat.Net.Tcp;
using IndieGoat.Net.Updater;
using MoonByte.ClientSoftware.ServerHostingClient.Overlay;
using MoonByte.ClientSoftware.ServerHostingClient.Settings;
using MoonByte.Net.Plugins;
using System.Collections.Generic;

namespace MoonByte.ClientSoftware.ServerHostingClient.Resources
{
    public static class MoonResource
    {
        public static UniversalClient MainClient = new UniversalClient();
        public static UniversalServiceUpdater ClientUpdater;
        public static MoonSettings SettingsManager = new MoonSettings();
        public static RemoteFileManagement FileManager;
        public static ServerModifier serverModifier;

        public static string ServerDirectory;
        public static List<string> UserServers;

        public static bool IsLoggedin = false;

        public static List<string> Servers = new List<string>();
    }
}
