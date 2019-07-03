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
    /// Interaction logic for fuc_emp.xaml
    /// </summary>
    public partial class fuc_emp : Window
    {
        public fuc_emp()
        {
            InitializeComponent();
        }
       
        private void emp1_Click(object sender, RoutedEventArgs e)
        {
            id_emp.txthead = "ค้นหาด้วยรหัสพนักงาน";
            Rframe.NavigationService.Navigate(new Uri("id_emp.xaml", UriKind.RelativeOrAbsolute));
        }

        private void emp2_Click(object sender, RoutedEventArgs e)
        {
            dep_emp.txthead = "ค้นหาตามแผนก";
            Rframe.NavigationService.Navigate(new Uri("dep_emp.xaml", UriKind.RelativeOrAbsolute));
        }

       

        private void addemp_Click(object sender, RoutedEventArgs e)
        {
            add_emp.txthead = "เพิ่มรายชื่อพนักงาน";
            Rframe.NavigationService.Navigate(new Uri("add_emp.xaml", UriKind.RelativeOrAbsolute));
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            edit_emp ed = new edit_emp();
            ed.Show();
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

        private void product_Click(object sender, RoutedEventArgs e)
        {
            fuc_pro fd = new fuc_pro();
            fd.Show();
            this.Close();
        }

        private void emp_Click(object sender, RoutedEventArgs e)
        {
            Rframe.NavigationService.Navigate(new Uri("name_emp.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
