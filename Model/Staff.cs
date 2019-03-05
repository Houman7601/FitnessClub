using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
     public class Staff
    {
        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffID { get; set; }
        public string Melli { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Birthdate { get; set; }
        public string Salary { get; set; }
        public string Type { get; set; }
        public string Date_Created { get; set; }

        
        public int? ManagerID { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
