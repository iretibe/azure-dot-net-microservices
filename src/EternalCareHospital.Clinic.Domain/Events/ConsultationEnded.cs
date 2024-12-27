using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Events
{
    public record ConsultationEnded(Guid Id, DateTime EndedAt) : IDomainEvent;
}
