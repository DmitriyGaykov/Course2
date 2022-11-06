global using System.Diagnostics;
global using System.Reflection;
using System;
using System.Text;

namespace lab14;
internal class Program
{
    private static System.Timers.Timer timer;
    static void Main(string[] args)
    {
        try
        {
            #region Ex1

            // Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет,
            // время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.

            Process[] processes = Process.GetProcesses("Dima");
            Process process;

            const string PATH = "process.txt";
            StringBuilder text = new("");

            for (int i = 0; i < processes.Length; i++)
            {
                try
                {
                    process = processes[i];
                    
                    text.Append($"\n\nId: {process.Id},\n" +
                                $"Name: {process.ProcessName},\n" +
                                $"Priority: {process.BasePriority},\n" +
                                $"StartTime: {process.StartTime},\n" +
                                $"State: {process.Responding},\n" +
                                $"TotalProcessorTime: {process.TotalProcessorTime}\n\n");
                    
                    Console.WriteLine(text);

                    File.AppendAllText(PATH, text.ToString());

                    text.Clear();
                }
                catch { }
            }

            #endregion

            #region Ex2
            /*Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
    загруженные в домен.Создайте новый домен.Загрузите туда сборку.Выгрузите домен*/

            var thisAppDomain = Thread.GetDomain();

            Console.WriteLine($"\n\n\nName:  {thisAppDomain.FriendlyName}");
            Console.WriteLine($"Setup Information:  {thisAppDomain.SetupInformation.ToString()}");
            Console.WriteLine("Assemblies:");

            foreach (var item in thisAppDomain.GetAssemblies())
            {
                Console.WriteLine("    " + item.FullName.ToString());
            }

           //var newAppDomain = AppDomain.CreateDomain("NewAppDomain");

            #endregion

            #region Ex3

            Exesizes.Ex3(10000);

            #endregion

            #region Ex4

            Exesizes.Ex4(10);

            #endregion

       
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Thread.Sleep(20000);
    }
}