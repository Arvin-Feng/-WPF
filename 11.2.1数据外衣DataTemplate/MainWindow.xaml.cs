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

namespace _11._2._1数据外衣DataTemplate
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

        //初始化listbox
        private void InitialCarList()
        {
            List<Car> carList = new List<Car>()
            {
                new Car(){Automaker="Lamborghini", Name="CarA", Year="2000", TopSpeed="340"},
                new Car(){Automaker="Lamborghini", Name="CarB", Year="2001", TopSpeed="350"},
                new Car(){Automaker="Lamborghini", Name="CarC", Year="2002", TopSpeed="360"},
                new Car(){Automaker="Lamborghini", Name="CarD", Year="2003", TopSpeed="370"},
            };
            foreach (Car car in carList)
            {
                CarListItemView view = new CarListItemView();
                view.Car = car;
                this.listBoxCars.Items.Add(view);
            }
        }


        private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListItemView view = e.AddedItems[0] as CarListItemView;
            if (view != null)
            {
                this.detailView.Car = view.Car;
            }
        }
    }
}
