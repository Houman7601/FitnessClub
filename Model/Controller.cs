using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class Controller
    {
        GymDbContexts db = new GymDbContexts();
        public void AddMember(Member mem)
        {
            db.Members.Add(mem);
            db.SaveChanges();
        }
    }
}
