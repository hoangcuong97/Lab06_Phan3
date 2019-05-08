namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrungTamX : DbContext
    {
        public TrungTamX()
            : base("name=TrungTamX1")
        {
        }

        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Coure> Coures { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Tuition> Tuitions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.SessionNum)
                .IsFixedLength();

            modelBuilder.Entity<Classroom>()
                .Property(e => e.Size)
                .IsFixedLength();

            modelBuilder.Entity<Classroom>()
                .Property(e => e.CSVC)
                .IsFixedLength();

            modelBuilder.Entity<Coure>()
                .HasMany(e => e.Classes)
                .WithOptional(e => e.Coure)
                .HasForeignKey(e => e.CourseID);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Shifts)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tuition>()
                .Property(e => e.ObjectsReduced)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.AccountType)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
