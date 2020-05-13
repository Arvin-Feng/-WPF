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

namespace _9._1._3._1命令
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }
        /// <summary>
        /// 注意的记得：
        /// 1. RoutedCommand只负责在程序中“跑腿”，不会直接
        /// 对命令目标进行任何操作；
        /// 2. CanExecute事件触发频率比较高， 所以在处理完成后建议设置e.Handled = true；
        /// 3. CommandBinding一定要设置在命令目标的外围控件上，否则无法捕捉到CanExecute、Executed等路由事件
        /// </summary>


        //声明并定义命令。  系统也预定义了一些命令， 如Open、Save等这些就不需要自己定义了， 拿来直接用。
        private RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(MainWindow));

        private void InitializeCommand()
        {
            //把命令赋值给命令源（发送者）并指定快捷键
            this.btn1.Command = this.clearCmd;
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            //指定命令目标
            this.btn1.CommandTarget = this.txt1;
            //创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCmd; //只关注与clearCmd相关的事件
            cb.CanExecute += Cb_CanExecute;
            cb.Executed += Cb_Executed;
            //把命令关联在外围控件上
            this.skRoot.CommandBindings.Add(cb);
        }

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.txt1.Clear();
            //避免继续上传而降低程序性能
            e.Handled = true;
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
            //避免继续上传而降低程序性能
            e.Handled = true;
        }
    }
}
