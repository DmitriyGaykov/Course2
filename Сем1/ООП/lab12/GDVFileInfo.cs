global using System.Reflection;

namespace lab12;
/*Создать класс XXXFileInfo c методами для вывода информации о
конкретном файле
a.Полный путь
b. Размер, расширение, имя
c. Дата создания, изменения
d. Продемонстрируйте работу класса*/
static class GDVFileInfo
{
    public static void GetFileInfo(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var file = new FileInfo(path);

        Console.WriteLine($"Full path: {file.FullName}");
        Console.WriteLine($"File size: {file.Length}");
        Console.WriteLine($"File extension: {file.Extension}");
        Console.WriteLine($"File name: {file.Name}");
        Console.WriteLine($"File creation time: {file.CreationTime}");
        Console.WriteLine($"File last write time: {file.LastWriteTime}\n\n");

        GDVLog.Write("GDVFileInfo", MethodBase.GetCurrentMethod()!.Name);
    }
}
