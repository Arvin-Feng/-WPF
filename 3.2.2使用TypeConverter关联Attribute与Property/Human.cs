using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2._2使用TypeConverter关联Attribute与Property
{
    [TypeConverter(typeof(StringToHuman))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }
    }
}
