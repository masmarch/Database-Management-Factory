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
    /// Interaction logic for detail_ordermateral.xaml
    /// </summary>
    public partial class detail_ordermateral : Window
    {
        public detail_ordermateral(String text)
        {
            InitializeComponent();
            txt.Content = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            String sql = "SELECT ORM_ID as รหัสใบสั่งซื้อวัตถุดิบ,M_ID as รหัสวัตถุดิบ,DOM_NAME as ชื่อวัตถุดิบ,DOM_DESCRIPTION as รายละเอียด,DOM_TYPE as ประเภท,DOM_UNIT as จำนวนที่ซื้อ,DOM_PPU as ราคาต่อกิโลกรัม FROM detail_ordermateral WHERE ORM_ID = '" + txt.Content + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();            
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);          
            da.Fill(ds);            
            detailG.ItemsSource = ds.Tables[0].DefaultView;           
            con.Close();
        }
    }
}
