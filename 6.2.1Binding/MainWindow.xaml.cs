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

namespace _6._2._1Binding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu;
        public MainWindow()
        {
            InitializeComponent();
            #region 方法1
            //stu = new Student();
            //Binding binding = new Binding();
            //binding.Source = stu;
            //binding.Path = new PropertyPath("Name");
            //BindingOperations.SetBinding(this.txt1, TextBox.TextProperty, binding);
            #endregion

            //方法二 推荐方法， 简洁方便。
            this.txt1.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu = new Student() });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "大王";
        }
    }
}
