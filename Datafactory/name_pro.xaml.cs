using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Datafactory
{
    /// <summary>
    /// Interaction logic for name_pro.xaml
    /// </summary>
    public partial class name_pro : Page
    {
        public name_pro()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT P_ID as รหัสสินค้า ,P_NAME as ชื่อสินค้า, P_DESCRIPTION as รายละเอียด,P_TYPE as ประเภท , P_BPPU as ราคาต้นทุน,P_FPPU as ราคาขาย FROM product WHERE P_NAME ='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            matG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            String sql  = "SELECT P_ID as รหัสสินค้า ,P_NAME as ชื่อสินค้า, P_DESCRIPTION as รายละเอียด,P_TYPE as ประเภท , P_BPPU as ราคาต้นทุน,P_FPPU as ราคาขาย FROM product";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            matG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
