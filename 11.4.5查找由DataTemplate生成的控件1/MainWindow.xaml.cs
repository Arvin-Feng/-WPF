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

namespace _11._4._5查找由DataTemplate生成的控件1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //1. 如果需要取到元素的界面属性， 如宽度、高度等，就使用此方法；
            TextBlock tb = this.cp.ContentTemplate.FindName("txt1", this.cp) as TextBlock;
            MessageBox.Show(tb.Text);

            //2. 如果仅仅取到对象， 这种方法最好！
            //Student student = this.cp.Content as Student;
            //MessageBox.Show(student.Name);
        }
    }
}
