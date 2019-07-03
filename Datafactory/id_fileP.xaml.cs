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
    /// Interaction logic for id_fileP.xaml
    /// </summary>
    public partial class id_fileP : Page
    {
        public id_fileP()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT OP_ID as รหัสใบสั้งทำแม่พิมพ์,OP_DATE as วันสั่งทำแม่พิมพ์,OP_DATELINE as วันรับแม่พิมพ์,OP_PAYDAY as วันจ่าย ,OP_TOTAL as ราคาทั้งหมด,OP_STATUS as สถานะ ,PART_ID as รหัสบริษัททำแม่พิมพ์,EMP_ID as รหัสพนักงาน FROM order_product WHERE OP_ID ='" + txtsearch.Text + "'";
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
            String sql = "SELECT OP_ID as รหัสใบสั้งทำแม่พิมพ์,OP_DATE as วันสั่งทำแม่พิมพ์,OP_DATELINE as วันรับแม่พิมพ์,OP_PAYDAY as วันจ่าย ,OP_TOTAL as ราคาทั้งหมด,OP_STATUS as สถานะ ,PART_ID as รหัสบริษัททำแม่พิมพ์,EMP_ID as รหัสพนักงาน FROM order_product";

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
            String sql = "SELECT OP_ID as รหัสใบสั้งทำแม่พิมพ์,OP_DATE as วันสั่งทำแม่พิมพ์,OP_DATELINE as วันรับแม่พิมพ์,OP_PAYDAY as วันจ่าย ,OP_TOTAL as ราคาทั้งหมด,OP_STATUS as สถานะ ,PART_ID as รหัสบริษัททำแม่พิมพ์,EMP_ID as รหัสพนักงาน FROM order_product WHERE OP_ID='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                detail_orderproduct dp = new detail_orderproduct(txtsearch.Text);
                dp.Show();
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
