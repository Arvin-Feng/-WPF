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

namespace _5._3._3ItemControl
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

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DependencyObject leve1 = VisualTreeHelper.GetParent(btn);
            DependencyObject leve2 = VisualTreeHelper.GetParent(leve1);
            DependencyObject leve3 = VisualTreeHelper.GetParent(leve2);
            MessageBox.Show(leve3.GetType().ToString());
        }
    }
}
