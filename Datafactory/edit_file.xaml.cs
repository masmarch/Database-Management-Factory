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
    /// Interaction logic for edit_file.xaml
    /// </summary>
    public partial class edit_file : Window
    {
        public edit_file()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommandBuilder cmd;
        DataSet ds;

        private void success_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT REC_ID as รหัสใบเสร็จ,REC_DATE as วันิิกใบเสร็จ,JOB_ID as รหัสใบรับงาน,EMP_ID as รหัสพนักงาน FROM recept NATURAL JOIN job WHERE JOB_STATUS = 'ดำเนินการ' AND REC_ID ='"+qid.Text+"'";
            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);
            ds = new System.Data.DataSet();
            da.Fill(ds);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT REC_ID FROM  recept NATURAL JOIN job  WHERE JOB_STATUS ='ดำเนินการ'";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String quotation = reader.GetString("REC_ID");
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
    }
}
