using System;
using System.Collections.Generic;
using System.IO;
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

namespace _6._4._2Binding的数据转换
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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> planeList = new List<Plane>() 
            { 
                new Plane(){Category = Category.Bomber, Name="B-1", State=State.Unknown},
                new Plane(){Category = Category.Bomber, Name="B-2", State=State.Unknown},
                new Plane(){Category = Category.Fighter, Name="F-22", State=State.Unknown},
                new Plane(){Category = Category.Bomber, Name="Su-47", State=State.Unknown},
                new Plane(){Category = Category.Fighter, Name="J-10", State=State.Unknown},
            };
            this.listBoxPlane.ItemsSource = planeList;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Plane item in listBoxPlane.Items)
            {
                sb.AppendLine(string.Format($"Category={item.Category}, Name={item.Name}, State={item.State}"));
            }
            File.WriteAllText(@"D:\PlaneList.txt", sb.ToString());
        }
    }
}
