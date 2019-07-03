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
using System.Windows.Shapes;

namespace Datafactory
{
    /// <summary>
    /// Interaction logic for edit_materal.xaml
    /// </summary>
    public partial class edit_materal : Window
    {
        public edit_materal()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        MySqlDataAdapter da, da1;
        MySqlCommandBuilder cmd, cmd1;
        DataSet ds, ds1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT ORM_ID FROM order_materal WHERE ORM_STATUS ='รอจ่าย' ";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String mat = reader.GetString("ORM_ID");
                qid.Items.Add(mat);
            }
            
        }

        private void success_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT ORM_ID as รหัสใบสั่งวัตถุดิบ,ORM_DATE as วันสั่งซื้อ,ORM_DATELINE as วันรับวัตถุดิบ,ORM_PAYDAY as วันชำระค่าใช้จ่าย,ORM_TOTAL as ราคาทั้งหมด,ORM_STATUS as สถานะ,EMP_ID as รหัสพนักงาน,VEN_ID as รหัสบริษัทวัตถุดิบ FROM order_materal WHERE ORM_STATUS != 'จ่ายเเล้ว'AND ORM_ID ='"+qid.Text+"'";
            String sql2 = "SELECT ORM_ID as รหัสใบสั่งวัตถุดิบ,M_ID as รหัสวัตถุดิบ,DOM_NAME as ชื่อแม่พิมพ์,DOM_DESCRIPTION as รายละเอียด,DOM_TYPE as ประเภท,DOM_UNIT as จำนวนที่ซื้อ,DOM_PPU as ราคาต่อกิโลกรัม FROM detail_ordermateral NATURAL JOIN order_product WHERE OP_STATUS != 'จ่ายเเล้ว'AND ORM_ID ='"+qid.Text+"'";
            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);
            da1 = new MySqlDataAdapter(sql2, con);
            ds = new System.Data.DataSet();
            ds1 = new System.Data.DataSet();
            da.Fill(ds);
            da1.Fill(ds1);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
            dataG1.ItemsSource = ds1.Tables[0].DefaultView;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cmd = new MySqlCommandBuilder(da);
            da.Update(ds);
            cmd1 = new MySqlCommandBuilder(da1);
            da1.Update(ds1);
            MessageBox.Show("แก้ไขเรียบร้อย");
        }
    }
}
