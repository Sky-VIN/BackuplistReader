using Microsoft.Win32;
using System;


class RegistryHelper
{
    private const string settingsKey = @"HKEY_CURRENT_USER\Software\VIN\Backuplist Reader";

    private const string EXT_KEY = ".dbf";
    private const string EXT_LINK = "Daniel's Backuplist File";

    public static string Load(string valueName)
    { return Registry.GetValue(settingsKey, valueName, null) as string; }

    public static void Save(string valueName, string value)
    { Registry.SetValue(settingsKey, valueName, value); }

    static public void Integrate(string appPath)
    {
        RegistryKey key = Registry.ClassesRoot.CreateSubKey(EXT_KEY);
        Registry.SetValue(key.Name, null, EXT_LINK);

        key = Registry.ClassesRoot.CreateSubKey(EXT_LINK);
        Registry.SetValue(key.Name, null, EXT_LINK);

        key = Registry.ClassesRoot.CreateSubKey(EXT_LINK + @"\DefaultIcon");
        Registry.SetValue(key.Name, null, appPath + ",1");

        key = Registry.ClassesRoot.CreateSubKey(EXT_LINK + @"\shell\open\command");
        Registry.SetValue(key.Name, null, "notepad.exe %1");
    }
}





