using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class GymDbInitializer : DropCreateDatabaseIfModelChanges<GymDbContexts>
    {
        protected override void Seed(GymDbContexts context)
        {         
            User admin = new User()
            {
                Username = "admin"
               ,
                Password = "1234"
               ,
                Type = "مدیر"
            };

            Manager mg = new Manager()
            {
                ManagerId = 1
                ,
                FirstName = "فرید"
                ,
                LastName = "محمدی"
                ,
                Melli = "3241627432"
                ,
                Birthdate = "1366/4/4"
                ,
                Mobile = "09121862848"
            };
            context.Users.Add(admin);
            context.Managers.Add(mg);
        }
    }
}
