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

namespace _7._2._2声明和使用依赖属性
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
            #region 1. 使用BindingOperations绑定数据
            //stu = new Student();
            //Binding binding = new Binding("Text") { Source = txt1 };
            ////把stu对象借助Binding实例依赖在txt1上。
            //BindingOperations.SetBinding(stu, Student.NameProperty, binding); 
            #endregion

            #region 3. txt1作为txt2的源， 使用TextBox的SetBinding方法
            Binding binding = new Binding("Text") { Source = txt1 };
            txt2.SetBinding(TextBox.TextProperty, binding);
            #endregion

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            #region 2. 简单说明依赖属性读、取
            //Student stu = new Student();
            //stu.SetValue(Student.NameProperty, this.txt1.Text);     //把txt1.Text属性的值存储进依赖属性
            //txt2.Text = (string)stu.GetValue(Student.NameProperty); //把值取出来

            #endregion

            MessageBox.Show(stu.GetValue(Student.NameProperty).ToString());

        
        }
    }
}
