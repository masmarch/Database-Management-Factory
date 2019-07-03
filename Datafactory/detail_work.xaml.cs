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
    /// Interaction logic for detail_work.xaml
    /// </summary>
    public partial class detail_work : Window
    {
        public detail_work(String text)
        {
            InitializeComponent();
            txt.Content = text;
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
                String sql = "SELECT W_ID as รหัสใบสั่งงาน,Q_ID as รหัสใบเสนอราคา,P_ID as รหัสสินค้า,M_ID as รหัสวัตถุดิบ,DWM_UNIT as จำนวนวัตถุดิบที่ใช้,DWM_PPU as ราคาต่อกิโลกรัม,DWM_TOTAL as ราคารวม,PMPU as จำที่ใช่ต่อชิ้น,PCOS as ราคาต่อชิ้น FROM detail_wmateral WHERE W_ID = '"+txt.Content+"'";
                String sql1 = "SELECT  W_ID as รหัสใบสั่งงาน,Q_ID as รหัสใบเสนอราคา,P_ID as รหัสสินค้า,DWP_DESCRIPTION as รายละเอียด,DWP_TYPE as ประเภท,DWP_UNIT as จำนวน,DWP_FPRICE as ราคาขาย FROM detail_wproduct WHERE W_ID = '" + txt.Content + "'";
                MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                con.Open();
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da.Fill(ds);
                da1.Fill(ds1);
                detailG.ItemsSource = ds.Tables[0].DefaultView;
                detailG2.ItemsSource = ds1.Tables[0].DefaultView;
                con.Close();            
                        
                
           
        }
    }
}
