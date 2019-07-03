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
    /// Interaction logic for find_product.xaml
    /// </summary>
    public partial class find_product : Window
    {
        public find_product()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT P_ID as รหัสสินค้า,P_NAME as ชื่อสินค้า,P_DESCRIPTION as รายละเอียด,P_TYPE as ประเภท,P_FPPU as ราคาขาย FROM product WHERE P_TYPE ='แม่พิมพ์'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
