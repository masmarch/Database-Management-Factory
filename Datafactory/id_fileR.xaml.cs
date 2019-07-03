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
    /// Interaction logic for id_fileR.xaml
    /// </summary>
    public partial class id_fileR : Page
    {
        public id_fileR()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT REC_ID as รหัสใบเสร็จ,REC_DATE as วันออกใบเสร้จ,JOB_ID as รหัสใบรับงาน,EMP_ID as รหัสพนักงาน FROM recept WHERE REC_ID ='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            fileG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT REC_ID as รหัสใบเสร็จ,REC_DATE as วันออกใบเสร้จ,JOB_ID as รหัสใบรับงาน,EMP_ID as รหัสพนักงาน FROM recept";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            fileG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT REC_ID as รหัสใบเสร็จ,REC_DATE as วันออกใบเสร้จ,JOB_ID as รหัสใบรับงาน,EMP_ID as รหัสพนักงาน FROM recept WHERE REC_ID='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                String a = (reader["รหัสใบรับงาน"].ToString());
                String b = (reader["รหัสพนักงาน"].ToString());
                detail_recept dr = new detail_recept(txtsearch.Text, a, b);
                dr.Show();
            }
            else if (txtsearch.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล");
            }
            else
            {
                MessageBox.Show("ข้อมูลผิดพลาด");
            }
        }
    }
}
