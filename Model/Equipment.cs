using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Equipment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Eq_id { get; set; }
        public string Eq_Number { get; set; }
        public string Eq_Name { get; set; }
        public string Eq_Type { get; set; }
        public string Buy_Date { get; set; }
        public string Company { get; set; }
        public string Condition { get; set; }
        public string Cost { get; set; }
        public string Weight { get; set; }


        public int? ClassID { get; set; }
        public virtual Class Class { get; set; }

    }
}
