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
    /// Interaction logic for edit_work.xaml
    /// </summary>
    public partial class edit_work : Window
    {
        public edit_work()
        {
            InitializeComponent();
        }

        MySqlConnection con;
        MySqlDataAdapter da, da1,da2;
        MySqlCommandBuilder cmd, cmd1,cmd2;
        DataSet ds, ds1,ds2;

        private void success_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT W_ID as รหัสใบสั่งงาน,W_DATE as วันสั่งงาน,W_DATELINE as วันปิดงาน,W_TOTAL as ราคา FROM work WHERE W_STATUS ='ดำเนินการ' AND W_ID = '" + qid.Text + "' ";
            String sql2 = "SELECT W_ID as รหัสใบสั่งงาน,Q_ID as รหัสใบเสนอราคา,P_ID as รหัสสินค้า,DWP_DESCRIPTION as รายละเอียด,DWP_UNIT as จำนวน,DWP_FPRICE as ราคารวม FROM detail_wproduct NATURAL JOIN work WHERE W_STATUS ='ดำเนินการ' AND W_ID = '"+qid.Text+"' ";
            String Sql3 = "SELECT W_ID as รหัสใบสั่งงาน,Q_ID as รหัสใบเสนอราคา,P_ID as รหัสสินค้า,M_ID as รหัสวัตถุดิบ,DWM_UNIT as จำนวน,DWM_PPU as ราคาวัตถุดิบต่อกิโลกรัม,DWM_TOTAL as ราคารวม,PMPU as วัตถุดิบที่ใช้ต่อชิ้น,PCOS as ราคาต้อนทุน FROM detail_wmateral WHERE W_ID = '" + qid.Text + "' ";
            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);
            da1 = new MySqlDataAdapter(sql2, con);
            da2 = new MySqlDataAdapter(Sql3, con);
            ds = new System.Data.DataSet();
            ds1 = new System.Data.DataSet();
            ds2 = new System.Data.DataSet();
            da.Fill(ds);
            da1.Fill(ds1);
            da2.Fill(ds2);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
            dataG1.ItemsSource = ds1.Tables[0].DefaultView;
            dataG2.ItemsSource = ds2.Tables[0].DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT W_ID FROM  work  WHERE W_STATUS ='ดำเนินการ'";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String quotation = reader.GetString("W_ID");
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
            cmd2 = new MySqlCommandBuilder(da2);
            da2.Update(ds2);
            MessageBox.Show("แก้ไขเรียบร้อย");
        }
    }
}
