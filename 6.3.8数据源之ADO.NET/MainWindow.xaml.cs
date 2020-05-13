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

namespace _6._3._8数据源之ADO.NET
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
            string sql = "SELECT sXM, sCH, sZYH, sNL, dRYSJ　FROM HIS_ZY..ZYBRJBXXB";
            string connString = @"Server=.\hans;DataBase=HIS_BZ;Uid=sa;Pwd=123";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            conn.Open();
            da.Fill(dataTable);
            conn.Close();
            //绑定到ListBox
            this.listStu.ItemsSource = dataTable.DefaultView;
            this.listStu.DisplayMemberPath = "sXM";
            //绑定到ListView
            this.listViewStu.ItemsSource = dataTable.DefaultView;
        }
    }
}
