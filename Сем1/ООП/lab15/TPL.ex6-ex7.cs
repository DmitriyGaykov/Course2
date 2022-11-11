using System.Collections.Concurrent;

namespace lab15;
static partial class TPL
{
    public static void Ex6()
    {
        Parallel.Invoke(
            () =>
            {
                Thread.Sleep(4000);
                Console.WriteLine("Первая функция выполнена!");
            },
            () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Вторая функция выполнена!");
            },
            () =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Третья функция выполнена!");
            },
            () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Четвертая функция выполнена!");
            }
            );
    }
    
    public static void Ex7()
    {
        BlockingCollection<Product> products = new();
        Task поставщик1 = new(()=>
        {
            int cnt = 0;
            while (cnt < 2 && products.TryAdd(new Product()))
            {
                cnt++;
                Console.WriteLine("Поставщик 1 добавил товар");
                Thread.Sleep(1700);
            }
        });
        Task поставщик2 = new(() =>
        {
            int cnt = 0;
            while (cnt < 2 && products.TryAdd(new Product()))
            {
                cnt++;
                Console.WriteLine("Поставщик 2 добавил товар");
                Thread.Sleep(2000);
            }
        });
        Task поставщик3 = new(() =>
        {
            int cnt = 0;
            while (cnt < 2 && products.TryAdd(new Product()))
            {
                cnt++;
                Console.WriteLine("Поставщик 3 добавил товар");
                Thread.Sleep(600);
            }
        });
        Task поставщик4 = new(() =>
        {
            int cnt = 0;
            while (cnt < 2 && products.TryAdd(new Product()))
            {
                cnt++;
                Console.WriteLine("Поставщик 4 добавил товар");
                Thread.Sleep(3000);
            }
        });
        Task поставщик5 = new(() =>
        {
            int cnt = 0;
            while (cnt < 2 && products.TryAdd(new Product()))
            {
                cnt++;
                Console.WriteLine("Поставщик 5 добавил товар");
                Thread.Sleep(1250);
            }
        });

        Task клиент1 = new(() =>
        {
            Product prod = new();
            while(true)
            {
                if(products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 1 забрал продукт");
                }
            }
        });
        Task клиент2 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                { 
                    Console.WriteLine("Клиент 2 забрал продукт");
                }
            }
        });
        Task клиент3 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 3 забрал продукт");
                }
            }
        });
        Task клиент4 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {                    
                    Console.WriteLine("Клиент 4 забрал продукт");
                }
            }
        });
        Task клиент5 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 5 забрал продукт");
                }
            }
        });
        Task клиент6 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 6 забрал продукт");
                }
            }
        });
        Task клиент7 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 7 забрал продукт");
                }
            }
        });
        Task клиент8 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 8 забрал продукт");
                }
            }
        });
        Task клиент9 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 9 забрал продукт");
                }
            }
        });
        Task клиент10 = new(() =>
        {
            Product prod = new();
            while (true)
            {
                if (products.TryTake(out prod) && prod is not null)
                {
                    Console.WriteLine("Клиент 10 забрал продукт");
                }
            }
        });

        поставщик1.Start();
        поставщик2.Start();
        поставщик3.Start();
        поставщик4.Start();
        поставщик5.Start();

        клиент1. Start();
        клиент2 .Start();
        клиент3 .Start();
        клиент4 .Start();
        клиент5 .Start();
        клиент6 .Start();
        клиент7 .Start();
        клиент8 .Start();
        клиент9 .Start();
        клиент10.Start();
    }
}

class Product
{
    public string Name { get; set; }
    public uint Price { get; set; }
    
    public Product(string name,
                   uint price)
    {
        Name = name;
        Price = price;
    }

    public Product()
    {
        Name = String.Empty;
        Price = 0;
    }

    public override string ToString() => $"Name: {Name}, Price: {Price}";
}
