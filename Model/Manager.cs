using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Manager
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ManagerId { get; set; }
        public string Melli { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Birthdate { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
    }
}
