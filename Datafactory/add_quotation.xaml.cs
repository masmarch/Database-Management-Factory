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
    /// Interaction logic for add_quotation.xaml
    /// </summary>
    public partial class add_quotation : Page
    {
        public add_quotation()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            String sql1 = "SELECT * FROM job WHERE JOB_STATUS = 'ดำเนินการ'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String job = reader.GetString("JOB_ID");
                jobid.Items.Add(job);
            }
        }
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql1 = "SELECT JOB_ID FROM job WHERE JOB_ID = '" + jobid.Text + "' ";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                String sql2 = "SELECT EMP_ID FROM employee WHERE EMP_ID = '" + empid.Text + "' ";
                MySqlConnection con2 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                MySqlDataReader reader1 = cmd2.ExecuteReader();
                if (reader1.Read())
                {
                    String sql = "INSERT INTO quotation VALUES('" + qid.Text + "','" + date.DisplayDate.ToString("yyyy-MM-dd") + "','"+jobid.Text+"','" + empid.Text + "') ";
                    MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("เรียบร้อย");
                }
                else
                {
                    MessageBox.Show("กรุณาใส่รหัสพนักงาน");
                }
            }
            else
            {
                MessageBox.Show("กรุณาใส่รหัสใบรับงาน");
            }
        }

    }
}
