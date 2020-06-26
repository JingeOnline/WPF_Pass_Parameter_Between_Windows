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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// 使用自定义Event，MianWindow打开Window1，Window1传值给MianWindow
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            if (this.PropertyChanged != null)
            {
                var handler = PropertyChanged;
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ButtonNewWindow_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            //PassMessage事件挂接的方法必须和PassMessageEventHandler委托的类型一致
            window1.PassMessage += SetMessage;
            window1.Show();
        }

        public void SetMessage(string str)
        {
            Message = str;
        }
    }
}
