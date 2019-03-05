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
    /// Interaction logic for EditClass.xaml
    /// </summary>
    public partial class EditClass : Window
    {

        #region Edit_Class
        public Class CL
        {
            get { return (Class)GetValue(CLProperty); }
            set { SetValue(CLProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CL.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CLProperty =
            DependencyProperty.Register("CL", typeof(Class), typeof(EditClass), new PropertyMetadata(new Class()));
        #endregion

        GymDbContexts db = new GymDbContexts();
        public EditClass(Class cl)
        {
            CL = cl;
            InitializeComponent();
            DataContext = this;
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
            int a = Convert.ToInt32(_txtClassID.Text.Trim());
            var record = db.Classes.Single(x=>x.ClassID == a);

            record.Cost = Convert.ToInt32(_txtClassCost.Text.Trim());

                record.Date = _txtClassDays.Text.Trim();

                record.Size = Convert.ToInt32(_txtClassSize.Text.Trim());

                record.Time = _txtClassTime.Text.Trim();

                record.Type = _txtClassType.Text.Trim();

            db.SaveChanges();
            MessageBox.Show("تغییرات اعمال شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
