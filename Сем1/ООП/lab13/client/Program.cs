using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;

namespace client;

internal class Program
{
    static void Main(string[] args)
    {
        string msg;
        int size;
        byte[] buffer = new byte[1024];

        const string IP = "127.0.0.1";
        const int PORT = 8282;

        IPEndPoint ipEndPoint = new(IPAddress.Parse(IP), PORT);

        Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(ipEndPoint);

        while(true)
        {
            if(socket.Available > 0)
            {
                size = socket.Receive(buffer);
                msg = Encoding.UTF8.GetString(buffer, 0, size);
                break;
            }
        }

        socket.Shutdown(SocketShutdown.Both);
        socket.Close();

        var clients = JsonSerializer.Deserialize<Info[]>(msg);

        foreach (var client in clients)
        {
            Console.WriteLine(client.Name);
        }
    }
}

record struct Info
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public Info(string name,
                string surname,
                int age)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }

    public override string ToString() => $"Name: {Name},\tSurname: {Surname},\tAge: {Age}";
}