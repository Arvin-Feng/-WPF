using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _9._2._2._1自定义Command
{
    public class ClearCommand : ICommand
    {
        //当命令可执行状态发生变化时，被触发。
        public event EventHandler CanExecuteChanged;
        //用于判断命令是否可执行（暂不实现）
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            if (view != null)
            {
                view.Clear();
            }
        }
    }
}
