namespace lab12;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            GDVLog.Write("Main", "Start");

            GDVDiskInfo.FreeSpace("D:\\");
            GDVDiskInfo.FileSystem("C:\\");
            GDVDiskInfo.DriveInfo("C:\\");
            GDVDiskInfo.AllDriveInfo();

            GDVFileInfo.GetFileInfo("gdvlogfile.json");

            GDVDirInfo.GetDirInfo("D:\\");

            GDVFileManager.GetFilesAndFoulders("..\\net6.0");
            GDVFileManager.CreateCopyOfFile("GDVInspect\\gdvdirinfo.txt");
            GDVFileManager.Remove("GDVInspect\\gdvdirinfo.txt");

            GDVFileManager.CreateDirectory("..\\net6.0", "GDVFiles");
            GDVFileManager.ReplaceTo("..\\net6.0", "GDVFiles", ".dll", ".exe");

            GDVFileManager.CreateArchive("GDVFiles");

            GDVLog.Write("Main", "End");

            var datas = GDVLog.Find(DateTime.Now.AddMinutes(-40), DateTime.Now.AddMinutes(-20));

            foreach (var d in datas)
            {
                Console.WriteLine(d);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}