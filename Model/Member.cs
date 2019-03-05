using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Member
    {

        public Member()
        {
            Closet = new HashSet<Closet>();
            MembersClasses = new HashSet<MemberClass>();
        }

        [Key]
        public string Membership_Number { get; set; }
        public string Melli_Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Paid_fee { get; set; }
        public string Debt_fee { get; set; }
        public string Mobile { get; set; }
        public string Condition { get; set; }
        public string Address { get; set; }
        public string Date_Created { get; set; }
        public string Duration { get; set; }
        public virtual ICollection<Closet> Closet { get; set; }
        public virtual ICollection<MemberClass> MembersClasses { get; set; }
    }
}
