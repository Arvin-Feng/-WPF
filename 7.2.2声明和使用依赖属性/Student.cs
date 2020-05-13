using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _7._2._2声明和使用依赖属性
{
    public class Student : DependencyObject
    {
        public static readonly DependencyProperty NameProperty = 
            DependencyProperty.Register("Name", typeof(string), typeof(Student));
    }
}
