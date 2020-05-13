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

namespace _7._3._1附加属性2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeLayout();
        }

        private void InitializeLayout()
        {
          // < Grid ShowGridLines = "True" >
  
          //< Grid.ColumnDefinitions >
  
          //    < ColumnDefinition ></ ColumnDefinition >
  
          //    < ColumnDefinition ></ ColumnDefinition >
  
          //    < ColumnDefinition ></ ColumnDefinition >
  
          //</ Grid.ColumnDefinitions >
  
          //< Grid.RowDefinitions >
  
          //    < RowDefinition ></ RowDefinition >
  
          //    < RowDefinition ></ RowDefinition >
  
          //    < RowDefinition ></ RowDefinition >
  
          //</ Grid.RowDefinitions >
  
          //< Button Content = "确定" Grid.Column = "1" Grid.Row = "1" ></ Button >
       
          // </ Grid >

          //与以上在xaml中的代码等效， 其中使用了附加属性来设置button的位置。
          Grid grid = new Grid() { ShowGridLines = true};

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Button button = new Button() { Content = "确定" };
            //使用附加属性设置button的位置
            Grid.SetColumn(button, 1);
            Grid.SetRow(button, 1);

            grid.Children.Add(button);
            this.Content = grid;
        }

    }
}
