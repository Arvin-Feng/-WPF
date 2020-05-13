using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _6._5._1多路绑定
{
    public class LogonMutiBinding : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text=>string.IsNullOrEmpty(text)) 
                && values[0].ToString() == values[1].ToString()
                && values[2].ToString() == values[3].ToString())
            {
                return true;
            }
            return false;
        }

        //因为设置了Mode=BindingMode.OneWay属性， 所以这里不会被调用
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
