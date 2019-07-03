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
    /// Interaction logic for edit_orderProduct.xaml
    /// </summary>
    public partial class edit_orderProduct : Window
    {
        public edit_orderProduct()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        MySqlDataAdapter da, da1;
        MySqlCommandBuilder cmd, cmd1;
        DataSet ds, ds1;

        private void success_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT OP_ID as รหัสใบสั่งเเม่พิมพ์,OP_DATE as วันสั่งทำ,OP_DATELINE as วันรับแม่พิมพ์,OP_PAYDAY as วันชำระค่าใช้จ่าย,OP_TOTAL as ราคาทั้งหมด,OP_STATUS as สถานะ,PART_ID as รหัสบริษัทสั่งทำ,EMP_ID as รหัสพนักงาน FROM order_product WHERE OP_STATUS != 'จ่ายเเล้ว'AND OP_ID ='"+qid.Text+"'";
            String sql2 = "SELECT P_ID as รหัสสินค้า,OP_ID as รหัสใบสั่งเเม่พิมพ์,DOP_NAME as ชื่อแม่พิมพ์,DOP_DESCRIPTION as รายละเอียด,DOP_UNIT as จำนวน,DOP_PRICE as ราคารวม FROM detail_orderproduct NATURAL JOIN order_product WHERE OP_STATUS != 'จ่ายเเล้ว'AND OP_ID ='" + qid.Text + "'";
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT OP_ID FROM order_product  WHERE OP_STATUS ='รอจ่าย'";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String quotation = reader.GetString("OP_ID");
                qid.Items.Add(quotation);
            }
            con3.Close();
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