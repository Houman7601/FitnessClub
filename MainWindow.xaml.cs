using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApplication3.Model;
using WpfApplication3.UserControls;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        GymDbContexts db = new GymDbContexts();
        public MainWindow()
        {          
            InitializeComponent();
            _cmbType.SelectedIndex = 0;
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _winDrag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User us = new User()
            {
                Username = _txtUsername.Text.Trim()
                ,
                Password = _txtPassword.Password.ToString().Trim()
            };

            try
            {
                var query = db.Users.Single(x => x.Username == us.Username && x.Password == us.Password);


                if (query != null)
                {
                    User user = (User)query;

                   if(user.Type == _cmbType.Text && user.Type=="مدیر")
                    {
                        user.Type = "مدیر";
                        Main win = new Main(user);
                        win.Show();
                        this.Close();
                    }
                   else if (user.Type == _cmbType.Text && user.Type == "کاربر")
                    {
                        user.Type = "کاربر";
                        PersianDateTime pdt = PersianDateTime.Now;
                        query.LastEntry = pdt.ToString();
                        db.SaveChanges();
                        MainUser win = new MainUser(user);
                        win.Show();
                        this.Close();
                    }
                   else { MessageBox.Show(".نام کاربری یا رمز عبور اشتباه است", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(".نام کاربری یا رمز عبور اشتباه است","پیغام",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        private void _winDrag_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
