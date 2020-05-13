using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _6._4._1Binding的数据校验
{
    public class RandValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double d = 0;
            if (double.TryParse(value.ToString(), out d))
            {
                if (d >=0 && d<=100)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "数据无效！");
        }
    }
}
