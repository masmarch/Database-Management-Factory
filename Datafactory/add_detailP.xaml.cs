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
    /// Interaction logic for add_detailP.xaml
    /// </summary>
    public partial class add_detailP : Window
    {
        public add_detailP(String text)
        {
            InitializeComponent();
            txtadd.Content = text;
        }
        public static int count;

        MySqlConnection con;
        MySqlDataAdapter da,da1;
        MySqlCommandBuilder cmd,cmd1;
        DataSet ds,ds1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                  

            String sql3 = "SELECT QUO_ID FROM quotation NATURAL JOIN job  WHERE JOB_STATUS ='ดำเนินการ' ";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3= new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String quotation= reader.GetString("QUO_ID");
                qid.Items.Add(quotation);
            }

            String sql = "SELECT W_ID as รหัสใบสั่งงาน,Q_ID as รหัสใบเสนอราคา,P_ID as สินค้า,DWP_DESCRIPTION as รายละเอียด,DWP_TYPE as ประเภท,DWP_UNIT as จำนวน,DWP_FPRICE as ราคาขาย FROM detail_wproduct WHERE Q_ID = '"+qid.Text+"' ";
            String sql2 = "SELECT W_ID as รหัสใบสั่งงาน,Q_ID as รหัสใบเสนอราคา,P_ID as สินค้า,M_ID as รหัสวัตถุดิบ,DWM_UNIT as จำนวน,DWM_PPU as ราคาต่อกิโลกรัม,DWM_TOTAL as ราคารวมวัตถุดิบ,PMPU as จำนวนที่ใช้ต่อชิ้น,PCOS as ราคาต่อชิ้น FROM detail_wmateral WHERE Q_ID = '"+qid.Text+"'";
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


        private void find_Click(object sender, RoutedEventArgs e)
        {
            find_detail_job fj = new find_detail_job(qid.Text);
            fj.Show();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             if(price.Text != "")
             {
                Double p=0;
                cmd = new MySqlCommandBuilder(da);
                da.Update(ds);
                cmd1 = new MySqlCommandBuilder(da1);
                da1.Update(ds1);
                p += Double.Parse(price.Text);

                
                String sql = "UPDATE work SET W_TOTAL = '"+p+"' WHERE W_ID ='"+txtadd.Content+"'";
                MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cm = new MySqlCommand(sql, con);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("เรียบร้อย");
                
             }
            else
            {
                MessageBox.Show("กรุณาใส่ราคางาน");
            }
            

        }
    }
}