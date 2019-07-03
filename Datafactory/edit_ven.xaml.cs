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
    /// Interaction logic for edit_ven.xaml
    /// </summary>
    public partial class edit_ven : Window
    {
        public edit_ven()
        {
            InitializeComponent();
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM vendor WHERE VEN_ID ='" + userid.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();



            if (reader.Read())
            {
                cname.Text = (reader["VEN_CNAME"].ToString());
                address.Text = (reader["VEN_ADDRESS"].ToString());
                phone.Text = (reader["VEN_PHONE"].ToString());
                


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

            String sql = "UPDATE vendor SET VEN_CNAME='" + cname.Text + "',VEN_ADDRESS='" + address.Text + "',VEN_PHONE='" + phone.Text + "',' WHERE VEN_ID='" + userid.Text + "'";
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
