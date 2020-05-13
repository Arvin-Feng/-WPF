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
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace _6._3._10使用LINQ结果作为Binding的源
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region 1. LINQ从List对象查找以A开头的对象
            //List<Student> stuList = new List<Student>()
            //{
            //    new Student(){sZYH = "1300008", sXM = "A", sNL = "29", sCH = "01", sBRBMMC = "外科"},
            //    new Student(){sZYH = "1300009", sXM = "AB", sNL = "30", sCH = "02", sBRBMMC = "外科"},
            //    new Student(){sZYH = "1300010", sXM = "C", sNL = "31", sCH = "03", sBRBMMC = "外科"},
            //    new Student(){sZYH = "1300011", sXM = "D", sNL = "32", sCH = "04", sBRBMMC = "外科"},
            //    new Student(){sZYH = "1300012", sXM = "E", sNL = "33", sCH = "05", sBRBMMC = "外科"},
            //};
            ////找到有A开头的学生
            //this.listViewStu.ItemsSource = from a in stuList where a.sXM.StartsWith("A") select a;
            #endregion

            #region 2. LINQ从DataTable对象里面查找
            //string stringConn = @"Server=.\hans;DataBase=HIS_BZ;Uid=sa;Pwd=123";
            //SqlConnection conn = new SqlConnection(stringConn);
            //SqlCommand cmd = new SqlCommand("SELECT sXM, sCH, sZYH, sNL, sBRBMMC　FROM HIS_ZY..ZYBRJBXXB", conn);
            //SqlDataAdapter sdp = new SqlDataAdapter(cmd);
            //DataTable table = new DataTable();
            //conn.Open();
            //sdp.Fill(table);
            //conn.Close();

            //this.listViewStu.ItemsSource =
            //    from row in table.Rows.Cast<DataRow>()
            //    where row["sBRBMMC"].Equals("内一科")
            //    select new Student()
            //    {
            //        sXM = row["sXM"].ToString(),
            //        sCH = row["sCH"].ToString(),
            //        sZYH = row["sZYH"].ToString(),
            //        sNL = row["sNL"].ToString(),
            //        sBRBMMC = row["sBRBMMC"].ToString()
            //    };
            #endregion

            #region 3. LINQ从xml读取
            XDocument xdoc = XDocument.Load(@"..\..\XMLFile1.xml");
            this.listViewStu.ItemsSource =
                from element in xdoc.Descendants("Student")
                where element.Attribute("sBRBMMC").Value.Equals("内二科")
                select new Student()
                {
                    sXM = element.Attribute("sXM").Value,
                    sCH = element.Attribute("sCH").Value,
                    sBRBMMC = element.Attribute("sBRBMMC").Value,
                    sZYH = element.Attribute("sZYH").Value
                };
            //SELECT sXM, sCH, sZYH, sNL, sBRBMMC　FROM HIS_ZY..ZYBRJBXXB
            #endregion

        }
    }
}
