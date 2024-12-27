using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Events
{
    public record ConsultationStarted(Guid Id, Guid PatientId, DateTime StartedAt) :  IDomainEvent;
}
