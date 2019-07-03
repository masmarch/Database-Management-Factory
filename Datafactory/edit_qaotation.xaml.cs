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
    /// Interaction logic for edit_qaotation.xaml
    /// </summary>
    public partial class edit_qaotation : Window
    {
        public edit_qaotation()
        {
            InitializeComponent();
        }

        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommandBuilder cmd;
        DataSet ds;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            String sql3 = "SELECT QUO_ID FROM quotation NATURAL JOIN job  WHERE JOB_STATUS ='ดำเนินการ'";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String quotation = reader.GetString("QUO_ID");
                qid.Items.Add(quotation);
            }
            con3.Close();
                
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cmd = new MySqlCommandBuilder(da);
            da.Update(ds);
            MessageBox.Show("แก้ไขเรียบร้อย");
        }

        private void success_Click(object sender, RoutedEventArgs e)
        {
            String sql4 = "SELECT QUO_ID FROM quotation NATURAL JOIN job  WHERE QUO_ID ='" + qid.Text + "' AND JOB_STATUS ='ดำเนินการ'";

            MySqlConnection con4 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd4 = new MySqlCommand(sql4, con4);
            con4.Open();
            MySqlDataReader reader4 = cmd4.ExecuteReader();
            if (reader4.Read())
            {

                String sql = "SELECT QUO_ID as รหัสใบเสนอราคา,QUO_DATE as วันเสนอราคางาน,JOB_ID as รหัสใบรับงาน,EMP_ID as รหัสพนักงาน FROM quotation NATURAL JOIN job WHERE JOB_STATUS = 'ดำเนินการ'";
                con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
                con.Open();
                da = new MySqlDataAdapter(sql, con);
                ds = new System.Data.DataSet();
                da.Fill(ds);
                dataG.ItemsSource = ds.Tables[0].DefaultView;
            }
        }
    }
}