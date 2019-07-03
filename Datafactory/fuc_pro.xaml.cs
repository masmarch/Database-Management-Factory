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
    /// Interaction logic for fuc_pro.xaml
    /// </summary>
    public partial class fuc_pro : Window
    {
        public fuc_pro()
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
        private void materal_Click(object sender, RoutedEventArgs e)
        {
            fuc_mat fm = new fuc_mat();
            fm.Show();
            this.Close();
        }

        private void pro1_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_pro.xaml", UriKind.RelativeOrAbsolute));
        }

        private void pro2_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("name_pro.xaml", UriKind.RelativeOrAbsolute));
        }

        private void pro3_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("type_pro.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            edit_product ep = new edit_product();
            ep.Show();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
           Rframe.NavigationService.Navigate(new Uri("add_product.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
