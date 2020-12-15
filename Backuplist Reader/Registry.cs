using Microsoft.Win32;

namespace Backuplist_Reader
{
    class RegistryHelper
    {
        private const string settingsKey = @"HKEY_CURRENT_USER\Software\VIN\Backuplist Reader";

        public string loadPath(string valueName)
        { return (string)Registry.GetValue(settingsKey, valueName, null); }

        public void savePath(string valueName, string value)
        { Registry.SetValue(settingsKey, valueName, value); }
    }
}
