using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    //用来传递事件信息的类,约定用EventArgs结尾。
    class OrderEventArgs :EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
}
