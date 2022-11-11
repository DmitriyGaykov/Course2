using System.Numerics;

namespace lab15;

class Program
{

    static void Main(string[] args)
    {
        try
        {
            TPL.Ex8();
            TPL.Ex1(2200);
            TPL.Ex2(6000);
            TPL.Ex4_1();
            TPL.Ex4_2();
            TPL.Ex5();
            TPL.Ex6();
            TPL.Ex7();
        } 
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Thread.Sleep(100000);
    }
    
}