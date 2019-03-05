using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Instructor : Staff
    {
        public string Certificate { get; set; }

        public ICollection<Class> Class { get; set; }
    }
}
