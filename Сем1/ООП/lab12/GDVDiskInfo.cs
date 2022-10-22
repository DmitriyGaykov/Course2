using System.Reflection;

namespace lab12;
static class GDVDiskInfo
{
    /*2. Создать класс XXXDiskInfo c методами для вывода информации о
    a.свободном месте на диске
    b. Файловой системе
    c.Для каждого существующего диска - имя, объем, доступный
    объем, метка тома.
    d.Продемонстрируйте работу класса*/

    public static void FreeSpace(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var drive = new DriveInfo(path);
        Console.WriteLine($"Free space: {(int)(drive.TotalFreeSpace / 1000000)}Mb\n\n");

        GDVLog.Write("GDVDiskInfo", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void FileSystem(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var drive = new DriveInfo(path);
        Console.WriteLine($"File system: {drive.DriveFormat}\n\n");
        GDVLog.Write("GDVDiskInfo", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void DriveInfo(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var drive = new DriveInfo(path);
        Console.WriteLine($"Drive name: {drive.Name}");
        Console.WriteLine($"Drive size: {drive.TotalSize}");
        Console.WriteLine($"Drive free space: {drive.TotalFreeSpace}");
        Console.WriteLine($"Drive label: {drive.VolumeLabel}\n\n");
        GDVLog.Write("GDVDiskInfo", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void AllDriveInfo()
    {
        var drives = System.IO.DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            Console.WriteLine($"Drive name: {drive.Name}");
            Console.WriteLine($"Drive size: {drive.TotalSize}");
            Console.WriteLine($"Drive free space: {drive.TotalFreeSpace}");
            Console.WriteLine($"Drive label: {drive.VolumeLabel}\n\n\n");
        }
        GDVLog.Write("GDVDiskInfo", MethodBase.GetCurrentMethod()!.Name);
    }
}
