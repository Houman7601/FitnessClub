using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.IO;

namespace WpfApplication3.Model
{
    public class MyData
    {
        public string strsql;
        public DataTable ShowData()
        {
            SqlConnection con1 = new SqlConnection(
            ConfigurationManager.ConnectionStrings["GymDataBase"].ConnectionString);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter(strsql, con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con1.Close();
            return (dt);
        }


        public void Backup()
        {
            try
            {
                if (File.Exists(@"C:\\Gym.BAK"))
                {
                    File.Delete(@"C:\\Gym.BAK");
                }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GymDataBase"].ConnectionString);
                con.Open();
                SqlCommand sc = new SqlCommand();

                sc.CommandText = "BACKUP DATABASE GymDataBase TO DISK = 'C:\\Gym.BAK'";
                sc.CommandType = CommandType.Text;
                sc.Connection = con;
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("پشتیبان گیری با موفقیت انجام شد","پیغام",MessageBoxButton.OK,MessageBoxImage.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("خطا", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }


        public void Restore()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GymDataBase"].ConnectionString);
                con.Open();
                SqlCommand sc = new SqlCommand();

                sc.CommandText = "USE master ALTER DATABASE GymDataBase SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE GymDataBase FROM DISK = 'C:\\Gym.BAK' WITH REPLACE ALTER DATABASE GymDataBase SET MULTI_USER";
                sc.CommandType = CommandType.Text;
                sc.Connection = con;
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("بازیابی با موفقیت انجام شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("برای اعمال تغییرات برنامه را مجددا اجرا کنید", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                Environment.Exit(0);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);

            }
}
    }
}
