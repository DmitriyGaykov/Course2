namespace lab8;
internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Headmaster Dima = new("Dima");
            Person Vova = new("Vova");
            Person Alex = new("Alex");
            Person Alexey = new("Alexey");

            Dima.AddMemberOrStudent(Vova);
            Dima.AddMemberOrStudent(Alex);
            Dima.AddMemberOrStudent(Alexey);

            Dima.PromoteDelegate(Alex, APerson.Roles.Teacher);
            Dima.PromoteDelegate(Alexey, APerson.Roles.Student);

            Console.WriteLine(Vova.ToString());

            Dima.PromoteDelegate(Vova, APerson.Roles.Teacher);
            Console.WriteLine(Vova.ToString());

            Alex.FineDelegate(Alexey, 100);
            Console.WriteLine(Alexey.ToString());

            Dima.FineDelegate(Vova, 2000);
            Console.WriteLine(Vova.ToString());

            Console.WriteLine("\n\n");
            string str = "hello world a";
            Console.WriteLine(str);

            StringCorrector.ToCorrect(ref str);
            Console.WriteLine(str);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}