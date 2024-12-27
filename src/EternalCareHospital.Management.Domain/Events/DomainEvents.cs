using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Management.Domain.Events
{
    public static class DomainEvents
    {
        public static DomainEventDispatcher<PetWeightUpdated> PetWeightUpdated = new ();
    }
}
