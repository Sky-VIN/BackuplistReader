using BackuplistReader;
using System.Collections.Generic;


class Data
{
    /* this is crutch object for working with main list to avoid freezing UI */
    public class BackupListItem
    {
        public int index;
        public string sourceAddress;
        public string destinationAddress;

        public BackupListItem(int index, string sourceAddress, string destinationAddress)
        {
            this.index = index;
            this.sourceAddress = sourceAddress;
            this.destinationAddress = destinationAddress;
        }
    }

    public struct Values {
        public static string OpenList;
        public static string SaveList;
        public static string BrowsePath;
        public static string CopyPath;
        public static List<string> FilesToSearch = new List<string>();
        public static List<string> FoundFiles = new List<string>();
    }

    
    public static void Load()
    {
        Values.OpenList = RegistryHelper.Load(Strings.OpenList);
        Values.SaveList = RegistryHelper.Load(Strings.SaveList);
        Values.CopyPath = RegistryHelper.Load(Strings.CopyPath);
        Values.BrowsePath = RegistryHelper.Load(Strings.BrowsePath);
    }


    public static void Save() {
        if (Values.OpenList != null) RegistryHelper.Save(Strings.OpenList, Values.OpenList);
        if (Values.SaveList != null) RegistryHelper.Save(Strings.SaveList, Values.SaveList);
        if (Values.CopyPath != null) RegistryHelper.Save(Strings.CopyPath, Values.CopyPath);
        if (Values.BrowsePath != null) RegistryHelper.Save(Strings.BrowsePath, Values.BrowsePath);
    }
}