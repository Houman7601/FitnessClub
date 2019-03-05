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
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        GymDbContexts db = new GymDbContexts();
        public AddStaff()
        {
            InitializeComponent();
        }

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
            _txtAddress.Clear();
            _txtBirthDate.Clear();
            _txtFName.Clear();
            _txtLName.Clear();
            _txtMelli.Clear();
            _txtMobile.Clear();
            _txtSalary.Clear();
            _txtStaffId.Clear();
        }

        public bool Validate()
        {
            if (_txtFName.Text.Trim() == "")
            {
                MessageBox.Show("فیلد نام نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtLName.Text.Trim() == "")
            {
                MessageBox.Show("فیلد نام خانوادگی نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtMelli.Text.Trim() == "")
            {
                MessageBox.Show("فیلد کد ملی نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtStaffId.Text.Trim() == "")
            {
                MessageBox.Show("فیلد شماره ی کارمند نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtStaffId.Text.Trim() != "")
            {
                int a = Convert.ToInt32(_txtStaffId.Text.Trim());
                int num = db.Staffs.Where(x => x.StaffID == a).Count();
                if (num == 1)
                {
                    MessageBox.Show("کارمند با این شماره از قبل وجود دارد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else return true;
            }
            else
            {
                return true;
            }
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
           if(Validate())
            {
                Staff st = new Staff()
                {
                    Address = _txtAddress.Text.Trim()
               ,
                    Birthdate = _txtBirthDate.Text.Trim()
               ,
                    FirstName = _txtFName.Text.Trim()
               ,
                    LastName = _txtLName.Text.Trim()
               ,
                    Melli = _txtMelli.Text.Trim()
               ,
                    Mobile = _txtMobile.Text.Trim()
               ,
                    Salary = _txtSalary.Text.Trim()
               ,
                    StaffID = Convert.ToInt32(_txtStaffId.Text.Trim())
               ,
                    Type = "معمولی"
                    ,
                    ManagerID = 1
                };
                db.Staffs.Add(st);
                db.SaveChanges();
                MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                txtClear();
            }
        }
    }
}
