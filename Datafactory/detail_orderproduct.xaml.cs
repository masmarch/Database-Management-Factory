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
    /// Interaction logic for detail_orderproduct.xaml
    /// </summary>
    public partial class detail_orderproduct : Window
    {
        public detail_orderproduct(String text)
        {
            InitializeComponent();
            txt.Content = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT P_ID as รหัสสินค้า,OP_ID as รหัสใบสั่งทำแม่พิมพ์,DOP_NAME as ชื่อแม่พิมพ์,DOP_DESCRIPTION as รายละเอียด,DOP_UNIT as จำนวนที่สั่งทำ,DOP_PRICE as ราคารวม FROM detail_orderproduct WHERE OP_ID = '" + txt.Content + "'";
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
