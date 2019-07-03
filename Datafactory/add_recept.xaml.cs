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
    /// Interaction logic for add_recept.xaml
    /// </summary>
    public partial class add_recept : Page
    {
        public add_recept()
        {
            InitializeComponent();
        }

        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM job WHERE JOB_STATUS = 'ดำเนินการ'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String job = reader.GetString("JOB_ID");
                jobid.Items.Add(job);
            }
        }
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT JOB_ID FROM job WHERE JOB_ID = '" + jobid.Text + "' ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String sql1 = "SELECT EMP_ID FROM employee WHERE EMP_ID = '" + empid.Text + "' ";
                MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
                con1.Open();
                MySqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    String sql2 = "INSERT INTO recept VALUES('" + recid.Text + "','" + recdate.DisplayDate.ToString("yyyy-MM-dd") + "','" + jobid.Text + "','" + empid.Text + "') ";
                    MySqlConnection con2 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                    MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                    MessageBox.Show("เรียบร้อย");
                }
                else
                {
                    MessageBox.Show("กรอกรหัสพนักงานให้ถูกต้อง");
                }
            }
            else
            {
                MessageBox.Show("กรอกรหัสใบรับงานให้ถูกต้อง");
            }

            
        }

    }
}
