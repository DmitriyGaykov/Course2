using System.IO.Compression;

namespace lab12;

/*5. Создать класс XXXFileManager.Набор методов определите
самостоятельно.С его помощью выполнить следующие действия:
a.Прочитать список файлов и папок заданного диска.Создать
директорий XXXInspect, создать текстовый файл
xxxdirinfo.txt и сохранить туда информацию.Создать
копию файла и переименовать его. Удалить
первоначальный файл.
b.Создать еще один директорий XXXFiles.Скопировать в
него все файлы с заданным расширением из заданного
пользователем директория. Переместить XXXFiles в
XXXInspect.
c.Сделайте архив из файлов директория XXXFiles. 
Разархивируйте его в другой директорий.
*/
static class GDVFileManager
{
    public static void GetFilesAndFoulders(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }
        DirectoryInfo dir = new(path);

        var files = dir.GetFiles();
        var foulders = dir.GetDirectories();

        dir.CreateSubdirectory("GDVInspect");

        dir = new(path + "\\GDVInspect");

        string path_dirInfo = "gdvdirinfo.txt";

        using StreamWriter sw = new(dir.FullName + "\\" + path_dirInfo);

        foreach (var f in files)
        {
            sw.WriteLine(f.Name);
        }

        sw.WriteLine("\n");

        foreach (var f in foulders)
        {
            sw.WriteLine(f.Name);
        }

        sw.WriteLine("\n");

        GDVLog.Write("GDVFileManager", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void CreateCopyOfFile(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        FileInfo file = new(path);

        DirectoryInfo dir = file.Directory ??
                            throw new ArgumentNullException("Directory is not found");

        string fullNameOfCopy = $"{dir.FullName}\\copy_{file.Name}";
        Remove(fullNameOfCopy);

        file.CopyTo(fullNameOfCopy);

        GDVLog.Write("GDVFileManager", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void Remove(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        FileInfo file = new(path);
        file.Delete();

        GDVLog.Write("GDVFileManager", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void CreateDirectory(string path,
                                       string name)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        DirectoryInfo dir = new(path);
        dir.CreateSubdirectory(name);

        GDVLog.Write("GDVFileManager", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void ReplaceTo(string pathFrom,
                                 string pathTo,
                                 params string[] extens)
    {
        DirectoryInfo dirFrom = new(pathFrom);
        DirectoryInfo dirTo = new(pathTo);

        var files = dirFrom.GetFiles();

        foreach (var file in files)
        {
            if (extens.Length == 0 ||
                extens.Contains(file.Extension))
            {
                Remove(dirTo.FullName + "\\" + file.Name);
                file.MoveTo(dirTo.FullName + "\\" + file.Name);
            }
        }

        GDVLog.Write("GDVFileManager", MethodBase.GetCurrentMethod()!.Name);
    }

    public static void CreateArchive(string dirPath)
    {
        if (dirPath is null)
        {
            throw new ArgumentNullException(nameof(dirPath));
        }
        DirectoryInfo dir = new(dirPath);
        Console.WriteLine(dir.Name);
        string path = $"{dir.FullName}\\..\\{dir.Name}.zip";

        Remove(path);

        ZipFile.CreateFromDirectory(dir.FullName, path);

        GDVLog.Write("GDVFileManager", MethodBase.GetCurrentMethod()!.Name);
    }
}
