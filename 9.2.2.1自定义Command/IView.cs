using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._2._2._1自定义Command
{
    public interface IView
    {
        bool IsChanged { get; set; }
        void SetBinding();
        void Refresh();
        void Clear();
        void Save();
    }
}
