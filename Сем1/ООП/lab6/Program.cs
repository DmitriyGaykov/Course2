namespace lab6;
class MainClass
{
    public static void Main(string[] args)
    {
        Logger Log = new();

        User user1 = new();

        Log.WriteLine("Переменная user1 создана");
        // Продемонстрируйте возможность многоразовой обработки одного 
        // исключения и проброс его выше по стеку вызовов        
        try
        {
            user1.CreateUser();
            Log.WriteLine("CreateUser | Переменная user1 заполнена");
            user1.CalculateNumbers(1, 0);
            Log.WriteLine("CalculateNumbers | Расчет произведен");
        }
        catch (Exception e)
        {
            Log.WriteError(e.Message);
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Программа завершена");
            Console.WriteLine($"Был создан пользователь:\n {user1.ToString()}");
        }
        Log.WriteEnd();
    }
}