using GlobalSettingsFramework;
using System.IO;
using System.Windows.Forms;

namespace MoonByte.ClientSoftware.ServerHostingClient.Settings
{
    public class MoonSettings
    {
        public string Username;
        public string Password;

        private GFS manager = new GFS();
        private string SettingsDirectory = Application.StartupPath + @"\Bin\ApplicationSettings\";

        public void SaveAll()
        {
            if (!Directory.Exists(SettingsDirectory)) Directory.CreateDirectory(SettingsDirectory);
            manager.SettingsDirectory = SettingsDirectory + "settings.dll";

            manager.EditSetting("user", Username);
            manager.EditSetting("pass", Password);
        }

        public void LoadAll()
        {
            if (!Directory.Exists(SettingsDirectory)) Directory.CreateDirectory(SettingsDirectory);
            manager.SettingsDirectory = SettingsDirectory + "settings.dll";

            Username = manager.ReadSetting("user");
            Password = manager.ReadSetting("pass");
        }
    }
}
