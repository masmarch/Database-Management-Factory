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
    /// Interaction logic for name_cus.xaml
    /// </summary>
    public partial class name_cus : Page
    {
        public name_cus()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT CUS_ID as รหัสลูกค้า,CUS_CNAME as ชื่อบริษัท,CUS_ADDRESS as ที่อยู่,CUS_PHONE as เบอร์ติดต่อ,CUS_STATUS as สถานะ FROM customer WHERE CUS_CNAME ='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            cusG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT CUS_ID as รหัสลูกค้า,CUS_CNAME as ชื่อบริษัท,CUS_ADDRESS as ที่อยู่,CUS_PHONE as เบอร์ติดต่อ,CUS_STATUS as สถานะ FROM customer";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            cusG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
