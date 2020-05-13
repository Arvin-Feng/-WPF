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

namespace _6._3._3Binding的路径
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> stringList = new List<string> {"Tim", "Tom", "Blog" };

            //取list的默认值
            txt3.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList});
            //
            txt4.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList, 
                Mode=BindingMode.OneWay });
        }
    }
}
