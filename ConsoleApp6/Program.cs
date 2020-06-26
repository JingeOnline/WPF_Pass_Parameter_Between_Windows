using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer c = new Customer();
            Waiter w = new Waiter();
            //c.Order += w.Receive;
            c.DoSomething();
        }
    }
}
