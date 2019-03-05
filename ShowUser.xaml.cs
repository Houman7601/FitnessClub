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
using System.Windows.Shapes;
using WpfApplication3.Model;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for ShowUser.xaml
    /// </summary>
    public partial class ShowUser : Window
    {
        GymDbContexts db = new GymDbContexts();
        public ShowUser()
        {
            InitializeComponent();
            _datagridUsers.ItemsSource = db.Users.Where(x => x.Type == "کاربر").ToList();
        }


        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _btnDeleteRowClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User us = (User)(_datagridUsers.SelectedItem);
                db.Users.Remove(us);
                db.SaveChanges();
                _datagridUsers.ItemsSource = db.Users.Where(x => x.Type == "کاربر").ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("هیچ رکوردی انتخاب نشده","پیغام",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        private void darg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
