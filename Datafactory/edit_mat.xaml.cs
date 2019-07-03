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
    /// Interaction logic for edit_mat.xaml
    /// </summary>
    public partial class edit_mat : Window
    {
        public edit_mat()
        {
            InitializeComponent();
        }
        String type;
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql = "UPDATE materal SET M_NAME='" + name.Text + "',M_DESCRIPTION='" + disciption.Text + "',M_TYPE='" + type + "',M_UNIT='" + volume.Text + "',M_PPU='"+price.Text+"' WHERE M_ID='" + userid.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("แก้ไขเรียบร้อย");
            this.Close();
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM materal WHERE M_ID ='" + userid.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset = utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                String type = reader.GetString("M_TYPE");
                name.Text = (reader["M_NAME"].ToString());
                disciption.Text = (reader["M_DESCRIPTION"].ToString());
                price.Text = (reader["M_PPU"].ToString());
                volume.Text = (reader["M_UNIT"].ToString());
                if (type == "Chemical")
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
                disciption.Text = "";
                price.Text = "";
                volume.Text = "";
                tick1.IsChecked = false;
                tick2.IsChecked = false;
                

            }
        }

        private void tick1_Checked(object sender, RoutedEventArgs e)
        {
            type = "Chemical";
        }

        private void tick2_Checked(object sender, RoutedEventArgs e)
        {
            type = "Substrate";
        }
    }
}
