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
    /// Interaction logic for detailOrderMateral.xaml
    /// </summary>
    public partial class detailOrderMateral : Window
    {
        public detailOrderMateral(String text)
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
            String sql = "SELECT M_ID as รหัสวัตถุดิบ,ORM_ID as รหัสใบสั่งวัตถุดิบ,DOM_NAME as ชื่อวัตถุดิบ,DOM_DESCRIPTION as รายละเอียด,DOM_TYPE as ประเภท,DOM_UNIT as จำนวน,DOM_PPU as ราคาต่อกิโลกรัม FROM detail_ordermateral WHERE ORM_ID ='"+txtadd.Content+"' ";
            
            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);            
            ds = new System.Data.DataSet();            
            da.Fill(ds);           
            dataG.ItemsSource = ds.Tables[0].DefaultView;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Double sum = 0;
            cmd = new MySqlCommandBuilder(da);
            da.Update(ds);
            String sql1 = "SELECT SUM(DOM_UNIT*DOM_PPU) FROM detail_ordermateral WHERE ORM_ID = '" + txtadd.Content + "'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                sum += Double.Parse(reader.GetString(0));
            }
            Double vat = (7 / 100) * sum;
            Double sumvat = sum + vat;
            String sql2 = "UPDATE order_materal SET ORM_TOTAL = '" + sum + "',ORM_TOTALVAT ='"+sumvat+"' WHERE ORM_ID = '" + txtadd.Content + "' ";
            MySqlConnection con2 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();
            MessageBox.Show("เรียบร้อย");
            this.Close();
            
        }

        private void domfind_Click(object sender, RoutedEventArgs e)
        {
            find_ordermateral fd = new find_ordermateral();
            fd.Show();
        }
    }
}
