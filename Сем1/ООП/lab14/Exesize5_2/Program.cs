namespace Exesize5_2;

class Program
{
    public static void Main(string[] args)
    {
        Client c1 = new("Dima");
        Client c2 = new("Vova");
        Client c3 = new("Vasya");
        Client c4 = new("Petya");
        Client c5 = new("Sasha");

        Channel ch1 = new("ОНТ");
        Channel ch2 = new("Россия 1");
        Channel ch3 = new("ТНТ");

        Link(ref c1, ref ch1);
        Link(ref c2, ref ch1);
        Link(ref c3, ref ch1);
        Link(ref c4, ref ch1);
    }
    
    private static void Link(ref Client client,
                             ref Channel channel)
    {
        Thread th; 
        
        client.Channel = channel;

        th = new(new ThreadStart(client.Channel.Get));
        th.Name = client.Name;
        th.Start();
    }
}