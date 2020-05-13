using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6._3._12RelativeSource
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //不确定数据源的名字叫什么， 但可以通过xaml的结构查找到， 比如： 查询上一层的gird类型的元素的Name，
            //这时可以是使用RelativeSource绑定。

            //从txtBox的的第一层开始，从内向外查找第一个grid，并且把grid的name属性绑定给textBox的Text

            //1. 查找第一层的grid对象
            //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            //rs.AncestorLevel = 1;
            //rs.AncestorType = typeof(Grid);

            //2. 查找第二层的DockPanel对象
            //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            //rs.AncestorLevel = 2;
            //rs.AncestorType = typeof(DockPanel);

            //3. 查找自己的name
            RelativeSource rs = new RelativeSource();
            rs.Mode = RelativeSourceMode.Self;

            Binding binding = new Binding("Name") { RelativeSource = rs};
            this.txtBox.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
