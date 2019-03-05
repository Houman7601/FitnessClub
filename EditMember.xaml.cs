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
    /// Interaction logic for EditMember.xaml
    /// </summary>
    public partial class EditMember : Window
    {

        #region Mem_Edit
        public Member Mem_Edit
        {
            get { return (Member)GetValue(Mem_EditProperty); }
            set { SetValue(Mem_EditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mem_Edit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Mem_EditProperty =
            DependencyProperty.Register("Mem_Edit", typeof(Member), typeof(EditMember), new PropertyMetadata(new Member()));
        #endregion


        GymDbContexts db = new GymDbContexts();
        public EditMember(Member mem)
        {
            Mem_Edit = mem;
            InitializeComponent();
            DataContext = this;
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = db.Members.Single(x => x.Membership_Number == _txtMemberNumber.Text.Trim());

                query.FirstName = _txtFName.Text.Trim();

                query.LastName = _txtLName.Text.Trim();

                query.Melli_Code = _txtMelli.Text.Trim();

                query.Address = _txtAddress.Text.Trim();

                query.BirthDate = _txtBirthDate.Text.Trim();

                query.Date_Created = _txtDateCreated.Text.Trim();

                query.Debt_fee = _txtDebtFee.Text.Trim();

                query.Paid_fee = _txtPaidFee.Text.Trim();

                query.Duration = _txtDuration.Text.Trim();
       
                query.Mobile = _txtMobile.Text.Trim();

                query.Condition = _cmbCondition.Text;

                db.SaveChanges();
                
                MessageBox.Show("تغییرات با موفقیت اعمال شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {

            }
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

      
        private void _btnCloset_Click(object sender, RoutedEventArgs e)
        {
            ResCloset win = new ResCloset(_txtMemberNumber.Text.Trim());
            win.ShowDialog();
        }
    }
}
