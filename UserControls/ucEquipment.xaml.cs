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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3.Model;

namespace WpfApplication3.UserControls
{
    /// <summary>
    /// Interaction logic for ucEquipment.xaml
    /// </summary>
    public partial class ucEquipment : UserControl
    {
        GymDbContexts db = new GymDbContexts();
        public ucEquipment()
        {
            InitializeComponent();
            _datagridEquipments.ItemsSource = db.Equipments.ToList();
        }

        private void _btnNewEq_Click(object sender, RoutedEventArgs e)
        {
            Add_Eq win = new Add_Eq();
            win.ShowDialog();
            _datagridEquipments.ItemsSource = db.Equipments.ToList();
        }

        private void _btnDeleteRowEq_Click(object sender, RoutedEventArgs e)
        {
            var msg = MessageBox.Show("آیا میخواهید حذف شود؟", "پیغام", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (msg)
            {
                case MessageBoxResult.OK:
                    {
                        var selected = _datagridEquipments.SelectedItem;
                        Equipment eq = (Equipment)selected;
                        db.Equipments.Remove(eq);
                        db.SaveChanges();
                        _datagridEquipments.ItemsSource = db.Equipments.ToList();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void _btnEditEq_Click(object sender, RoutedEventArgs e)
        {
            var selected = _datagridEquipments.SelectedItem;
           if(selected == null)
            {
                MessageBox.Show("هیچ موردی انتخاب نشده","پیغام",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            else
            {
                Equipment eq = (Equipment)selected;
                Edit_Eq win = new Edit_Eq(eq);
                win.ShowDialog();
            }
        }

        private void _btnCloset_Click(object sender, RoutedEventArgs e)
        {
            AddCloset win = new AddCloset();
            win.ShowDialog();
        }

        private void _btnLocater_Click(object sender, RoutedEventArgs e)
        {
            _btnGivaClassLocater.Visibility = Visibility.Hidden;
            _btnCloset.Visibility = Visibility.Hidden;
            _btnEditEq.Visibility = Visibility.Hidden;
            _btnNewEq.Visibility = Visibility.Hidden;
            _txtSearchEq.Visibility = Visibility.Visible;
            _cmbSearchPrio.Visibility = Visibility.Visible;
            _btnSearchEq.Visibility = Visibility.Visible;
            _btnLocater.Visibility = Visibility.Hidden;
            _btnBack.Visibility = Visibility.Visible;
            _cmbSearchPrio.SelectedIndex = 0;
        }

        private void _btnSearchEq_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (_cmbSearchPrio.SelectedIndex)
                {
                    case 0:
                        _datagridEquipments.ItemsSource = db.Equipments.ToList();
                        break;
                    case 1:
                        {
                            _datagridEquipments.ItemsSource = db.Equipments.Where(x => x.Eq_id.StartsWith(_txtSearchEq.Text.Trim())).ToList();
                            break;
                        }
                    case 2:
                        {
                            _datagridEquipments.ItemsSource = db.Equipments.Where(x => x.Company.StartsWith(_txtSearchEq.Text.Trim())).ToList();
                            break;
                        }
                    case 3:
                        {
                            _datagridEquipments.ItemsSource = db.Equipments.Where(x => x.Company.StartsWith(_txtSearchEq.Text.Trim())).ToList();
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
            _btnNewEq.Visibility = Visibility.Visible;
            _btnEditEq.Visibility = Visibility.Visible;
            _btnCloset.Visibility = Visibility.Visible;
            _txtSearchEq.Visibility = Visibility.Hidden;
            _btnSearchEq.Visibility = Visibility.Hidden;
            _cmbSearchPrio.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Visible;
            _btnGivaClassLocater.Visibility = Visibility.Visible;
        }

        private void _btnGivaClassLocater_Click(object sender, RoutedEventArgs e)
        {
            _btnGivaClassLocater.Visibility = Visibility.Hidden;
            _btnCloset.Visibility = Visibility.Hidden;
            _btnEditEq.Visibility = Visibility.Hidden;
            _btnNewEq.Visibility = Visibility.Hidden;
            _datagridClassesGiveClass.Visibility = Visibility.Visible;
            _datagridEquipmentsGiveClass.Visibility = Visibility.Visible;
            _datagridClassesGiveClass.ItemsSource = db.Classes.ToList();
            _datagridEquipmentsGiveClass.ItemsSource = db.Equipments.ToList();
            _btnBackGiveClass.Visibility = Visibility.Visible;
            _btnGivaClass.Visibility = Visibility.Visible;
            _stkTxT.Visibility = Visibility.Visible;
            _btnLocater.Visibility = Visibility.Hidden;
            _datagridEquipments.Visibility = Visibility.Hidden;
        }

        private void _btnBackGiveClass_Click(object sender, RoutedEventArgs e)
        {
            _btnBack.Visibility = Visibility.Hidden;
            _btnNewEq.Visibility = Visibility.Visible;
            _btnEditEq.Visibility = Visibility.Visible;
            _btnCloset.Visibility = Visibility.Visible;
            _txtSearchEq.Visibility = Visibility.Hidden;
            _btnSearchEq.Visibility = Visibility.Hidden;
            _cmbSearchPrio.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Visible;
            _datagridClassesGiveClass.Visibility = Visibility.Hidden;
            _datagridEquipmentsGiveClass.Visibility = Visibility.Hidden;
            _datagridEquipments.Visibility = Visibility.Visible;
            _stkTxT.Visibility = Visibility.Hidden;
            _btnBackGiveClass.Visibility = Visibility.Hidden;
            _btnGivaClass.Visibility = Visibility.Hidden;
            _btnGivaClassLocater.Visibility = Visibility.Visible;
        }

        private void _btnGivaClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GymDbContexts db = new GymDbContexts();
                Class cl = (Class)(_datagridClassesGiveClass.SelectedItem);
                Equipment eq = (Equipment)(_datagridEquipmentsGiveClass.SelectedItem);
                var record = db.Equipments.Single(x => x.Eq_id == eq.Eq_id);
                if (eq.ClassID == null)
                {
                    
                    record.ClassID = cl.ClassID;
                    db.SaveChanges();
                    MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                    _datagridEquipmentsGiveClass.ItemsSource = db.Equipments.ToList();
                }
                else
                {
                    MessageBox.Show("قبلا ثبت شده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("هیچ رکوری انتخاب نشده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
