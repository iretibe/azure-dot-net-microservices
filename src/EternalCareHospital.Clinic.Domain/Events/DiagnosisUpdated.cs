using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Events
{
    public record DiagnosisUpdated(Guid Id, string Diagnosis) : IDomainEvent;
}
