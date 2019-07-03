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
    /// Interaction logic for fuc_cus.xaml
    /// </summary>
    public partial class fuc_cus : Window
    {
        public fuc_cus()
        {
            InitializeComponent();
        }

        private void cus1_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_cus.xaml", UriKind.RelativeOrAbsolute));
        }

        private void cus2_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("name_cus.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fuc_emp fe = new fuc_emp();
            fe.Show();
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_cus.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            edit_cus ec = new edit_cus();
            ec.Show();
        }

        private void cus3_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("status_cus.xaml", UriKind.RelativeOrAbsolute));
        }

   

        private void employee_Click(object sender, RoutedEventArgs e)
        {
            fuc_emp fe = new fuc_emp();
            fe.Show();
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

        private void product_Click(object sender, RoutedEventArgs e)
        {
            fuc_pro fd = new fuc_pro();
            fd.Show();
            this.Close();
        }

    }
}
