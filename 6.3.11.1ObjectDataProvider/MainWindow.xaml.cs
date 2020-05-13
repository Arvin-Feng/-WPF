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

namespace _6._3._11._1ObjectDataProvider
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetBinding();
        }

        private void SetBinding()
        {
            //创建并配置ObjectDataProvider对象
            ObjectDataProvider odp = new ObjectDataProvider();
            odp.ObjectInstance = new Calculator();
            odp.MethodName = "Add";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");
            //以ObjectDataProvider对象为Source创建Binding
            Binding bindingArg1 = new Binding("MethodParameters[0]")
            {              
                Source = odp,
                //设置binding对象只是负责把从UI元素收集到的数据写入其直接Source(即ObjectDataProvider对象)。
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged//有更新就立即将值传会Source
            };

            Binding bindingArg2 = new Binding("MethodParameters[1]") {
                Source = odp,
                BindsDirectlyToSource = true, 
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            Binding bindingResult = new Binding(".") { Source = odp};

            //将Binding关联到UI元素上
            this.txtArg1.SetBinding(TextBox.TextProperty, bindingArg1);
            this.txtArg2.SetBinding(TextBox.TextProperty, bindingArg2);
            this.txtResult.SetBinding(TextBox.TextProperty, bindingResult);

        }

    }
}
