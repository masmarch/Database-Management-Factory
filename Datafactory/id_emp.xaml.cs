using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for id_emp.xaml
    /// </summary>
    public partial class id_emp : Page
    {
        public id_emp()
        {
            InitializeComponent();
        }
        public static string txthead = "";
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            head.Content = txthead;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                String sql = "SELECT EMP_ID as รหัสพนักงาน,DEP_ID as รหัสแผนก,EMP_FNAME as ชื่อ,EMP_LNAME as นามสกุล,EMP_ADDRESS as ที่อยู่,EMP_PHONE as เบอร์ติดต่อ,EMP_PASS as รหัสผ่าน,EMP_STATUS as สถานะ FROM employee WHERE EMP_ID ='" + empsearch.Text + "'";
                MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                empG.ItemsSource = ds.Tables[0].DefaultView;
                con.Close();
         
        }

        private void allemp_Click(object sender, RoutedEventArgs e)
        {
                      
            String sql = "SELECT EMP_ID as รหัสพนักงาน,DEP_ID as รหัสแผนก,EMP_FNAME as ชื่อ,EMP_LNAME as นามสกุล,EMP_ADDRESS as ที่อยู่,EMP_PHONE as เบอร์ติดต่อ,EMP_PASS as รหัสผ่าน,EMP_STATUS as สถานะ FROM employee";   
            
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            empG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }
    }
}
