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

namespace _8._3._1使用WPF内置路由事件
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //在xaml里的gridRoot也可以这样写： ButtonBase.Click="gridRoot_Click"， 和下面是等价的。
            this.gridRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.ButtonClicked));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">这个参数就是   gridRoot</param>
        /// <param name="e">而事件发起的源头是： e.OriginalSource</param>
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( (e.OriginalSource as FrameworkElement).Name );
        }

        private void gridRoot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
