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
    /// Interaction logic for id_fileV.xaml
    /// </summary>
    public partial class id_fileV : Page
    {
        public id_fileV()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT ORM_ID as รหัสวัตถุดิบ,ORM_DATE as วันสั่งวัตถุดิบ,ORM_DATELINE as วันรับของ,ORM_PAYDAY as วันจ่าย,ORM_TOTAL as ราคา,ORM_TOTALVAT as ราคารวมภาษี,ORM_STATUS as สถานะ,EMP_ID as รหัสพนักงาน,VEN_ID as รหัสบริษัทสั่งของ FROM order_materal WHERE ORM_ID ='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            fileG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT ORM_ID as รหัสวัตถุดิบ,ORM_DATE as วันสั่งวัตถุดิบ,ORM_DATELINE as วันรับของ,ORM_PAYDAY as วันจ่าย,ORM_TOTAL as ราคา,ORM_TOTALVAT as ราคารวมภาษี,ORM_STATUS as สถานะ,EMP_ID as รหัสพนักงาน,VEN_ID as รหัสบริษัทสั่งของ FROM order_materal";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            fileG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT ORM_ID as รหัสวัตถุดิบ,ORM_DATE as วันสั่งวัตถุดิบ,ORM_DATELINE as วันรับของ,ORM_PAYDAY as วันจ่าย,ORM_TOTAL as ราคา,ORM_TOTALVAT as ราคารวมภาษี,ORM_STATUS as สถานะ,EMP_ID as รหัสพนักงาน,VEN_ID as รหัสบริษัทสั่งของ FROM order_materal WHERE ORM_ID='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                detail_ordermateral dm = new detail_ordermateral(txtsearch.Text);
                dm.Show();
            }
            else if (txtsearch.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล");
            }
            else
            {
                MessageBox.Show("ข้อมูลผิดพลาด");
            }
        }
    }
}
