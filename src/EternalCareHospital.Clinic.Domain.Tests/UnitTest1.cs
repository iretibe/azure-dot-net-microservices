using EternalCareHospital.Clinic.Domain.Entities;
using EternalCareHospital.Clinic.Domain.Enums;
using EternalCareHospital.Clinic.Domain.ValueObjects;

namespace EternalCareHospital.Clinic.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Consultation_Should_Be_Open()
        {
            var consultation = new Consultation(Guid.NewGuid());

            Assert.True(consultation.Status == ConsultationStatus.Open);
        }

        [Fact]
        public void Consultation_Should_Not_Have_Ended_TimeStamp()
        {
            var consultation = new Consultation(Guid.NewGuid());

            //Assert.Null(consultation.EndedAt);
            Assert.Null(consultation.When.EndedAt);
        }

        [Fact]
        public void Consultation_Should_Not_End_When_Missing_Data()
        {
            var consultation = new Consultation(Guid.NewGuid());

            Assert.Throws<InvalidOperationException>(consultation.End);
        }

        [Fact]
        public void Consultation_Should_End_With_Complete_Data()
        {
            var consultation = new Consultation(Guid.NewGuid());

            consultation.SetTreatment("Treatment");
            consultation.SetDiagnosis("Diagnosis");
            consultation.SetWeight(18.5m);
            consultation.End();

            Assert.True(consultation.Status == ConsultationStatus.Closed);
        }

        [Fact]
        public void Consultation_Should_Not_Allow_Weight_Updates_When_Closed()
        {
            var consultation = new Consultation(Guid.NewGuid());

            consultation.SetTreatment("Treatment");
            consultation.SetDiagnosis("Diagnosis");
            consultation.SetWeight(18.5m);
            consultation.End();

            Assert.Throws<InvalidOperationException>(() => consultation.SetWeight(19.2m));
        }

        [Fact]
        public void Consultation_Should_Not_Allow_Diagnosis_Updates_When_Closed()
        {
            var consultation = new Consultation(Guid.NewGuid());

            consultation.SetTreatment("Treatment");
            consultation.SetDiagnosis("Diagnosis");
            consultation.SetWeight(18.5m);
            consultation.End();

            Assert.Throws<InvalidOperationException>(() => consultation.SetDiagnosis("New diagnosis"));
        }

        [Fact]
        public void Consultation_Should_Not_Allow_Treatment_Updates_When_Closed()
        {
            var consultation = new Consultation(Guid.NewGuid());

            consultation.SetTreatment("Treatment");
            consultation.SetDiagnosis("Diagnosis");
            consultation.SetWeight(18.5m);
            consultation.End();

            Assert.Throws<InvalidOperationException>(() => consultation.SetDiagnosis("New treatment"));
        }

        [Fact]
        public void Consultation_Should_Administer_Drug()
        {
            var drugId = new DrugId(Guid.NewGuid());
            var consultation = new Consultation(Guid.NewGuid());

            consultation.AdministerDrug(drugId, new Dose(1, UnitOfMeasure.tablet));
            
            Assert.True(consultation.AdministeredDrugs.Count == 1);
            Assert.True(consultation.AdministeredDrugs.First().DrugId == drugId);
        }

        [Fact]
        public void Consultation_Should_Register_VitalSigns()
        {
            var consultation = new Consultation(Guid.NewGuid());
            IEnumerable<VitalSigns> vitalSigns = [ new VitalSigns(DateTime.UtcNow, 38.8m, 100, 120)];

            consultation.RegisterVitalSigns(vitalSigns);

            Assert.True(consultation.VitalSignReadings.Count == 1);
            Assert.True(consultation.VitalSignReadings.First() == vitalSigns.First());
        }

        [Fact]
        public void DateTimeRange_Should_Be_Ongoing()
        {
            var theDate = new DateTime(2027, 12, 24, 22, 0, 0);
            var dr1 = new DateTimeRange(theDate);

            Assert.Equal("Ongoing", dr1.Duration);
        }

        [Fact]
        public void DateTimeRange_Should_Be_Ongoings()
        {
            var theDate = new DateTime(2027, 12, 24, 22, 0, 0);
            var dr1 = new DateTimeRange(theDate);
            var dr2 = new DateTimeRange(theDate);

            Assert.Equal(dr1, dr2);
        }
    }
}
