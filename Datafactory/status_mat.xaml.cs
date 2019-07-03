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
    /// Interaction logic for status_mat.xaml
    /// </summary>
    public partial class status_mat : Page
    {
        public status_mat()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT M_ID as รหัสวัตถุดิบ,M_NAME as ชือวัตถุดิบ,M_DESCRIPTION as รายละเอีนด, M_TYPE as ประเภท,M_UNIT as จำนวนหน่วยกิโลกรัม,M_PPU as ราคาต่อกิโลกรัม FROM materal WHERE M_TYPE ='" + txtsearch.Text + "'";
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
            String sql = "SELECT M_ID as รหัสวัตถุดิบ,M_NAME as ชือวัตถุดิบ,M_DESCRIPTION as รายละเอีนด, M_TYPE as ประเภท,M_UNIT as จำนวนหน่วยกิโลกรัม,M_PPU as ราคาต่อกิโลกรัม FROM materal";

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
