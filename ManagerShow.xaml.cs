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
    /// Interaction logic for ManagerShow.xaml
    /// </summary>
    public partial class ManagerShow : Window
    {

        public Manager Manager_edit
        {
            get { return (Manager)GetValue(Manager_editProperty); }
            set { SetValue(Manager_editProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Manager_edit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Manager_editProperty =
            DependencyProperty.Register("Manager_edit", typeof(Manager), typeof(ManagerShow), new PropertyMetadata(new Manager()));

        GymDbContexts db = new GymDbContexts();
        public ManagerShow()
        {
            InitializeComponent();
            var manager = db.Managers.Single();
            var admin = db.Users.Single(x => x.Type == "مدیر");
            Manager_edit.FirstName = manager.FirstName;
            Manager_edit.LastName = manager.LastName;
            Manager_edit.ManagerId = manager.ManagerId;
            Manager_edit.Melli = manager.Melli;
            Manager_edit.Mobile = manager.Mobile;
            Manager_edit.Birthdate = manager.Birthdate;
            _txtUsername.Text = admin.Username.ToString();
            DataContext = this;
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _chkEdit_Checked(object sender, RoutedEventArgs e)
        {
            _txtBirthDate.IsEnabled = true;
            _txtFName.IsEnabled = true;
            _txtLName.IsEnabled = true;
            _txtMelli.IsEnabled = true;
            _txtMobile.IsEnabled = true;
            _txtUsername.IsEnabled = true;
            _btnSabt.IsEnabled = true;
        }

        private void _chkEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            _txtBirthDate.IsEnabled = false;
            _txtFName.IsEnabled = false;
            _txtLName.IsEnabled = false;
            _txtMelli.IsEnabled = false;
            _txtMobile.IsEnabled = false;
            _txtUsername.IsEnabled = false;
            _btnSabt.IsEnabled = false;
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = db.Managers.Single();
                var admin = db.Users.Single(x => x.Type == "مدیر");
                User us = (User)admin;
                db.Users.Remove(us);
                db.SaveChanges();
                User usn = new User()
                {
                    Username = _txtUsername.Text.Trim()
                    ,
                    Type = "مدیر"
                    ,
                    Password = us.Password
                };
                db.Users.Add(usn);
                db.SaveChanges();
                manager.FirstName = _txtFName.Text.Trim();
                manager.LastName = _txtLName.Text.Trim();
                manager.Birthdate = _txtBirthDate.Text.Trim();
                manager.Melli = _txtMelli.Text.Trim();
                manager.Mobile = _txtMobile.Text.Trim();
                db.SaveChanges();
                MessageBox.Show("تغییرات اعمال شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                Main win = new Main(usn);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
