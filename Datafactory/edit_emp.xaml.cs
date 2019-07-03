using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for edit_emp.xaml
    /// </summary>
    public partial class edit_emp : Window
    {
        public edit_emp()
        {
            InitializeComponent();
        }
        
        
        String sex;
        private void show_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT * FROM employee WHERE EMP_ID ='" + userid.Text + "'";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {               
                
                String type = reader.GetString("EMP_STATUS");
                name.Text = (reader["EMP_FNAME"].ToString());
                address.Text = (reader["EMP_ADDRESS"].ToString());
                surname.Text = (reader["EMP_LNAME"].ToString());
                phone.Text = (reader["EMP_PHONE"].ToString());
                dep.Text = (reader["DEP_ID"].ToString());
                password.Text = (reader["EMP_PASS"].ToString());
                if(type == "พนักงานประจำ")
                {
                    emp1.IsChecked = true;
                }
                else if(type == "อัตราจ้าง")
                {
                    emp2.IsChecked = true;
                }
                else
                {
                    emp3.IsChecked = true;
                }
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
                name.Text = "";
                address.Text = "";
                surname.Text = "";
                phone.Text = "";
                dep.Text = "";
                password.Text = "";
                emp1.IsChecked = false;
                emp2.IsChecked = false;
                emp3.IsChecked = false;
            }
        }
        private void done_Click(object sender, RoutedEventArgs e)
        {
            String sql = "UPDATE employee SET EMP_FNAME='" + name.Text + "',EMP_LNAME='"+surname.Text+"',EMP_ADDRESS='"+address.Text+"',EMP_PHONE='"+phone.Text+"',DEP_ID='"+dep.Text+"',EMP_STATUS='"+sex+"',EMP_PASS='"+password.Text+"' WHERE EMP_ID='"+userid.Text+"'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("แก้ไขเรียบร้อย");
            this.Close();
        }

        private void emp1_Checked(object sender, RoutedEventArgs e)
        {
            sex = "พนักงานประจำ";
        }

        private void emp2_Checked(object sender, RoutedEventArgs e)
        {
            sex = "อัตราจ้าง";
        }

        private void emp3_Checked(object sender, RoutedEventArgs e)
        {
            sex = "ลาออก";
        }
    }
}
