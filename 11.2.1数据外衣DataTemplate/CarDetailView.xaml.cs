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
    /// CarDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }
        private Car car;
        public Car Car
        {
            get { return car; }
            set 
            {
                car = value;
                this.txtBlockName.Text = car.Name;
                this.txtYear.Text = car.Year;
                this.txtTopSpeed.Text = car.TopSpeed;
                this.txtAutoMaker.Text = car.Automaker;
                string uriStr = string.Format(@"/Resources/Images/{0}.jpg", car.Name);
                this.imagePhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
