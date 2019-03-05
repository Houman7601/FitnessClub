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
    /// Interaction logic for MainUser.xaml
    /// </summary>
    public partial class MainUser : Window
    {
        ucClass ucc = new ucClass();
        ucMembers uc = new ucMembers();
        TabChanger tab = new TabChanger();
        GymDbContexts db = new GymDbContexts();
        User UserInf = new User();
        public MainUser(User user)
        {
            UserInf = user;
            InitializeComponent();
            DateSet();
            _txtAllMemberCount.Text = db.Members.Count().ToString();
            _txbHazer.Text = db.Members.Where(x => x.Condition == "حاضر").Count().ToString();
            tab.CallChildiren(_grdContent, uc);
        }

        public void DateSet()
        {
            PersianDateTime pdt = PersianDateTime.Now;
            _txtdate.Text = pdt.Date.ToLongDateString();
        }
        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void _btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void _btnMemberTab_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, uc);
        }

        private void _btnClassTab_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, ucc);
        }

        private void _btnPassChange_Click(object sender, RoutedEventArgs e)
        {
            ChangePass win = new ChangePass(UserInf);
            win.ShowDialog();
        }

        private void _drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void _btnReport_Click(object sender, RoutedEventArgs e)
        {
            MemberReport win = new MemberReport();
            win.ShowDialog();
        }
    }
}
