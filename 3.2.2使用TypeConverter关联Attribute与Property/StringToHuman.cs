using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2._2使用TypeConverter关联Attribute与Property
{
    public class StringToHuman : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return new Human() { Name = value as string };
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
