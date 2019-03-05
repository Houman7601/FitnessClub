using MD.PersianDateTime;
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
using WpfApplication3.UserControls;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Window
    {
        GymDbContexts db = new GymDbContexts();
        Controller cn = new Controller();
        public AddMember()
        {
            InitializeComponent();
            _cmbCondition.SelectedIndex = 0;
        }

        public void txtClear()
        {
            _txtFName.Clear();
            _txtLName.Clear();
            _txtMelli.Clear();
            _txtDuration.Clear();
            _txtDebtFee.Clear();
            _txtMobile.Clear();
            _txtMemberNumber.Clear();
            _txtDateCreated.Clear();
            _txtBirthDate.Clear();
            _txtPaidFee.Clear();
            _txtAddress.Clear();
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _DragBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public bool Validate()
        {
            if (_txtFName.Text.Trim() == "")
            {
                MessageBox.Show("فیلد نام نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if(_txtLName.Text.Trim() == "")
            {
                MessageBox.Show("فیلد نام خانوادگی نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtMelli.Text.Trim() == "")
            {
                MessageBox.Show("فیلد کد ملی نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtMemberNumber.Text.Trim() == "")
            {
                MessageBox.Show("فیلد شماره ی عضویت نمیتواند خالی باشد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (_txtMemberNumber.Text.Trim() != "")
            {
                int num = db.Members.Where(x => x.Membership_Number == _txtMemberNumber.Text.Trim()).Count();
                if (num == 1)
                {
                    MessageBox.Show("این شماره عضویت از قبل وجود دارد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
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
            try
            {
                if (Validate())
                {
                    Member mem = new Member()
                    {
                        FirstName = _txtFName.Text.Trim()
              ,
                        LastName = _txtLName.Text.Trim()
              ,
                        Melli_Code = _txtMelli.Text.Trim()
              ,
                        Address = _txtAddress.Text.Trim()
              ,
                        BirthDate = _txtBirthDate.Text.Trim()
              ,
                        Date_Created = _txtDateCreated.Text.Trim()
              ,
                        Debt_fee = _txtDebtFee.Text.Trim()
              ,
                        Paid_fee = _txtPaidFee.Text.Trim()
              ,
                        Duration = _txtDuration.Text.Trim()
              ,
                        Membership_Number = _txtMemberNumber.Text.Trim()
              ,
                        Mobile = _txtMobile.Text.Trim()
              ,
                        Condition = _cmbCondition.Text
                    };
                    GymDbContexts db = new GymDbContexts();
                    cn.AddMember(mem);
                    MessageBox.Show("با موفقیت ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtClear();
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnResCloset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = db.Members.Where(x => x.Membership_Number == _txtMemberNumber.Text);
                if (query != null)
                {
                    ResCloset win = new ResCloset();
                    win.ShowDialog();
                }
            }
            catch (Exception)
            {

            }
        }

        private void drag_Loaded(object sender, RoutedEventArgs e)
        {
            PersianDateTime pt = PersianDateTime.Now;
            _txtDateCreated.Text = pt.Date.ToShortDateString().ToString();
        }
    }
}
