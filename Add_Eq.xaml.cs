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
    /// Interaction logic for Add_Eq.xaml
    /// </summary>
    public partial class Add_Eq : Window
    {
        GymDbContexts db = new GymDbContexts();
        public Add_Eq()
        {
            InitializeComponent();
        }

        public void txtClear()
        {
            _txtBuyDate.Clear();
            _txtCompany.Clear();
            _txtCondition.Clear();
            _txtCost.Clear();
            _txtID.Clear();
            _txtName.Clear();
            _txtNumber.Clear();
            _txtType.Clear();
            _txtWeight.Clear();
        }

        private void drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_txtID.Text.Trim() == "")
                {
                    MessageBox.Show("فیلد کد دستگاه نمیتواند خالی باشد", "پغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (_txtName.Text.Trim() == "")
                {
                    MessageBox.Show("فیلد نام دستگاه نمیتواند خالی باشد", "پغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    Equipment eq = new Equipment()
                    {
                        Eq_id = _txtID.Text.Trim()
                ,
                        Eq_Name = _txtName.Text.Trim()
                ,
                        Buy_Date = _txtBuyDate.Text.Trim()
                ,
                        Company = _txtCompany.Text.Trim()
                ,
                        Condition = _txtCondition.Text.Trim()
                ,
                        Cost = _txtCost.Text.Trim()
                ,
                        Eq_Number = _txtNumber.Text.Trim()
                ,
                        Eq_Type = _txtType.Text.Trim()
                ,
                        Weight = _txtWeight.Text.Trim()
                    };
                    db.Equipments.Add(eq);
                    db.SaveChanges();
                    txtClear();
                    MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطا", "پغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _txtID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                key >= 74 && key <= 83 || key == 2);
        }

        private void _txtNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                key >= 74 && key <= 83 || key == 2);
        }

        private void _txtWeight_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                key >= 74 && key <= 83 || key == 2);
        }
    }
}
