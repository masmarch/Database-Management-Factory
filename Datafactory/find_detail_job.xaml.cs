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
    /// Interaction logic for find_detail_job.xaml
    /// </summary>
    public partial class find_detail_job : Window
    {
        public find_detail_job(String text)
        {
            InitializeComponent();
            txtadd.Content = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT P_ID as สินค้า,DJ_DESCRIPTION as รายละเอียด,DJ_TYPE as ประเภท,DJ_UNIT as จำนวน,DJ_PCS as ราคาขาย FROM detail_job " +
           "WHERE JOB_ID = (SELECT JOB_ID FROM quotation " +
           "WHERE QUO_ID = '" + txtadd.Content + "' AND DJ_TYPE != 'แม่พิมพ์')";

            String sql1 = "SELECT M_ID as รหัสวัตถุดิบ,M_NAME as ชื่อวัตถุดิบ,M_DESCRIPTION as รายละเอียด,M_TYPE as ประเภท,M_PPU as ราคาต่อกิโลกรัม FROM materal";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            con.Open();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            da.Fill(ds);
            da1.Fill(ds1);
            dataG.ItemsSource = ds.Tables[0].DefaultView;
            dataG1.ItemsSource = ds1.Tables[0].DefaultView;
            con.Close();
        }
    }
}
