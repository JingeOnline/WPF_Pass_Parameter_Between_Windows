using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window,INotifyPropertyChanged
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { _person = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            if (this.PropertyChanged != null)
            {
                var handler = PropertyChanged;
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        //声明一个委托类型的变量
        private MessageBackDelegate _messageBackDelegate;

        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        //添加一个构造函数，接收由主窗口传过来的值，和委托方法
        public Window1(MessageBackDelegate backDelegate,Person p) : this()
        {
            //为委托变量赋值
            _messageBackDelegate = backDelegate;
            this.Person = p;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (_messageBackDelegate != null)
            {
                //执行委托方法
                _messageBackDelegate.Invoke(Person);
                this.Close();
            }
        }
    }

    //声明一个委托类型
    public delegate void MessageBackDelegate(Person p);
}
