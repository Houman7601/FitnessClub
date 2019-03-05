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
    /// Interaction logic for Edit_Eq.xaml
    /// </summary>
    public partial class Edit_Eq : Window
    {

        #region Eq_Edit
        public Equipment Eq_Edit
        {
            get { return (Equipment)GetValue(Eq_EditProperty); }
            set { SetValue(Eq_EditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Eq_Edit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Eq_EditProperty =
            DependencyProperty.Register("Eq_Edit", typeof(Equipment), typeof(Edit_Eq), new PropertyMetadata(new Equipment()));
        #endregion
        GymDbContexts db = new GymDbContexts();
        public Edit_Eq(Equipment eq)
        {
            Eq_Edit = eq;
            InitializeComponent();
            DataContext = this;
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = db.Equipments.Single(x => x.Eq_id == Eq_Edit.Eq_id);

                query.Eq_Name = _txtName.Text.Trim();

                query.Buy_Date = _txtBuyDate.Text.Trim();

                query.Company = _txtCompany.Text.Trim();

                query.Condition = _txtCondition.Text.Trim();

                query.Cost = _txtCost.Text.Trim();

                query.Eq_Number = _txtNumber.Text.Trim();

                query.Eq_Type = _txtType.Text.Trim();

                query.Weight = _txtWeight.Text.Trim();
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

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
