using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Class
    {
        public Class()
        {
            MembersClasses = new HashSet<MemberClass>();
        }

        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int? Cost { get; set; }
        public int? Size { get; set; }
        public string Type { get; set; }


        public virtual ICollection<MemberClass> MembersClasses { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }


        [ForeignKey("Instructor")]
        public int? InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
