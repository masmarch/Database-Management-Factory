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
    /// Interaction logic for add_job.xaml
    /// </summary>
    public partial class add_job : Page
    {
        public add_job()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            String sql1 = "SELECT * FROM customer WHERE CUS_STATUS != 'ยกเลิก'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String customer = reader.GetString("CUS_ID");
                cusid.Items.Add(customer);
            }
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sqlx = "SELECT JOB_ID FROM job WHERE JOB_ID = '" + jobid.Text + "'";
            MySqlConnection conx = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmdx = new MySqlCommand(sqlx, conx);
            conx.Open();
            MySqlDataReader readerx = cmdx.ExecuteReader();
            if (readerx.Read() || jobid.Text == "")
            {
                MessageBox.Show("ซ้ำโปรดกรอกใหม่");
                jobid.Text = "";
                jobdate.Text = "";
                jobdateline.Text = "";
                jobpayday.Text = "";
                cusid.Text = "";
            }
            else
            {
                String sql1 = "SELECT CUS_ID FROM customer WHERE CUS_ID = '" + cusid.Text + "' ";
                MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                con.Open();
                MySqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    String sql = "INSERT INTO job VALUES('" + jobid.Text + "','" + jobdate.DisplayDate.ToString("yyyy-MM-dd") + "','" + jobdateline.DisplayDate.ToString("yyyy-MM-dd") + "','" + jobpayday.DisplayDate.ToString("yyyy-MM-dd") + "'" +
                       ",'0.00','ดำเนินการ','" + cusid.Text + "') ";
                    MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                    MySqlCommand cmd = new MySqlCommand(sql, con1);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("เรียบร้อย");

                    add_detail_job ad = new add_detail_job(jobid.Text);
                    ad.Show();
                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสลูกค้า");
                }
            }
               
        }
    }
}
