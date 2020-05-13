using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace _11._4._5查找由DataTemplate生成的控件2
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

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            //访问业务逻辑数据
            TextBox tb = e.OriginalSource as TextBox; //获取事件发起的源头
            ContentPresenter cp = tb.TemplatedParent as ContentPresenter; //获取模板目标
            Student stu = cp.Content as Student; //获取业务逻辑数据
            this.listViewStudent.SelectedItem = stu;

            //访问界面元素
            ListViewItem lvi = this.listViewStudent.ItemContainerGenerator.ContainerFromItem(stu) as ListViewItem;
            CheckBox chb = this.FindVisualChild<CheckBox>(lvi);
            if (chb.IsChecked == true)
                MessageBox.Show("已工作");
            else
                MessageBox.Show("未工作");
            //MessageBox.Show(chb.Name);
        }

        private T FindVisualChild<T>(DependencyObject obj)
            where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    return child as T;
                }
                else
                {
                    T t = FindVisualChild<T>(child);
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

    }
}
