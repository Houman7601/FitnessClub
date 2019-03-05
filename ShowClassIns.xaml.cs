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
using System.Windows.Shapes;
using WpfApplication3.Model;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for ShowClassIns.xaml
    /// </summary>
    public partial class ShowClassIns : Window
    {
        Instructor INS = new Instructor();
        public ShowClassIns(Instructor ins)
        {
            INS = ins;
            InitializeComponent();
            Initializer();
        }

        public void Initializer()
        {
            MyData md = new MyData();
            md.strsql = "select ClassID,Time,Date,Cost,Classes.Type from Instructor,Classes where Instructor.StaffID = Classes.InstructorID and Instructor.StaffID = " + INS.StaffID + "";

            ObservableCollection<Class> list = new ObservableCollection<Class>();
            foreach (DataRow item in md.ShowData().Rows)
            {
                Class cl = new Class()
                {
                    ClassID = int.Parse(item["ClassID"].ToString())
                ,
                    Cost = int.Parse(item["Cost"].ToString())
                   ,
                    Date = item["Date"].ToString()
                   ,
                    Time = item["Time"].ToString()
                   ,
                    Type = item["Type"].ToString()
                };
                list.Add(cl);
                _datagridClasses.ItemsSource = list;
            }
        }

        private void darg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
