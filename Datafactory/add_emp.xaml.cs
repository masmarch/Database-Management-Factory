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
    /// Interaction logic for add_emp.xaml
    /// </summary>
    public partial class add_emp : Page
    {
        public add_emp()
        {
            InitializeComponent();
        }
        public static string txthead = "";
        String sex;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            head.Content = txthead;
            String sql1 = "SELECT * FROM department  ";

            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String depart = reader.GetString("DEP_ID");
                dep.Items.Add(depart);
            }
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            String sql = "INSERT INTO employee VALUES('" + userid.Text + "','" + dep.Text + "','" + name.Text + "','" + surname.Text + "','" + address.Text + "','" + phone.Text + "','" + password.Password + "','" + sex + "') ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("เรียบร้อย");            
            this.NavigationService.Navigate(new Uri("id_emp.xaml", UriKind.RelativeOrAbsolute));
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
