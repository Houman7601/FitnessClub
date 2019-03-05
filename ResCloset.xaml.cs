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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for ResCloset.xaml
    /// </summary>
    public partial class ResCloset : Window
    {
        GymDbContexts db = new GymDbContexts();
        string Mem_num;
        public ResCloset(string mem_num)
        {
 
            Mem_num = mem_num;
            InitializeComponent();
            cmbitem();
        }

        public ResCloset()
        {         
            InitializeComponent();
            cmbitem();
        }

        public void cmbitem()
        {
            _cmbRCloset.Items.Clear();
            var query = db.Closets.Where(x => x.Membership_Number == null);
            foreach (var item in query)
            {
                _cmbRCloset.Items.Add(item.Closet_id);
            }
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void _btnSabt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(_cmbRCloset.Text);
                var record = db.Closets.Single(x => x.Closet_id == a);
                record.Membership_Number = Mem_num;
                record.Res_Start = _txtresDate.Text.Trim();
                record.Duration = _txtDuration.Text.Trim();
                db.SaveChanges();
                cmbitem();
                txtClear();
                MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا");
            }
        }

        public void txtClear()
        {
            _txtDuration.Clear();
            _txtresDate.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PersianDateTime dt = PersianDateTime.Now;
            _txtresDate.Text = dt.Date.ToShortDateString().ToString();
        }
    }
}
