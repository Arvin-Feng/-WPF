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
using System.Collections.ObjectModel;

namespace _6._3._7ItemsSource
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        ObservableCollection<Student> students = new ObservableCollection<Student>();
        public MainWindow()
        {
            InitializeComponent();
            students.Add(new Student() { Id = 1, Name = "A", Age = random.Next(20, 40), Sex = random.Next(0, 1) > 0.5 ? "男" : "女" } );
            students.Add(new Student() { Id = 2, Name = "B", Age = random.Next(20, 40), Sex = random.Next(0, 1) > 0.5 ? "男" : "女" });
            students.Add(new Student() { Id = 3, Name = "C", Age = random.Next(20, 40), Sex = random.Next(0, 1) > 0.5 ? "男" : "女" });
            students.Add(new Student() { Id = 4, Name = "D", Age = random.Next(20, 40), Sex = random.Next(0, 1) > 0.5 ? "男" : "女" });
            students.Add(new Student() { Id = 5, Name = "E", Age = random.Next(20, 40), Sex = random.Next(0, 1) > 0.5 ? "男" : "女" });
            #region 在cs代码绑定  目前没有办法直接在xaml文件里设置数据源！！！
            //方法1：
            this.lstStudents.ItemsSource = students;

            //方法2：
            //this.lstStudents.DataContext = students;
            //<ListBox x:Name="lstStudents" Height="120" Margin="5" ItemsSource="{Binding}">

            //this.lstStudents.DisplayMemberPath = "Name";
            ////
            Binding binding = new Binding("SelectedItem.Id") { Source = this.lstStudents };
            this.txtNameId.SetBinding(TextBox.TextProperty, binding);
            #endregion


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Student student = (from a in students where a.Id == Convert.ToInt32(this.txtNameId.Text.Trim()) select a).First<Student>();
            //student.Name = student.Name + '1';

            students[2].Name = "FF";
            //students.Add(new Student() { Id = 5, Name = "EE", Age = random.Next(20, 40), Sex = random.Next(0, 1) > 0.5 ? "男" : "女" });
        }
    }
}
