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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            String sql = "SELECT * FROM employee WHERE EMP_ID ='" + username.Text + "'AND EMP_PASS ='" + password1.Password + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
           

            if (reader.Read())
            {
                menu mn = new menu(username.Text);
                mn.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("รหัสผู้ใช้หรือรหัสผ่านผิดพลาด");
            }
        }

        
    }
    
}
