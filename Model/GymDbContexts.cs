using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.Model
{
    public class GymDbContexts : DbContext
    {
        public virtual DbSet<Closet> Closets { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<MemberClass> MemberesClasses { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        public GymDbContexts()
            : base("GymDataBase")
        {
            Database.SetInitializer(new GymDbInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                    .HasMany(e => e.Closet)
                    .WithOptional(e => e.Member)
                    .HasForeignKey(e => e.Membership_Number)
                    .WillCascadeOnDelete();

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Equipments)
                .WithOptional(e => e.Class)
                .HasForeignKey(e => e.ClassID)
                .WillCascadeOnDelete();



            modelBuilder.Entity<Manager>()
                .HasMany(e => e.Staff)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.ManagerID)
                .WillCascadeOnDelete();


            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.Class)
                .WithOptional(e => e.Instructor)
                .HasForeignKey(e => e.InstructorID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Instructor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Instructor");
            });
        }
    }
}
