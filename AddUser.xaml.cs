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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        GymDbContexts db = new GymDbContexts();
        public AddUser()
        {
            InitializeComponent();
        }

        public object User { get; private set; }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void txtClear()
        {
            _txtusername.Clear();
            _txtPass.Clear();
            _txtPassConf.Clear();
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            if (_txtusername.Text.Trim() == "")
            {
                MessageBox.Show("فیلد نام کاربری نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                _txtusername.Focus();
                return;
            }         
            else if (_txtPass.Password.Trim() == "")
            {
                MessageBox.Show("فیلد کلمه ی عبور نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                _txtPass.Focus();
                return;
            }
            else if (_txtPassConf.Password.Trim() == "")
            {
                MessageBox.Show("دو کلمه ی عبور وارد شده همخوانی ندارند", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                _txtPassConf.Focus();
                return;
            }
            else if (_txtPass.Password.Trim() != "")
            {
                if (_txtPass.Password != _txtPassConf.Password)
                {
                    MessageBox.Show("دو کلمه ی عبور وارد شده همخوانی ندارند", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    _txtPassConf.Focus();
                    return;
                }
                else
                {
                    try
                    {
                        User us = new User()
                        {
                            Username = _txtusername.Text.Trim()
                       ,
                            Password = _txtPassConf.Password.Trim()
                       ,
                            Type = "کاربر"
                        };
                        db.Users.Add(us);
                        db.SaveChanges();
                        MessageBox.Show("ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtClear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("این نام کاربری از قبل وجود دارد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
