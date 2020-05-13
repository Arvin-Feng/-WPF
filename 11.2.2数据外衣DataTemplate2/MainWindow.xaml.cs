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

namespace _11._2._2数据外衣DataTemplate2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialCarList();
        }

        private void InitialCarList()
        {
            List<Car> carList = new List<Car>()
            {
                new Car(){Automaker="Lamborghini", Name="CarA", Year="2000", TopSpeed="340"},
                new Car(){Automaker="Lamborghini", Name="CarB", Year="2001", TopSpeed="350"},
                new Car(){Automaker="Lamborghini", Name="CarC", Year="2002", TopSpeed="360"},
                new Car(){Automaker="Lamborghini", Name="CarD", Year="2003", TopSpeed="370"},
            };

            //填充数据
            this.listBoxCars.ItemsSource = carList;
        }

    }
}
