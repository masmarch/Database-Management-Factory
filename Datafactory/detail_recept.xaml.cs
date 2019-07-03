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
using System.Windows.Shapes;

namespace Datafactory
{
    /// <summary>
    /// Interaction logic for detail_recept.xaml
    /// </summary>
    public partial class detail_recept : Window
    {
        String a;
        String b;
        public detail_recept(String text, string text1, string text2)
        {
            InitializeComponent();
            txt.Content = text;
            a = text1;
            b = text2;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM job WHERE JOB_ID = '" + a + "'";
            String sql1 = "SELECT * FROM employee WHERE EMP_ID = '" + b + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            con.Open();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            da.Fill(ds);
            da1.Fill(ds1);
            detailG.ItemsSource = ds.Tables[0].DefaultView;
            detailG2.ItemsSource = ds1.Tables[0].DefaultView;
            con.Close();
        }
    }
}
