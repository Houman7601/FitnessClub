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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3.Model;

namespace WpfApplication3.UserControls
{
    /// <summary>
    /// Interaction logic for UcManager.xaml
    /// </summary>
    public partial class UcManager : UserControl
    {
        public UcManager()
        {
            InitializeComponent();
        }

        private void _btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser win = new AddUser();
            win.ShowDialog();
        }

        private void btnBackup_Click(object sender, RoutedEventArgs e)
        {
           MyData md = new MyData();
            md.Backup(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyData md = new MyData();
            md.Restore();
        }

        private void _btnEditManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerShow win = new ManagerShow();
            win.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowUser win = new ShowUser();
            win.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MemberReport win = new MemberReport();
            win.ShowDialog();
        }
    }
}
