using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class MemberClass
    {
        [Key , Column(Order = 0)]
        [ForeignKey("Member")]
        public string Membership_Number { get; set; }
        public virtual Member Member { get; set; }


        [Key , Column(Order = 1)]
        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }

    }
}
