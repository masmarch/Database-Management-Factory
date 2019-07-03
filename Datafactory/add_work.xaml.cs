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
    /// Interaction logic for add_work.xaml
    /// </summary>
    public partial class add_work : Page
    {
        public add_work()
        {
            InitializeComponent();
        }
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql1 = "SELECT W_ID FROM work WHERE W_ID = '" + userid.Text +"'";
            MySqlConnection con1 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
            con1.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read() || userid.Text == "" )
            {
                MessageBox.Show("ซ้ำโปรดกรอกใหม่");
                userid.Text = "";
                date.Text = "";
                dateline1.Text = "";
            }
            else
            {
                String sql = "INSERT INTO work VALUES('" + userid.Text + "','" + date.DisplayDate.ToString("yyyy-MM-dd") + "','" + dateline1.DisplayDate.ToString("yyyy-MM-dd") + "',' 0.00 ','ดำเนินการ') ";
                MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("เรียบร้อยแล้วกรุณาเพิ่มสินค้า");


                add_detailP dp = new add_detailP(userid.Text);
                dp.Show();




            }
        }
       
    }
}
