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
using System.Windows.Shapes;

namespace Datafactory
{
    /// <summary>
    /// Interaction logic for edit_product.xaml
    /// </summary>
    public partial class edit_product : Window
    {
        public edit_product()
        {
            InitializeComponent();
        }
        String type;

        private void show_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM product WHERE P_ID ='" + userid.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                String type = reader.GetString("P_TYPE");
                name.Text = (reader["P_NAME"].ToString());
                description.Text = (reader["P_DESCRIPTION"].ToString());
                bsell.Text = (reader["P_BPPU"].ToString());
                fsell.Text = (reader["P_FPPU"].ToString());
                if (type == "ชิ้นงาน")
                {
                    tick1.IsChecked = true;
                }
                else
                {
                    tick2.IsChecked = true;
                }


            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
                name.Text = "";
                description.Text = "";
                fsell.Text = "";
                bsell.Text = "";
                tick1.IsChecked = false;
                tick2.IsChecked = false;


            }
        }


        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql = "UPDATE product SET P_NAME='" + name.Text + "',P_DESCRIPTION='" + description.Text + "',P_TYPE='" + type + "',P_BPPU='" + bsell.Text + "',P_FPPU='" + fsell.Text + "' WHERE P_ID='" + userid.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("แก้ไขเรียบร้อย");
            this.Close();
        }
        private void tick1_Checked(object sender, RoutedEventArgs e)
        {
            type = "ชิ้นงาน";
        }

        private void tick2_Checked(object sender, RoutedEventArgs e)
        {
            type = "แม่พิมพ์";
        }
    }
}
