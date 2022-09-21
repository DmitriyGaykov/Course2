namespace lab6;
class MainClass
{
    public static void Main(string[] args)
    {
        User user1 = new();
        try
        {
            user1.CreateUser();
            user1.CalculateNumbers(1, 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Программа завершена");
            Console.WriteLine($"Был создан пользователь:\n {user1.ToString()}");
        }
    }
}