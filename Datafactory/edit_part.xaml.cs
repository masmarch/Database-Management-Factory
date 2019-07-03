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
    /// Interaction logic for edit_part.xaml
    /// </summary>
    public partial class edit_part : Window
    {
        public edit_part()
        {
            InitializeComponent();
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM partner WHERE PART_ID ='" + userid.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                cname.Text = (reader["PART_CNAME"].ToString());
                address.Text = (reader["PART_ADDRESS"].ToString());
                phone.Text = (reader["PART_PHONE"].ToString());
            
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
                cname.Text = "";
                address.Text = "";
                phone.Text = "";
              

            }
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {

            String sql = "UPDATE partner SET PART_CNAME='" + cname.Text + "',PART_ADDRESS='" + address.Text + "',PART_PHONE='" + phone.Text + "',' WHERE PART_ID='" + userid.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("แก้ไขเรียบร้อย");
            this.Close();
        }
    }
}
