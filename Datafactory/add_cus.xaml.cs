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
    /// Interaction logic for add_cus.xaml
    /// </summary>
    public partial class add_cus : Page
    {
        public add_cus()
        {
            InitializeComponent();
        }
        string sex;
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql = "INSERT INTO customer VALUES('" + userid.Text + "','" + cname.Text + "','" + address.Text + "','" + phone.Text + "','" + sex + "') ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("เรียบร้อย");

            this.NavigationService.Navigate(new Uri("id_cus.xaml", UriKind.RelativeOrAbsolute));
        }

        private void emp1_Checked(object sender, RoutedEventArgs e)
        {
            sex = "พนักงานประจำ";
        }

        private void emp2_Checked(object sender, RoutedEventArgs e)
        {
            sex = "อัตราจ้าง";
        }

        private void emp3_Checked(object sender, RoutedEventArgs e)
        {
            sex = "ลาออก";
        }
    }
}
