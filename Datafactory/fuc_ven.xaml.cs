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
    /// Interaction logic for fuc_ven.xaml
    /// </summary>
    public partial class fuc_ven : Window
    {
        public fuc_ven()
        {
            InitializeComponent();
        }

             

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_ven.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            edit_ven ec= new edit_ven();
            ec.Show();
        }

        private void ven1_Click_1(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_ven.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ven2_Click_1(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("name_ven.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ven3_Click_1(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("status_ven.xaml", UriKind.RelativeOrAbsolute));
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


        private void partner_Click(object sender, RoutedEventArgs e)
        {
            fuc_part fp = new fuc_part();
            fp.Show();
            this.Close();
        }

        private void materal_Click(object sender, RoutedEventArgs e)
        {
            fuc_mat fm = new fuc_mat();
            fm.Show();
            this.Close();
        }

        private void product_Click(object sender, RoutedEventArgs e)
        {
            fuc_pro fd = new fuc_pro();
            fd.Show();
            this.Close();
        }

    }
}
