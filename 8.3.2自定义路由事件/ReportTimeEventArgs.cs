using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _8._3._2自定义路由事件
{
    class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, object source) 
            : base(routedEvent, source)
        {

        }

        public DateTime ClickTime { get; set; }

    }
}
