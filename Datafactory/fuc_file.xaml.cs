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
    /// Interaction logic for fuc_file.xaml
    /// </summary>
    public partial class fuc_file : Window
    {
        public fuc_file()
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

        private void fileQ1_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_fileQ.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileR1_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_fileR.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileV_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_fileV.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileP_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_fileP.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileJ_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_fileJ.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileW_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_fileW.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileQ2_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_jobQ.xaml", UriKind.RelativeOrAbsolute));
        }

        private void fileR2_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("id_jobR.xaml", UriKind.RelativeOrAbsolute));
        }

        private void addW_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_work.xaml", UriKind.RelativeOrAbsolute));
        }

        private void addQ_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_quotation.xaml", UriKind.RelativeOrAbsolute));
        }

        private void addV_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_order_materal.xaml", UriKind.RelativeOrAbsolute));
        }

        private void addR_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_recept.xaml", UriKind.RelativeOrAbsolute));
        }

        private void addJ_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_job.xaml", UriKind.RelativeOrAbsolute));
        }

        private void addP_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("add_order_product.xaml", UriKind.RelativeOrAbsolute));
        }

        private void editJ_Click(object sender, RoutedEventArgs e)
        {
            edit_job ej = new edit_job();
            ej.Show();
        }

        private void editQ_Click(object sender, RoutedEventArgs e)
        {
            edit_qaotation eq = new edit_qaotation();
            eq.Show();
        }

        private void editW_Click(object sender, RoutedEventArgs e)
        {
            edit_work ew = new edit_work();
            ew.Show();
        }

        private void editR_Click(object sender, RoutedEventArgs e)
        {
            edit_file ef = new edit_file();
            ef.Show();
        }

        private void editV_Click(object sender, RoutedEventArgs e)
        {
            edit_materal em = new edit_materal();
            em.Show();
        }

        private void editP_Click(object sender, RoutedEventArgs e)
        {
            edit_orderProduct ep = new edit_orderProduct();
            ep.Show();
        }
    }
}
