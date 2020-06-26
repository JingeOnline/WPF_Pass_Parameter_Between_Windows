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

namespace WpfApp2
{
    /// <summary>
    /// 使用自定义Event，MianWindow打开并传值给Window1
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

        public event PassMessageEventHandler PassMessageEvent;

        private void ButtonNewWindow_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            this.PassMessageEvent += window1.SetMessage;
            this.PassMessageEvent.Invoke(Message);
            window1.Show();
        }

        
    }
    public delegate void PassMessageEventHandler(string s);
}
