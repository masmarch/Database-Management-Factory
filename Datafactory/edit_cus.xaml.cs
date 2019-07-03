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
    /// Interaction logic for edit_cus.xaml
    /// </summary>
    public partial class edit_cus : Window
    {
        public edit_cus()
        {
            InitializeComponent();
        }
        String sex;

        private void show_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM customer WHERE CUS_ID ='" + userid.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();



            if (reader.Read())
            {
                String type = reader.GetString("CUS_STATUS");
                cname.Text = (reader["CUS_CNAME"].ToString());
                address.Text = (reader["CUS_ADDRESS"].ToString());                
                phone.Text = (reader["CUS_PHONE"].ToString());
                if (type == "ลูกค้าประจำ")
                {
                    emp1.IsChecked = true;
                }
                else if (type == "ลูกค้ารายใหม่")
                {
                    emp2.IsChecked = true;
                }
                else
                {
                    emp3.IsChecked = true;
                }


            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
                cname.Text = "";
                address.Text = "";                
                phone.Text = "";
                emp1.IsChecked = false;
                emp2.IsChecked = false;
                emp3.IsChecked = false;

            }
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql = "UPDATE customer SET CUS_CNAME='" + cname.Text + "',CUS_ADDRESS='" + address.Text + "',CUS_PHONE='" + phone.Text + "',CUS_STATUS='" + sex + "' WHERE CUS_ID='" + userid.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("แก้ไขเรียบร้อย");
            this.Close();
        }

        private void emp1_Checked(object sender, RoutedEventArgs e)
        {
            sex = "ลูกค้าประจำ";
        }

        private void emp2_Checked(object sender, RoutedEventArgs e)
        {
            sex = "ลูกค้ารายใหม่";
        }

        private void emp3_Checked(object sender, RoutedEventArgs e)
        {
            sex = "ยกเลิก";
        }
    }
}
