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
    /// Interaction logic for AddClass.xaml
    /// </summary>
    public partial class AddClass : Window
    {
        GymDbContexts db = new GymDbContexts();
        public AddClass()
        {
            InitializeComponent();
        }

        public void txtClear()
        {
            _txtClassID.Clear();
            _txtClassSize.Clear();
            _txtClassDays.Clear();
            _txtClassTime.Clear();
            _txtClassType.Clear();
            _txtClassCost.Clear();
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
                Class cl = new Class()
                {
                    Cost = Convert.ToInt32(_txtClassCost.Text.Trim())
              ,
                    Date = _txtClassDays.Text.Trim()
              ,
                    Size = Convert.ToInt32(_txtClassSize.Text.Trim())
              ,
                    Time = _txtClassTime.Text.Trim()
              ,
                    Type = _txtClassType.Text.Trim()
              ,
                    ClassID = Convert.ToInt32(_txtClassID.Text.Trim())
                };
                db.Classes.Add(cl);
                db.SaveChanges();
                MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                txtClear();
            }
            catch (Exception)
            {

            }
        }
    }
}
