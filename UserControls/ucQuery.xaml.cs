using System;
using System.Collections.Generic;
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
    /// Interaction logic for ucQuery.xaml
    /// </summary>
    public partial class ucQuery : UserControl
    {
        MyData md = new MyData();
        public ucQuery()
        {
            InitializeComponent();
        }

        public void Validation(DataTable dt)
        {          
            QueryShow win = new QueryShow(dt);
            win.ShowDialog();
        }


        private void _btnShow_Click(object sender, RoutedEventArgs e)
        {         
            if(_q1.IsChecked == true)
            {
                md.strsql = "select * from Members,MemberClasses,Classes,Instructor where MemberClasses.Membership_Number = Members.Membership_Number and MemberClasses.ClassID = Classes.ClassID and Classes.InstructorID = Instructor.StaffID and StaffID = 2";
                Validation(md.ShowData());
            }
            else if (_q2.IsChecked == true)
            {
                md.strsql = "select* from Members where Members.Membership_Number in (select Members.Membership_Number from Members,Closets,MemberClasses,Equipments,Classes where Members.Membership_Number = MemberClasses.Membership_Number and Classes.ClassID = MemberClasses.ClassID and Members.Membership_Number = Closets.Membership_Number and Equipments.ClassID = Classes.ClassID and Equipments.Eq_id = '12')";
                Validation(md.ShowData());
            }
            else if (_q3.IsChecked == true)
            {
                md.strsql = "select Instructor.FirstName,Instructor.LastName from Instructor,Classes,MemberClasses,Members where Instructor.StaffID = Classes.InstructorID and MemberClasses.Membership_Number = Members.Membership_Number and Classes.ClassID = MemberClasses.ClassID group by Instructor.LastName,Instructor.FirstName having COUNT(*) > 3";
                Validation(md.ShowData());
            }
            else if (_q4.IsChecked == true)
            {
                md.strsql = "select * from Classes,Members,MemberClasses where Classes.ClassID = MemberClasses.ClassID and MemberClasses.Membership_Number = Members.Membership_Number and Classes.Date = 'دوشنبه' and Members.Debt_fee = '0'";
                Validation(md.ShowData());
            }
            else if(_q5.IsChecked == true)
            {
                md.strsql = "select Classes.ClassID from Classes,Instructor,Equipments where Classes.InstructorID = Instructor.StaffID and Equipments.ClassID = Classes.ClassID and Equipments.Company = 'ایران فیتنس' and Instructor.LastName = 'رضایی'";
                Validation(md.ShowData());
            }
            else if(_q6.IsChecked == true)
            {
                md.strsql = "select Distinct Members.FirstName,Members.LastName from Members,MemberClasses where MemberClasses.Membership_Number = Members.Membership_Number and MemberClasses.ClassID in (select MemberClasses.ClassID from Members,MemberClasses where Members.Membership_Number = MemberClasses.Membership_Number and MemberClasses.Membership_Number in (select Members.Membership_Number from Members where Members.Membership_Number = '143'))";
                Validation(md.ShowData());
            } 
            else if(_q7.IsChecked == true)
            {
                md.strsql = "select Instructor.StaffID from Instructor,MemberClasses,Members,Classes where Instructor.StaffID = Classes.InstructorID and Members.Membership_Number = MemberClasses.Membership_Number and Classes.ClassID = MemberClasses.ClassID and Members.Debt_fee = '0' and Instructor.Salary > 100 and Instructor.Salary < 200";
                Validation(md.ShowData());
            }
        }
    }
}
