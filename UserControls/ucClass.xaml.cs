using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for ucClass.xaml
    /// </summary>
    public partial class ucClass : UserControl
    {
        GymDbContexts db = new GymDbContexts();
        MyData md = new MyData();
        public ucClass()
        {
            InitializeComponent();
            _datagridClasses.ItemsSource = db.Classes.ToList();
        }


        //public ObservableCollection<Member> CastingOperation()
        //{
        //    md.strsql = "select * from Members where Members.Membership_Number not in(select MemberClasses.Membership_Number from MemberClasses)";
        //    ObservableCollection<Member> list = new ObservableCollection<Member>();
        //    foreach (DataRow row in md.ShowData().Rows)
        //    {
        //        Member mem = new Member();
        //        mem.FirstName = row["FirstName"].ToString();
        //        mem.LastName = row["LastName"].ToString();
        //        mem.Membership_Number = row["Membership_Number"].ToString();
        //        mem.Melli_Code = row["Melli_Code"].ToString();
        //        list.Add(mem);
        //    }
        //    return list;
        //}

        private void _btnNewClass_Click(object sender, RoutedEventArgs e)
        {
            AddClass win = new AddClass();
            win.ShowDialog();
            _datagridClasses.ItemsSource = db.Classes.ToList();
        }

        private void _btnDeleteRowClass_Click(object sender, RoutedEventArgs e)
        {
            var msg = MessageBox.Show("آیا میخواهید حذف شود؟", "پیغام", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            switch (msg)
            {
                case MessageBoxResult.OK:
                    {
                        var selected = _datagridClasses.SelectedItem;
                        Class cl = (Class)selected;
                        db.Classes.Remove(cl);
                        db.SaveChanges();
                        _datagridClasses.ItemsSource = db.Classes.ToList();
                        break;
                    }
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void _btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            var selected = _datagridClasses.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("هیچ موردی انتخاب نشده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Class cl = (Class)selected;
                EditClass win = new EditClass(cl);
                win.ShowDialog();
                _datagridClasses.ItemsSource = db.Classes.ToList();
            }
        }

        private void _btnLocater_Click(object sender, RoutedEventArgs e)
        {
            _btnNewClass.Visibility = Visibility.Hidden;
            _btnEditClass.Visibility = Visibility.Hidden;
            _btnSignUpLocater.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Hidden;
            _cmbSearchPrio.Visibility = Visibility.Visible;
            _txtSearchCl.Visibility = Visibility.Visible;
            _btnSearchCl.Visibility = Visibility.Visible;
            _btnBack.Visibility = Visibility.Visible;
            _cmbSearchPrio.SelectedIndex = 0;
        }

        private void _btnBack_Click(object sender, RoutedEventArgs e)
        {
            _btnNewClass.Visibility = Visibility.Visible;
            _btnEditClass.Visibility = Visibility.Visible;
            _btnSignUpLocater.Visibility = Visibility.Visible;
            _btnLocater.Visibility = Visibility.Visible;
            _cmbSearchPrio.Visibility = Visibility.Hidden;
            _txtSearchCl.Visibility = Visibility.Hidden;
            _btnSearchCl.Visibility = Visibility.Hidden;
            _btnBack.Visibility = Visibility.Hidden;
        }

        private void _btnSearchCl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (_cmbSearchPrio.SelectedIndex)
                {
                    case 0:
                        _datagridClasses.ItemsSource = db.Classes.ToList();
                        break;
                    case 1:
                        {
                            _datagridClasses.ItemsSource = db.Classes.Where(x => x.Type.StartsWith(_txtSearchCl.Text.Trim())).ToList();
                            break;
                        }
                    case 2:
                        {
                            int a = Convert.ToInt32(_txtSearchCl.Text.Trim());
                            _datagridClasses.ItemsSource = db.Classes.Where(x => x.Size.Equals(a)).ToList();
                            break;
                        }
                    case 3:
                        {
                            _datagridClasses.ItemsSource = db.Classes.Where(x => x.Date.StartsWith(_txtSearchCl.Text.Trim())).ToList();
                            break;
                        }
                }
            }
            catch (Exception)
            {

            }
        }

        private void _btnSignUpLocater_Click(object sender, RoutedEventArgs e)
        {



            _stkTxT.Visibility = Visibility.Visible;
            _datagridClassesSignUp.ItemsSource = db.Classes.Where(x => x.Size > 0).ToList();



            _datagridMembersSignUp.ItemsSource = db.Members.ToList();



            _btnNewClass.Visibility = Visibility.Hidden;
            _btnEditClass.Visibility = Visibility.Hidden;
            _btnSignUpLocater.Visibility = Visibility.Hidden;
            _btnLocater.Visibility = Visibility.Hidden;
            _datagridClasses.Visibility = Visibility.Hidden;
            _datagridClassesSignUp.Visibility = Visibility.Visible;
            _datagridMembersSignUp.Visibility = Visibility.Visible;
            _btnSignUp.Visibility = Visibility.Visible;
            _btnBackDataGrid.Visibility = Visibility.Visible;
        }

        private void _btnBackDataGrid_Click(object sender, RoutedEventArgs e)
        {
            _stkTxT.Visibility = Visibility.Hidden;
            _btnNewClass.Visibility = Visibility.Visible;
            _btnEditClass.Visibility = Visibility.Visible;
            _btnSignUpLocater.Visibility = Visibility.Visible;
            _btnLocater.Visibility = Visibility.Visible;
            _datagridClasses.Visibility = Visibility.Visible;
            _datagridClassesSignUp.Visibility = Visibility.Hidden;
            _datagridMembersSignUp.Visibility = Visibility.Hidden;
            _btnSignUp.Visibility = Visibility.Hidden;
            _btnBackDataGrid.Visibility = Visibility.Hidden;
        }

        private void _btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            GymDbContexts db = new GymDbContexts();
            try
            {
                var SelectedCl = _datagridClassesSignUp.SelectedItem;
                var SelectedMem = _datagridMembersSignUp.SelectedItem;
                Class cl = (Class)SelectedCl;
                Member mem = (Member)SelectedMem;

                if (SelectedCl == null || SelectedMem == null)
                {
                    MessageBox.Show("یک عضو و یک کلاس انتخاب کنید", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (cl.Size == 0)
                {
                    MessageBox.Show("ظرفیت کلاس پر است", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MemberClass mc = new MemberClass()
                {
                    ClassID = cl.ClassID
                    ,
                    Membership_Number = mem.Membership_Number
                };

                var classreq = db.Classes.Single(x => x.ClassID == cl.ClassID);
                Class cll = (Class)classreq;
                cll.Size -= 1;

                db.MemberesClasses.Add(mc);
                db.SaveChanges();
                MessageBox.Show("ثبت شد", "پیغام", MessageBoxButton.OK, MessageBoxImage.Information);
                _datagridClassesSignUp.ItemsSource = db.Classes.Where(x => x.Size > 0).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("کلاس مورد نظر برای این عضو از قبل ثبت شده", "پیغام", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}
    }
}
