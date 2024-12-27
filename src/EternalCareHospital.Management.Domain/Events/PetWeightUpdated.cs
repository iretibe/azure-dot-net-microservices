using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Management.Domain.Events
{
    public record PetWeightUpdated(Guid Id, decimal Weight) : IDomainEvent;
}
