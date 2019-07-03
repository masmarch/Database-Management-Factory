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
    /// Interaction logic for deetailOderProduct.xaml
    /// </summary>
    public partial class deetailOderProduct : Window
    {
        public deetailOderProduct(String text)
        {
            InitializeComponent();
            txtadd.Content = text;
        }
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommandBuilder cmd;
        DataSet ds;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT P_ID as รหัสสินค้า,OP_ID as รหัสใบสั่งทำแม่พิมพ์,DOP_NAME as ชื่อแม่พิมพ์,DOP_DESCRIPTION as รายละเอียด,DOP_UNIT as จำนวน,DOP_PRICE as ราคา FROM detail_orderproduct WHERE OP_ID ='" + txtadd.Content + "' ";

            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
        }

            //cmd1.ExecuteNonQuery();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Double sum = 0;
            cmd = new MySqlCommandBuilder(da);
            da.Update(ds);

            String sql1 = "SELECT SUM(DOP_UNIT * DOP_PRICE) FROM detail_orderproduct WHERE OP_ID = '" + txtadd.Content + "'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                sum += Double.Parse(reader.GetString(0));
            }
            String sql2 = "UPDATE order_product SET OP_TOTAL = '" + sum + "' WHERE OP_ID = '" + txtadd.Content + "' ";
            MySqlConnection con2 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();

            MessageBox.Show("เรียบร้อย");
            this.Close();
        }

        private void dopfind_Click(object sender, RoutedEventArgs e)
        {
            find_product fd = new find_product();
            fd.Show();
        }
    }
}
