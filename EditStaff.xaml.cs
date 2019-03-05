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
    /// Interaction logic for EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {

        #region Edit_Staff
        public Staff Edit_Staff
        {
            get { return (Staff)GetValue(Edit_StaffProperty); }
            set { SetValue(Edit_StaffProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Edit_Staff.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Edit_StaffProperty =
            DependencyProperty.Register("Edit_Staff", typeof(Staff), typeof(EditStaff), new PropertyMetadata(new Staff()));
        #endregion
        GymDbContexts db = new GymDbContexts();
        public EditStaff(Staff st)
        {
            Edit_Staff = st;
            InitializeComponent();
            DataContext = this;
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Staffs.Single(x => x.StaffID == Edit_Staff.StaffID);

            query.Address = _txtAddress.Text.Trim();

            query.Birthdate = _txtBirthDate.Text.Trim();

            query.FirstName = _txtFName.Text.Trim();

            query.LastName = _txtLName.Text.Trim();

            query.Melli = _txtMelli.Text.Trim();

            query.Mobile = _txtMobile.Text.Trim();

            query.Salary = _txtSalary.Text.Trim();

            query.Date_Created = _txtDateCreated.Text.Trim();

            db.SaveChanges();
            MessageBox.Show("تغییرات با موفقیت اعمال شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
