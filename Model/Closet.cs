using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Closet
    {
        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Closet_id { get; set; }
        public string Duration { get; set; }
        public string Res_Start { get; set; }
        public virtual Member Member { get; set; }
        public string Membership_Number { get; set; }
    }
}
