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
    /// Interaction logic for ucWorkers.xaml
    /// </summary>
    public partial class ucWorkers : UserControl
    {
        GymDbContexts db = new GymDbContexts();

        public ucWorkers()
        {
            InitializeComponent();
            _datagridStaff.ItemsSource = db.Staffs.ToList();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Instructor ins = (Instructor)(_datagridStaff.SelectedItem);
                if (ins.Type == "مربی")
                {
                    ShowClassIns win = new ShowClassIns(ins);
                    win.ShowDialog();
                }
                else
                {
                    MessageBox.Show("فرد مورد نظر مربی نیست", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("فرد مورد نظر مربی نیست", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void _btnDeleteRowStaff_Click(object sender, RoutedEventArgs e)
        {
            var msg = MessageBox.Show("آیا میخواهید حذف شود؟", "پیغام", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (msg)
            {
                case MessageBoxResult.OK:
                    {
                        var selected = _datagridStaff.SelectedItem;
                        Staff st = (Staff)selected;
                        db.Staffs.Remove(st);
                        db.SaveChanges();
                        _datagridStaff.ItemsSource = db.Staffs.ToList();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void _btnNewStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaff win = new AddStaff();
            win.ShowDialog();
            _datagridStaff.ItemsSource = db.Staffs.ToList();
        }

        private void _btnEditStaff_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Staff)(_datagridStaff.SelectedItem);
            if (selected == null)
            {
                MessageBox.Show("هیچ رکوردی انتخاب نشده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Staff st = selected;
            EditStaff win = new EditStaff(st);
            win.ShowDialog();
        }

        private void _btnMakeIns_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Staff stf = (Staff)(_datagridStaff.SelectedItem);
                if (stf.Type == "مربی")
                {
                    MessageBox.Show("کارمند مورد نظر در حال حاضر مربی است", "پیغام", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    db.Staffs.Remove(stf);
                    Instructor ins = new Instructor()
                    {
                        Address = stf.Address
                    ,
                        Birthdate = stf.Birthdate
                    ,
                        Certificate = "دکترای تربیت بدنی"
                    ,
                        FirstName = stf.FirstName
                    ,
                        LastName = stf.LastName
                    ,
                        Date_Created = stf.Date_Created
                    ,
                        Melli = stf.Melli
                    ,
                        Mobile = stf.Mobile
                    ,
                        Salary = stf.Salary
                    ,
                        Type = "مربی"
                             ,
                        StaffID = stf.StaffID + 1
                        ,
                        ManagerID = 1
                    };
                    db.Staffs.Add(ins);
                    db.SaveChanges();
                    MessageBox.Show("به عنوان مربی ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                    _datagridStaff.ItemsSource = db.Staffs.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("هیچ رکوردی انتخاب نشده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void _btnGiveClassLocater_Click(object sender, RoutedEventArgs e)
        {
            _datagridClassesGiveClass.Visibility = Visibility.Visible;
            _datagridStaffGiveClass.Visibility = Visibility.Visible;
            _datagridStaff.Visibility = Visibility.Hidden;
            _btnNewStaff.Visibility = Visibility.Hidden;
            _btnEditStaff.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Hidden;
            _btnBackDatagrids.Visibility = Visibility.Visible;
            _btnMakeIns.Visibility = Visibility.Hidden;
            _btnGiveClass.Visibility = Visibility.Visible;
            _stkTxT.Visibility = Visibility.Visible;
            _datagridClassesGiveClass.ItemsSource = db.Classes.ToList();
            _datagridStaffGiveClass.ItemsSource = db.Staffs.Where(x => x.Type == "مربی").ToList();
        }

        private void _btnBackDatagrids_Click(object sender, RoutedEventArgs e)
        {
            _datagridClassesGiveClass.Visibility = Visibility.Hidden;
            _datagridStaffGiveClass.Visibility = Visibility.Hidden;
            _datagridStaff.Visibility = Visibility.Visible;
            _btnNewStaff.Visibility = Visibility.Visible;
            _btnEditStaff.Visibility = Visibility.Visible;
            _btnLocater.Visibility = Visibility.Visible;
            _btnBackDatagrids.Visibility = Visibility.Hidden;
            _btnMakeIns.Visibility = Visibility.Visible;
            _btnGiveClass.Visibility = Visibility.Hidden;
            _stkTxT.Visibility = Visibility.Hidden;
        }

        private void _btnGiveClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GymDbContexts db = new GymDbContexts();
                Class cl = (Class)(_datagridClassesGiveClass.SelectedItem);
                Instructor ins = (Instructor)(_datagridStaffGiveClass.SelectedItem);
                var record = db.Classes.Single(x => x.ClassID == cl.ClassID);
                if (record.InstructorID == null && record.InstructorID != ins.StaffID)
                {
                    record.InstructorID = ins.StaffID;
                    db.SaveChanges();
                    MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                    _datagridClassesGiveClass.ItemsSource = db.Classes.ToList();
                    _datagridStaffGiveClass.ItemsSource = db.Staffs.Where(x => x.Type == "مربی").ToList();
                }
                else
                {
                    MessageBox.Show("این فرد قبلا به عنوان مربی برای این کلاس ثبت شده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("هیج موردی انتخاب نشده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _btnLocater_Click(object sender, RoutedEventArgs e)
        {
            _btnNewStaff.Visibility = Visibility.Hidden;
            _btnEditStaff.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Hidden;
            _btnGiveClassLocater.Visibility = Visibility.Hidden;
            _btnMakeIns.Visibility = Visibility.Hidden;
            _cmbSearchPrio.Visibility = Visibility.Visible;
            _txtSearchStaff.Visibility = Visibility.Visible;
            _btnBack.Visibility = Visibility.Visible;
            _btnSearchStaff.Visibility = Visibility.Visible;
            _cmbSearchPrio.SelectedIndex = 0;
        }

        private void _btnBack_Click(object sender, RoutedEventArgs e)
        {
            _btnNewStaff.Visibility = Visibility.Visible;
            _btnEditStaff.Visibility = Visibility.Visible;
            _btnLocater.Visibility = Visibility.Visible;
            _btnGiveClassLocater.Visibility = Visibility.Visible;
            _btnMakeIns.Visibility = Visibility.Visible;
            _cmbSearchPrio.Visibility = Visibility.Hidden;
            _txtSearchStaff.Visibility = Visibility.Hidden;
            _btnBack.Visibility = Visibility.Hidden;
            _btnSearchStaff.Visibility = Visibility.Hidden;
        }

        private void _btnSearchStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (_cmbSearchPrio.SelectedIndex)
                {
                    case 0:
                        _datagridStaff.ItemsSource = db.Staffs.ToList();
                        break;
                    case 1:
                        {
                            _datagridStaff.ItemsSource = db.Staffs.Where(x => x.Melli.StartsWith(_txtSearchStaff.Text.Trim())).ToList();
                            break;
                        }
                    case 2:
                        {
                            _datagridStaff.ItemsSource = db.Staffs.Where(x => x.LastName.StartsWith(_txtSearchStaff.Text.Trim())).ToList();
                            break;
                        }
                    case 3:
                        {
                            _datagridStaff.ItemsSource = db.Staffs.Where(x => x.Type.Equals(_txtSearchStaff.Text.Trim())).ToList();
                            break;
                        }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
