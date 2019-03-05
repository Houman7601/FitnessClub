using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApplication3.Model;

namespace WpfApplication3
{
    public partial class ReportViewer : Form
    {
        GymDbContexts db = new GymDbContexts();
        string MemberNumber;
        public ReportViewer(string memnum)
        {
            MemberNumber = memnum;
            InitializeComponent();
            QuerySender();
        }


        public void QuerySender()
        {                     
            CrystalReport car = new CrystalReport();
            car.SetDataSource(db.Members.Where(x=> x.Membership_Number == MemberNumber));
            this.crystalReportViewer1.ReportSource = car;
        }
    }
}
