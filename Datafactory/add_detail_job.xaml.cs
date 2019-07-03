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
    /// Interaction logic for add_detail_job.xaml
    /// </summary>
    public partial class add_detail_job : Window
    {
        public add_detail_job(String text)
        {
            InitializeComponent();
            txtadd.Content = text;
        }
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommandBuilder cmd;
        DataSet ds;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT P_ID as รหัสสินค้า,JOB_ID as รหัสใบรับงาน,DJ_DESCRIPTION as รายละเอียด,DJ_TYPE as ประเภท,DJ_UNIT as จำนวน,DJ_PCS as ราคาขาย FROM detail_job WHERE JOB_ID = '" +txtadd.Content+ "' ";
            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);           
            ds = new System.Data.DataSet();            
            da.Fill(ds);           
            dataG.ItemsSource = ds.Tables[0].DefaultView;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Double sum = 0;
            cmd = new MySqlCommandBuilder(da);
            da.Update(ds);

            String sql1 = "SELECT SUM(DJ_UNIT * DJ_PCS) FROM detail_job WHERE JOB_ID = '" + txtadd.Content + "'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                sum += Double.Parse(reader.GetString(0));
            }
            String sql2 = "UPDATE job SET JOB_TOTAL = '" + sum + "' WHERE JOB_ID = '" + txtadd.Content + "' ";
            MySqlConnection con2 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();


            MessageBox.Show("เรียบร้อย");
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            find_product fp = new find_product();
            fp.Show();
        }
    }
}
