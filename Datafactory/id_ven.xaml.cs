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
    /// Interaction logic for id_venxaml.xaml
    /// </summary>
    public partial class id_venxaml : Page
    {
        public id_venxaml()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT VEN_ID as รหัสบรืษัท,VEN_CNAME as ชื่อบริษัท,VEN_ADDRESS as ที่อยู่,VEN_PHONE as เบอร์ติดต่อ FROM vendor WHERE VEN_ID ='" + txtsearch.Text + "'";
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
            String sql = "SELECT VEN_ID as รหัสบรืษัท,VEN_CNAME as ชื่อบริษัท,VEN_ADDRESS as ที่อยู่,VEN_PHONE as เบอร์ติดต่อ FROM vendor";

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
