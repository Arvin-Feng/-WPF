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

namespace _6._4._1Binding的数据校验
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region 1. 校验数据合法性【ValidationRule】， 当录入的数据不是整数类型时，会返回错误， 现在界面上就是一个红色框框，说明输入有误。必须从ValidationRule继承。
            Binding binding = new Binding("Value") { Source = this.slider1 };
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //基础至ValidationRule类， 并且现实ValidationResult方法
            RandValidationRule rvr = new RandValidationRule();
            binding.ValidationRules.Add(rvr);
            this.txtBox.SetBinding(TextBox.TextProperty, binding);
            #endregion

            #region 2. 监听错误信息，以上只是界面上会显示红色框框， 如果想接收到错误信息，需求实现监听器回调函数
            //Binding bd = new Binding("Value") { Source = this.slider1};
            //bd.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //RandValidationRule rvr = new RandValidationRule();
            //bd.ValidationRules.Add(rvr);
            //rvr.ValidatesOnTargetUpdated = true;
            //bd.NotifyOnValidationError = true;
            //this.txtBox.SetBinding(TextBox.TextProperty, bd);

            ////监听函数
            //this.txtBox.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));

            #endregion

        }

        void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.txtBox).Count > 0)
            {
                this.txtBox.ToolTip = Validation.GetErrors(this.txtBox)[0].ErrorContent.ToString();
            }
        }

    }
}
