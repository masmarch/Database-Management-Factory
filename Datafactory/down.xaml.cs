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
    /// Interaction logic for down.xaml
    /// </summary>
    public partial class down : Window
    {
        public down(String text)
        {
            InitializeComponent();
            letter.Content = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT DISTINCT M_ID FROM detail_wmateral WHERE W_ID='" + letter.Content + "' ";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String materal = reader.GetString("M_ID");
                id.Items.Add(materal);

            }
            con3.Close();
        }

        private void add1_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0, unit = 0, ans = 0;
            String sql = "SELECT SUM(DWM_UNIT) FROM detail_wmateral WHERE M_ID = '" + id.Text + "' ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sum += Double.Parse(reader.GetString(0));
            }

            String sql1 = "SELECT M_UNIT FROM materal WHERE M_ID = '" + id.Text + "'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                unit += Double.Parse(reader1.GetString(0));

            }
            ans =  unit-sum;
            String sql2 = "UPDATE materal SET M_UNIT = '" + ans + "' WHERE M_ID = '" + id.Text + "' ";
            MySqlConnection con2 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();

            String sql3 = "UPDATE  work SET W_STATUS = 'เสร็จสิ้น' WHERE W_ID = '" + letter.Content + "'";
            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            cmd3.ExecuteNonQuery();
            MessageBox.Show("เรียบร้อย");
            con3.Close();


        }
    }
}

