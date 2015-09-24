namespace DataAccessLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Framework;

    public partial class PatientContext : DbContext
    {
        public PatientContext()
            : base("name=PatientContext")
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.SexOfThePatient)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
