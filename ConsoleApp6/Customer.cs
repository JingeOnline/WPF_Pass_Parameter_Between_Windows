using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp6
{
    class Customer
    {
        public event EventHandler Order;
        
        public void DoSomething()
        {
            Console.WriteLine("Customer come in.");
            Console.WriteLine("Customer thinking...");
            Thread.Sleep(2000);
            //说明有人订阅了该事件
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Pizza";
                e.Size = "Large";
                //this是事件的发起者,e是事件携带的消息
                this.Order.Invoke(this, e);
            }
            Console.WriteLine("Customer place order.");
        }
    }
}
