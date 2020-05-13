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

namespace _7._2._2._1依赖属性例子
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu = null;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();
            stu.SetBinding( Student.NameProperty, new Binding("Text") { Source = txt1} );
            txt2.SetBinding( TextBox.TextProperty, new Binding("Name") { Source = stu} );
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
