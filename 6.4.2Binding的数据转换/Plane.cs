using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._4._2Binding的数据转换
{
    /// <summary>
    /// 飞机类型
    /// </summary>
    public enum Category
    {
        Bomber,
        Fighter
    }
    /// <summary>
    /// 飞机状态
    /// </summary>
    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class Plane
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }
}
