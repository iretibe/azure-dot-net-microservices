using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Events
{
    public record WeightUpdated(Guid Id, decimal Weight) : IDomainEvent;
}
