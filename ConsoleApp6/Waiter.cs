using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class Waiter
    {
        public void Receive(Object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs order = e as OrderEventArgs;
            Console.WriteLine("Waiter received order.");
            Console.WriteLine("Finish, " + order.DishName + ", " + order.Size);
        }
    }
}
