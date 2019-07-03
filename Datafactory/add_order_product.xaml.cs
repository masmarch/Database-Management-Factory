using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datafactory
{
    /// <summary>
    /// Interaction logic for add_order_product.xaml
    /// </summary>
    public partial class add_order_product : Page
    {
        public add_order_product()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            String sql1 = "SELECT * FROM partner  ";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String part = reader.GetString("PART_ID");
                partid.Items.Add(part);
            }
        }
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sqlx = "SELECT OP_ID FROM order_product WHERE OP_ID = '" + opid.Text + "'";
            MySqlConnection conx = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmdx = new MySqlCommand(sqlx, conx);
            conx.Open();
            MySqlDataReader readerx = cmdx.ExecuteReader();
            if (readerx.Read() || opid.Text == "")
            {
                MessageBox.Show("ซ้ำโปรดกรอกใหม่");
                opid.Text = "";
                opdate.Text = "";
                opdateline.Text = "";
                oppayday.Text = "";
                empid.Text = "";
            }
            else
            {
                String sql3 = "SELECT * FROM partner WHERE PART_ID = '" + partid.Text + "' ";
                MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
                con3.Open();
                MySqlDataReader reader3 = cmd3.ExecuteReader();
                if (reader3.Read())
                {
                    String sql1 = "SELECT EMP_ID FROM employee WHERE EMP_ID = '" + empid.Text + "' ";
                    MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    con.Open();
                    MySqlDataReader reader = cmd1.ExecuteReader();

                    if (reader.Read())
                    {

                        String sql = "INSERT INTO order_product VALUES('" + opid.Text + "','" + opdate.DisplayDate.ToString("yyyy-MM-dd") + "','" + opdateline.DisplayDate.ToString("yyyy-MM-dd") + "','" + oppayday.DisplayDate.ToString("yyyy-MM-dd") + "'" +
                           ",'0.00','รอจ่าย','" + partid.Text + "','" + empid.Text + "') ";
                        MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                        MySqlCommand cmd = new MySqlCommand(sql, con1);
                        con1.Open();
                        cmd.ExecuteNonQuery();
                        con1.Close();
                        MessageBox.Show("เรียบร้อย");
                        deetailOderProduct dp = new deetailOderProduct(opid.Text);
                        dp.Show();

                    }
                    else
                    {
                        MessageBox.Show("รหัสพนักงานผิดพลาด");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสบริษัททำของ");
                }
            }
            
        }

    }
}
