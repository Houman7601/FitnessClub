using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace WpfApplication3.UserControls
{
    /// <summary>
    /// Interaction logic for ucMembers.xaml
    /// </summary>
    public partial class ucMembers : UserControl
    {
        TabChanger tc = new TabChanger();
        GymDbContexts db = new GymDbContexts();

        public ucMembers()
        {
            InitializeComponent();
            _datagridMembers.ItemsSource = db.Members.ToList();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Member mem = (Member)(_datagridMembers.SelectedItem);
            ShowClass win = new ShowClass(mem);
            win.ShowDialog();
        }
        private void _btnNewMemebr_Click(object sender, RoutedEventArgs e)
        {
            AddMember win = new AddMember();
            win.ShowDialog();
            _datagridMembers.ItemsSource = db.Members.ToList();

        }


        private void _btnDeleteRowMember_Click(object sender, RoutedEventArgs e)
        {
           var msg =  MessageBox.Show("آیا میخواهید حذف شود؟","پیغام",MessageBoxButton.OKCancel,MessageBoxImage.Question);
            switch (msg)
            {
                case MessageBoxResult.OK:
                    {
                        var selected = _datagridMembers.SelectedItem;
                        Member mem = (Member)selected;
                        db.Members.Remove(mem);
                        db.SaveChanges();
                        _datagridMembers.ItemsSource = db.Members.ToList();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void _btnEditMember_Click(object sender, RoutedEventArgs e)
        {
            var selected = _datagridMembers.SelectedItem;
           if(selected != null)
            {
                Member mem = (Member)selected;
                EditMember win = new EditMember(mem);
                win.ShowDialog();
                _datagridMembers.ItemsSource = db.Members.ToList();
            }
           else
            {
                MessageBox.Show("هیچ رکوردی انتخاب نشده","پیغام",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void _btnClosetWin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = _datagridMembers.SelectedItem;
                Member mem = (Member)selected;
                ResCloset win = new ResCloset(mem.Membership_Number);
                win.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("هیچ رکوردی انتخاب نشده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _btnLocater_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(_btnLocater);
            if (column == 3)
            {
                _btnClosetWin.Visibility = Visibility.Hidden;
                _btnNewMemebr.Visibility = Visibility.Hidden;
                _btnEditMember.Visibility = Visibility.Hidden;
                _txtSearchMem.Visibility = Visibility.Visible;
                _cmbSearchPrio.Visibility = Visibility.Visible;
                _btnSearchMem.Visibility = Visibility.Visible;
                _btnLocater.Visibility = Visibility.Hidden;
                _btnBack.Visibility = Visibility.Visible;
                _cmbSearchPrio.SelectedIndex = 0;
            }
        }

        private void _btnSearchMem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (_cmbSearchPrio.SelectedIndex)
                {
                    case 0:
                        _datagridMembers.ItemsSource = db.Members.ToList();
                        break;
                    case 1:
                        {
                            _datagridMembers.ItemsSource = db.Members.Where(x => x.Membership_Number.StartsWith(_txtSearchMem.Text.Trim())).ToList();
                            break;
                        }
                    case 2:
                        {
                            _datagridMembers.ItemsSource = db.Members.Where(x => x.LastName.StartsWith(_txtSearchMem.Text.Trim())).ToList();
                            break;
                        }
                    case 3:
                        {
                            _datagridMembers.ItemsSource = db.Members.Where(x => x.Condition.StartsWith(_txtSearchMem.Text.Trim())).ToList();
                            break;
                        }
                }
            }
            catch (Exception)
            {

            }
        }

        private void _btnBack_Click(object sender, RoutedEventArgs e)
        {
            _btnBack.Visibility = Visibility.Hidden;
            _btnNewMemebr.Visibility = Visibility.Visible;
            _btnEditMember.Visibility = Visibility.Visible;
            _btnClosetWin.Visibility = Visibility.Visible;
            _txtSearchMem.Visibility = Visibility.Hidden;
            _btnSearchMem.Visibility = Visibility.Hidden;
            _cmbSearchPrio.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Visible;
        }
    }
}
