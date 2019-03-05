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
using System.Windows.Shapes;
using WpfApplication3.Model;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for AddCloset.xaml
    /// </summary>
    public partial class AddCloset : Window
    {
        GymDbContexts db = new GymDbContexts();
        public AddCloset()
        {
            InitializeComponent();
            _datagridCloset.ItemsSource = db.Closets.ToList();
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnAddClosetNew_Click(object sender, RoutedEventArgs e)
        {
            GymDbContexts db = new GymDbContexts();
            try
            {
                if(_txtAddCloset.Text.Trim() == "")
                {
                    MessageBox.Show("شماره ی کمد را وارد کنید","پیغام",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }


                Closet cl = new Closet()
                {
                    Closet_id = Convert.ToInt32(_txtAddCloset.Text.Trim())
               ,
                    Duration = "ندارد"
               ,
                    Res_Start = "ندارد"
                };
                db.Closets.Add(cl);
                db.SaveChanges();
                _txtAddCloset.Text = (cl.Closet_id+1).ToString();
                 
                _datagridCloset.ItemsSource = db.Closets.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("قبلا ثبت شده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _btnDeleteRowCloset_Click(object sender, RoutedEventArgs e)
        {
            var msg = MessageBox.Show("آیا میخواهید حذف شود؟", "پیغام", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (msg)
            {
                case MessageBoxResult.OK:
                    {
                        var selected = _datagridCloset.SelectedItem;
                        Closet cl = (Closet)selected;
                        db.Closets.Remove(cl);
                        db.SaveChanges();
                        _datagridCloset.ItemsSource = db.Closets.ToList();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    break;
            }
        }
    }
}
