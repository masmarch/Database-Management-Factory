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
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
        public menu(String text)
        {
            InitializeComponent();
            txtHello.Content = text;
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT EMP_FNAME,EMP_LNAME,EMP_STATUS FROM employee WHERE EMP_ID = '" + txtHello.Content + "' ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fname.Content = reader.GetString("EMP_FNAME")+"    "+reader.GetString("EMP_LNAME");
                status_user.Content = reader.GetString("EMP_STATUS");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fuc_emp fe = new fuc_emp();
            fe.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fuc_cus fc = new fuc_cus();
            fc.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            fuc_file fc = new fuc_file();
            fc.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            fuc_ven fc = new fuc_ven();
            fc.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            fuc_part fc = new fuc_part();
            fc.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            fuc_mat fc = new fuc_mat();
            fc.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            fuc_pro fc = new fuc_pro();
            fc.Show();
            this.Close();
        }
    }
}
