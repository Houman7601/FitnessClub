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
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        User UserInf = new User();
        public ChangePass(User user)
        {
            UserInf = user;
            InitializeComponent();
        }

        public void txtClear()
        {
            _txtCurrentPass.Clear();
            _txtnewPass.Clear();
            _txtPassConf.Clear();
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            GymDbContexts db = new GymDbContexts();
            if (_txtCurrentPass.Password == "" || _txtnewPass.Password == "" || _txtPassConf.Password == "")
            {
                MessageBox.Show("تمام فیلد ها باید پر باشند", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(_txtnewPass.Password != _txtPassConf.Password)
            {
                MessageBox.Show("کلمه ی عبور جدید و تایید آن با هم همخوانی ندارند", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(_txtCurrentPass.Password != UserInf.Password)
            {
                MessageBox.Show("کلمه ی عبور فعلی اشتباه است", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                    var record = db.Users.Single(x => x.Username == UserInf.Username);
                    record.Password = _txtnewPass.Password;
                    db.SaveChanges();
                    MessageBox.Show("کلمه ی عبور جدید با موفقیت ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserInf.Password = _txtnewPass.Password;
                    if(UserInf.Type == "مدیر")
                    {
                        Main win = new Main(UserInf);
                    }
                    else if(UserInf.Type == "کاربر")
                    {
                        MainUser win = new MainUser(UserInf);
                    }
                    txtClear();
                }
                catch (Exception)
                {
                    MessageBox.Show("خطا", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
