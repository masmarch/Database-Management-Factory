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
    /// Interaction logic for add_product.xaml
    /// </summary>
    public partial class add_product : Page
    {
        public add_product()
        {
            InitializeComponent();
        }
        String sex;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String sql1 = "SELECT P_ID FROM product WHERE P_ID = '"+pid.Text+"'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read() && pid.Text =="")
            {
                MessageBox.Show("ซ้ำโปรดกรอกใหม่");
                pid.Text = "";
            }
            else
            {
                String sql = "INSERT INTO product VALUES('" + pid.Text + "','" + name1.Text + "','" + detail.Text + "','" + sex + "','" + bprice.Text + "','" + fprice.Text + "') ";
                MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("เรียบร้อย");
                this.NavigationService.Navigate(new Uri("id_pro.xaml", UriKind.RelativeOrAbsolute));
            }

            
        }

        private void emp1_Checked(object sender, RoutedEventArgs e)
        {
            sex = "ชิ้นงาน";
        }

        private void emp2_Checked(object sender, RoutedEventArgs e)
        {
            sex = "แม่พิมพ์";
        }

    }
}
