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

namespace _3._2._1使用Attribute给对象赋值
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //2. 通过后台代码设置属性；
            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.GradientStops.Add( new GradientStop() { Color = Colors.Blue, Offset = 0 } );
            lgb.GradientStops.Add(new GradientStop() { Color = Colors.Red, Offset = 0.5 });
            lgb.GradientStops.Add(new GradientStop() { Color = Colors.Green, Offset = 1 });
            this.rect.Fill = lgb;
        }
    }
}
