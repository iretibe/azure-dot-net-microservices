using EternalCareHospital.Clinic.Domain.Enums;
using EternalCareHospital.Clinic.Domain.Events;
using EternalCareHospital.Clinic.Domain.ValueObjects;
using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Entities
{
    public class Consultation : AggregateRoot
    {
        private readonly List<DrugAdministration> administeredDrugs = new();
        private readonly List<VitalSigns> vitalSignsReadings = new();

        public Text? Diagnosis { get; private set; }
        public Text? Treatment { get; private set; }
        public PatientId PatientId { get; private set; }
        public Weight? CurrentWeight { get; private set; }
        public ConsultationStatus Status { get; private set; }
        //public DateTime StartedAt { get; init; }
        //public DateTime? EndedAt { get; private set; }
        public DateTimeRange When { get; set; }
        public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => administeredDrugs;
        public IReadOnlyCollection<VitalSigns> VitalSignReadings => vitalSignsReadings;

        public Consultation(PatientId patientId)
        {
            ApplyDomainEVent(new ConsultationStarted(Guid.NewGuid(), patientId, DateTime.UtcNow));
            //Id = Guid.NewGuid();
            //PatientId = patientId;
            //Status = ConsultationStatus.Open;
            ////StartedAt = DateTime.UtcNow;
            //When = DateTime.UtcNow;
        }

        public Consultation(IEnumerable<IDomainEvent> domainEvents)
        {
            Load(domainEvents);
        }

        public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
        {
            ValidateConsultationStatus();
            vitalSignsReadings.AddRange(vitalSigns);
        }

        public void AdministerDrug(DrugId drugId, Dose dose)
        {
            ValidateConsultationStatus();

            var newDrugAdministration = new DrugAdministration(drugId, dose);
            administeredDrugs.Add(newDrugAdministration);
        }

        public void End()
        {
            ApplyDomainEVent(new ConsultationEnded(Id, DateTime.UtcNow));

            //ValidateConsultationStatus();

            //if (Diagnosis == null || Treatment == null || CurrentWeight == null)
            //{
            //    throw new InvalidOperationException("The consultation cannot be ended!");
            //}

            //Status = ConsultationStatus.Closed;
            ////EndedAt = DateTime.UtcNow;
            //When = new DateTimeRange(When.StartedAt, DateTime.UtcNow);
        }

        public void SetWeight(Weight weight)
        {
            ApplyDomainEVent(new WeightUpdated(Id, weight));
            //ValidateConsultationStatus();
            //CurrentWeight = weight;
        }

        public void SetDiagnosis(Text diagnosis)
        {
            ApplyDomainEVent(new DiagnosisUpdated(Id, diagnosis));
            //ValidateConsultationStatus();
            //Diagnosis = diagnosis;
        }

        public void SetTreatment(Text treatment)
        {
            ApplyDomainEVent(new TreatmentUpdated(Id, treatment));
            //ValidateConsultationStatus();
            //Treatment = treatment;
        }

        private void ValidateConsultationStatus()
        {
            if (Status == ConsultationStatus.Closed)
            {
                throw new InvalidOperationException("The consultation is already closed!");
            }
        }

        protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case ConsultationStarted e:
                    Id = e.Id;
                    PatientId = e.PatientId;
                    Status = ConsultationStatus.Open;
                    When = e.StartedAt;
                    break;

                case DiagnosisUpdated e:
                    ValidateConsultationStatus();
                    Diagnosis = e.Diagnosis;
                    break;

                case TreatmentUpdated e:
                    ValidateConsultationStatus();
                    Treatment = e.Treatment;
                    break;

                case WeightUpdated e:
                    ValidateConsultationStatus();
                    CurrentWeight = e.Weight;
                    break;
                
                case ConsultationEnded e:
                    ValidateConsultationStatus();
                    if (Diagnosis == null || Treatment == null || CurrentWeight == null)
                    {
                        throw new InvalidOperationException("The consultation cannot be ended!");
                    }
                    Status = ConsultationStatus.Closed;
                    When = new DateTimeRange(When.StartedAt, DateTime.UtcNow);
                    break;
            }
        }
    }
}
