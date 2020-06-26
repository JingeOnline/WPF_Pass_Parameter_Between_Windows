using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// 使用委托传值，双向传值。
    /// 主窗口向window1传值是靠构造函数传值，同时传入委托方法
    /// window1向主窗口传值是靠委托方法
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private Person _person;

        public Person Person
        {
            get { return _person; }
            set { _person = value; OnPropertyChanged(); }
        }


        public MainWindow()
        {
            InitializeComponent();
            Person = new Person();
            this.DataContext = this;
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

        private void ButtonModifyProfile_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(setPerson,Person);
            window1.Show();
        }

        private void setPerson(Person p)
        {
            Person = p;
        }

        //说明Person对象的属性值变化，不会刷新在UI上
        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            Person.Age++;
            Debug.WriteLine(Person.Age);
        }
    }
}
