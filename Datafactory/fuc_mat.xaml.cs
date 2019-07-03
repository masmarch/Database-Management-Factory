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
    /// Interaction logic for fuc_mat.xaml
    /// </summary>
    public partial class fuc_mat : Window
    {
        public fuc_mat()
        {
            InitializeComponent();
        }

        private void employee_Click(object sender, RoutedEventArgs e)
        {
            fuc_emp fe = new fuc_emp();
            fe.Show();
            this.Close();
        }
        private void customer_Click(object sender, RoutedEventArgs e)
        {
            fuc_cus fc = new fuc_cus();
            fc.Show();
            this.Close();
        }

        private void file_Click(object sender, RoutedEventArgs e)
        {
            fuc_file ff = new fuc_file();
            ff.Show();
            this.Close();
        }

        private void vendor_Click(object sender, RoutedEventArgs e)
        {
            fuc_ven fv = new fuc_ven();
            fv.Show();
            this.Close();
        }

        private void partner_Click(object sender, RoutedEventArgs e)
        {
            fuc_part fp = new fuc_part();
            fp.Show();
            this.Close();
        }

        private void product_Click(object sender, RoutedEventArgs e)
        {
            fuc_pro fd = new fuc_pro();
            fd.Show();
            this.Close();
        }

        private void mat1_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_mat.xaml", UriKind.RelativeOrAbsolute));
        }

        private void mat2_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("name_mat.xaml", UriKind.RelativeOrAbsolute));
        }

        private void mat3_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("status_mat.xaml", UriKind.RelativeOrAbsolute));
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_mat.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            edit_mat em = new edit_mat();
            em.Show();

        }

        private void add1_Click(object sender, RoutedEventArgs e)
        {
            up up = new up(UP.Text);
            up.Show();
        }

        private void down1_Click(object sender, RoutedEventArgs e)
        {
            down down = new down(DOWN.Text);
            down.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT ORM_ID FROM order_materal WHERE ORM_STATUS ='รอจ่าย' ";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String materal = reader.GetString("ORM_ID");
                UP.Items.Add(materal);
            }
            con3.Close();
            String sql1 = "SELECT W_ID FROM work WHERE W_STATUS ='ดำเนินการ' ";

            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                String materal = reader1.GetString("W_ID");
                DOWN.Items.Add(materal);
            }
            con1.Close();
        }
    }

}
