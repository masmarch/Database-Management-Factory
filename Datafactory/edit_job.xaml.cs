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
    /// Interaction logic for edit_job.xaml
    /// </summary>
    public partial class edit_job : Window
    {
        public edit_job()
        {
            InitializeComponent();
        }

        MySqlConnection con;
        MySqlDataAdapter da, da1;
        MySqlCommandBuilder cmd, cmd1;
        DataSet ds, ds1;

        private void success_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT JOB_ID as รหัสใบรับงาน,JOB_DATE as วันรับงาน,JOB_DATELINE as วันรับปิดงาน,JOB_PAYDAY as วันชำระค่าชำระ,JOB_TOTAL as ราคา,JOB_STATUS as สถานะ,CUS_ID as รหัสลูกค้า FROM job WHERE JOB_STATUS = 'ดำเนินการ'AND JOB_ID ='"+qid.Text+"'";
            String sql2 = "SELECT P_ID as รหัสสินค้า,JOB_ID as รหัสใบรับงาน,DJ_DESCRIPTION as รายละเอียด,DJ_TYPE as ประเภท,DJ_UNIT as จำนวน,DJ_PCS as ราคาขาย FROM detail_job NATURAL JOIN job WHERE JOB_STATUS = 'ดำเนินการ'AND JOB_ID ='" + qid.Text + "'";
            con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            con.Open();
            da = new MySqlDataAdapter(sql, con);
            da1 = new MySqlDataAdapter(sql2, con);
            ds = new System.Data.DataSet();
            ds1 = new System.Data.DataSet();
            da.Fill(ds);
            da1.Fill(ds1);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
            dataG1.ItemsSource = ds1.Tables[0].DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql3 = "SELECT JOB_ID FROM  job  WHERE JOB_STATUS ='ดำเนินการ'";

            MySqlConnection con3 = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd3 = new MySqlCommand(sql3, con3);
            con3.Open();
            MySqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                String quotation = reader.GetString("JOB_ID");
                qid.Items.Add(quotation);
            }
            con3.Close();

            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cmd = new MySqlCommandBuilder(da);
            da.Update(ds);
            cmd1 = new MySqlCommandBuilder(da1);
            da1.Update(ds1);
            MessageBox.Show("แก้ไขเรียบร้อย");
        }
    }
}
