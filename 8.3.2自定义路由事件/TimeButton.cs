using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _8._3._2自定义路由事件
{
    public class TimeButton : Button
    {
        //声明和注册路由事件
        /// <summary>
        /// 第一个参数：string类型，路由事件名称；
        /// 第二个参数：路由事件策略，WPF路由事件有三种路由策略：
        ///           1. Bubble: 冒泡式，路由事件的触发， 从事件触发者出发，向它的上级容器一层一层路由。
        ///           2. Tunnel: 隧道式，事件的路由方式与Bubble相反，由树根向事件触发的控件移动。
        ///           3. Direct: 直达式，模仿CLR直接事件，直接将事件处理消息送到事件处理器。
        /// 第三个参数：指定事件处理器类型，这里指定是自定义的事件参数。
        /// 第四个参数：指定路由事件的宿主（拥有者）是哪个类型。
        /// </summary>
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent
            ("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));
        //CLR事件包装器
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }
        //触发路由事件
        protected override void OnClick()
        {
            base.OnClick();

            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args); //
        }
    }
}
