using System;
using System.Collections.Generic;
using System.Linq;
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

namespace _8._3._3路由事件在两棵树上的传递
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //为主窗体添加对Button_Click事件的侦听
            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.Button_Click));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //此事件是从myUserControl内部的innerButton出发。
            string strOriginalSource = string.Format("VisualTree start point: {0}, type is {1}", 
                    (e.OriginalSource as FrameworkElement).Name, e.Source.GetType().Name);

            string strSource = string.Format( "LogicalTree start point: {0}, type is {1}",
                (e.Source as FrameworkElement).Name, e.Source.GetType().Name);

            MessageBox.Show(strOriginalSource + "\r\n" + strSource);

        }

    }
}
