﻿using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datafactory
{
    /// <summary>
    /// Interaction logic for id_fileJ.xaml
    /// </summary>
    public partial class id_fileJ : Page
    {
        public id_fileJ()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT JOB_ID as รหัสใบรับงาน,JOB_DATE as วันรับงาน,JOB_DATELINE as วันครบกำหนด,JOB_PAYDAY as วันจ่าย,JOB_TOTAL as ราคา,JOB_STATUS as สถานะ,CUS_ID as รหัสลูกค้า FROM job WHERE job_ID ='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            fileG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT JOB_ID as รหัสใบรับงาน,JOB_DATE as วันรับงาน,JOB_DATELINE as วันครบกำหนด,JOB_PAYDAY as วันจ่าย,JOB_TOTAL as ราคา,JOB_STATUS as สถานะ,CUS_ID as รหัสลูกค้า FROM job";

            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            fileG.ItemsSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            String sql = "SELECT JOB_ID as รหัสใบรับงาน,JOB_DATE as วันรับงาน,JOB_DATELINE as วันครบกำหนด,JOB_PAYDAY as วันจ่าย,JOB_TOTAL as ราคา,JOB_STATUS as สถานะ,CUS_ID as รหัสลูกค้า FROM job WHERE JOB_ID='" + txtsearch.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=Polyurethane;password=0811558446;database=factory;charset=utf8");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                detail_job dj = new detail_job(txtsearch.Text);
                dj.Show();
            }
            else if (txtsearch.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล");
            }
            else
            {
                MessageBox.Show("ข้อมูลผิดพลาด");
            }
        }
    }
}
