using _15._1._1MVVM实例1.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._1._1MVVM实例1.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        #region 属性模型1 : 输入参数
        private double input1;
        public double Input1 
        {
            get { return input1; } 
            
            set
            {
                input1 = value;
                this.RaisePropertyChanged("Input1");
            }     
        }
        #endregion

        #region 属性模型2 : 输入参数
        private double input2;
        public double Input2
        {
            get { return input2; }

            set
            {
                input2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }
        #endregion

        #region 属性模型3 : 输出
        private double result;
        public double Result
        {
            get { return result; }

            set
            {
                result = value;
                this.RaisePropertyChanged("Result"); //告诉关联的Binding，数据值已经发生改变了。
            }
        }
        #endregion


        //命令属性
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        private void Add(object parameter)
        {
            this.Result = this.Input1 + this.Input2;
        }

        private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }

        public MainWindowViewModel()
        {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);

            this.SaveCommand = new DelegateCommand();
            this.SaveCommand.ExecuteAction += this.Save;

        }

    }
}
