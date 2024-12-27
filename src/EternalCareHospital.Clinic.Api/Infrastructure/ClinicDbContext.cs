using EternalCareHospital.Clinic.Domain.Entities;
using EternalCareHospital.Clinic.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EternalCareHospital.Clinic.Api.Infrastructure
{
    public class ClinicDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ConsultationEventData> Consultations { get; set; }
        //public DbSet<Consultation> Consultations { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Consultation>(consultation =>
        //    {
        //        consultation.HasKey(x => x.Id);

        //        consultation
        //            .Property(x => x.PatientId)
        //            .HasConversion(v => v.Value, v => new PatientId(v));

        //        consultation.OwnsOne(x => x.Diagnosis);
        //        consultation.OwnsOne(x => x.Treatment);
        //        consultation.OwnsOne(x => x.CurrentWeight);
        //        consultation.OwnsOne(x => x.When);

        //        consultation.OwnsMany(c => c.AdministeredDrugs, a =>
        //        {
        //            a.WithOwner().HasForeignKey("ConsultationId");
        //            a.OwnsOne(d => d.DrugId);
        //            a.OwnsOne(d => d.Dose);
        //        });

        //        consultation.OwnsMany(c => c.VitalSignReadings, v =>
        //        {
        //            v.WithOwner().HasForeignKey("ConsultationId");
        //        });
        //    });
        //}
    }
}