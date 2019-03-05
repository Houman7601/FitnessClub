using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using System.Windows.Threading;
using WpfApplication3.Model;
using WpfApplication3.UserControls;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {      
        ucClass ucc = new ucClass();
        ucWorkers ucw = new ucWorkers();
        ucMembers uc = new ucMembers();
        ucEquipment uce = new ucEquipment();
        TabChanger tab = new TabChanger();
        GymDbContexts db = new GymDbContexts();
        UcManager ucm = new UcManager();
        User UserInf = new User();
        ucQuery ucq = new ucQuery();
        public Main(User us)
        {
            UserInf = us;
            InitializeComponent();
            tab.CallChildiren(_grdContent, uc);
            _txtAllMemberCount.Text = db.Members.Count().ToString();
            _txbHazer.Text = db.Members.Where(x => x.Condition == "حاضر").Count().ToString();
            DateSet();
        }

        public void DateSet()
        {
            PersianDateTime pdt = PersianDateTime.Now;
            _txtdate.Text = pdt.Date.ToLongDateString();
        }

        private void _btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void _btnMemberTab_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, uc);
        }

        private void _btnucWorker_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, ucw);
        }

        private void _btnClassTab_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, ucc);
        }

        private void _btnManagerTab_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, ucm);
        }

        private void _btnEqTab_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, uce);
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void _btnPassChange_Click(object sender, RoutedEventArgs e)
        {
            ChangePass win = new ChangePass(UserInf);
            win.ShowDialog();
        }

        private void _btnQuery_Click(object sender, RoutedEventArgs e)
        {
            tab.CallChildiren(_grdContent, ucq);
        }

        private void _drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
