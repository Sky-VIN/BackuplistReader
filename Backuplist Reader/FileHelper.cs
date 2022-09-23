using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;


class FileHelper
{
    public static string SetFilesToSearch()
    {
        try
        {
            StreamReader file = new StreamReader(Data.Values.OpenList, System.Text.Encoding.UTF8);

            Data.Values.FilesToSearch.Clear();
            string line;
            bool start = false;
            while ((line = file.ReadLine()) != null)
            {
                if (!start && line.Equals("List:"))
                {
                    start = true;
                    continue;
                }

                if (start && line.Length > 1) Data.Values.FilesToSearch.Add(line);
            }

            file.Close();
        }
        catch (Exception e) { return e.Message; }

        return null;
    }


    public static string SearchFiles(string searchFile)
    {
        Data.Values.FoundFiles.Clear();
        try { Data.Values.FoundFiles.AddRange(Directory.GetFiles(Data.Values.BrowsePath, Path.GetFileName(searchFile), SearchOption.AllDirectories)); }
        catch (Exception e) { return e.Message; }

        return null;
    }


    public static string[] GenerateItem(string searchFile, string foundFile)
    {
        string ext = Path.GetExtension(foundFile);

        if (ext.Length > 1)
            ext = ext.Remove(0, 1).ToUpper();

        return new string[]
        {
            "",                                 // CheckBox
            ext,                                // Extension
            Path.GetFileName(foundFile),        // Found file name
            Path.GetDirectoryName(searchFile),  // Destination sub folder
            Path.GetDirectoryName(foundFile),   // Found file path
        };
    }


    public static string GetSourceAddress(string fileName, string filePath)
    { return filePath + "\\" + fileName; }


    public static string GetDestinationAddress(string fileName, string subFolder)
    {
        string destinationPath = Data.Values.CopyPath;

        /* check SubFolder */
        if (subFolder.Length > 0)
            destinationPath += "\\" + subFolder;

        return destinationPath + "\\" + fileName;
    }


    private static string CreateSubFolder(string destinationPath)
    {
        if (!Directory.Exists(destinationPath))
            try { Directory.CreateDirectory(destinationPath); }
            catch (Exception e) { return e.Message; }

        return null;
    }


    public static string CopyTo(string sourceAddress, string destinationAddress, bool overwrite)
    {
        /* check for file existing. Its faster then default check */
        if (!overwrite && File.Exists(destinationAddress))
            return BackuplistReader.Strings.FileExist + destinationAddress;

        /* delete existing file before copying 
         * in case if destination file is symlink or hardlink.
         * Default method(2) cant overwrite them */
        if (overwrite && File.Exists(destinationAddress))
            try { File.Delete(destinationAddress); }
            catch (Exception e) { return e.Message; }

        /* creating SubFolder */
        string errorMessage = CreateSubFolder(Path.GetDirectoryName(destinationAddress));
        if (errorMessage != null) return errorMessage;

        try { File.Copy(sourceAddress, destinationAddress); }
        catch (Exception e) { return e.Message; }

        return null;
    }


    [DllImport("kernel32.dll")]
    static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
    [DllImport("kernel32.dll")]
    static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

    public static string LinkTo(string sourceAddress, string destinationAddress, bool hardLink)
    {
        /* check drives for hardlink */
        if (hardLink && sourceAddress[0] != destinationAddress[0])
            return BackuplistReader.Strings.DifferentDrivesError;

        /* check for file existing */
        if (File.Exists(destinationAddress))
            return BackuplistReader.Strings.FileExist + destinationAddress;

        /* creating SubFolder */
        string errorMessage = CreateSubFolder(Path.GetDirectoryName(destinationAddress));
        if (errorMessage != null) return errorMessage;

        errorMessage = BackuplistReader.Strings.UnknownError;
        switch (hardLink)
        {
            case true:
                if (CreateHardLink(destinationAddress, sourceAddress, IntPtr.Zero) == true)
                    return null;
                break;
            case false:
                if (CreateSymbolicLink(destinationAddress, sourceAddress, 0) == true)
                    return null;
                break;
        }
        return errorMessage;
    }


    public static string SaveList(List<string> list)
    {
        try
        {
            StreamWriter file = new StreamWriter(Data.Values.SaveList, false, System.Text.Encoding.Default);

            foreach (string item in list)
                file.WriteLine(item);

            file.Close();
        }
        catch (Exception e) { return e.Message; }

        return null;
    }
}