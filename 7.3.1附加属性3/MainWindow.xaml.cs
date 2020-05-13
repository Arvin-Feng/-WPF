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

namespace _7._3._1附加属性3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //和XAML里的代码等效， <!--Canvas.Left就是个附加属性-->
            //this.rect.SetBinding(Canvas.LeftProperty, new Binding("Value") { Source = sd1});
            //this.rect.SetBinding(Canvas.TopProperty, new Binding("Value") { Source = sd2});
        }
    }
}
