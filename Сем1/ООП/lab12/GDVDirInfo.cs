namespace lab12;

/*4. Создать класс XXXDirInfo c методами для вывода информации о конкретном
директории
a.Количестве файлов
b. Время создания
c.Количестве поддиректориев
d.Список родительских директориев
e. Продемонстрируйте работу класса*/
static class GDVDirInfo
{
    public static void GetDirInfo(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var dir = new DirectoryInfo(path);

        Console.WriteLine($"Full path: {dir.FullName}");
        Console.WriteLine($"Number of files: {dir.GetFiles().Length}");
        Console.WriteLine($"Creation time: {dir.CreationTime}");
        Console.WriteLine($"Number of subdirectories: {dir.GetDirectories().Length}");
        Console.WriteLine($"Parent directory: {dir.Parent}\n\n");

        GDVLog.Write("GDVDirInfo", MethodBase.GetCurrentMethod()!.Name);
    }
}
