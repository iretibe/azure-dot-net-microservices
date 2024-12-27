using EternalCareHospital.Clinic.Domain.ValueObjects;
using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Entities
{
    public class DrugAdministration : Entity
    {
        public DrugAdministration(DrugId drugId, Dose dose)
        {
            Id = Guid.NewGuid();
            DrugId = drugId;
            Dose = dose;
        }

        public DrugAdministration()
        {
            
        }

        public DrugId DrugId { get; init; }
        public Dose Dose { get; init; }
    }
}
