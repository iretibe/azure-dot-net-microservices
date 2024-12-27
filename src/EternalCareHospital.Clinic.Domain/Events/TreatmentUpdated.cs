using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Events
{
    public record TreatmentUpdated(Guid Id, string Treatment) : IDomainEvent;
}
