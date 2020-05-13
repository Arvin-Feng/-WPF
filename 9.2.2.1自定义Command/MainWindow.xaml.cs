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

namespace _9._2._2._1自定义Command
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //定义命令
            ClearCommand clearCommand = new ClearCommand();
            //给命令源指定命令
            this.ctrlClear.Command = clearCommand;
            //给命令源指定目标
            this.ctrlClear.CommandTarget = this.miniView;
        }
    }
}
