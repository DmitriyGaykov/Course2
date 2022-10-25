using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "";
            var buffer = new byte[1024];
            
            Info[] clients = new Info[4]
            { 
                new("Dima", "Gaykov", 18),
                new("Andrey", "Korenchuk", 19),
                new("Aleksey", "Kravchenko", 4),
                new("Lexa", "Adamovich", 18)
            };

            msg += JsonSerializer.Serialize(clients);

            buffer = Encoding.UTF8.GetBytes(msg);

            const string IP = "127.0.0.1";
            const int PORT = 8282;

            IPEndPoint ipEndPoint = new(IPAddress.Parse(IP), PORT);

            Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(ipEndPoint);

            socket.Listen(1);

            var listener = socket.Accept();

            listener.Send(buffer);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
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
}
