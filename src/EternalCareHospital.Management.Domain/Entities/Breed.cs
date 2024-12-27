using EternalCareHospital.Management.Domain.ValueObjects;
using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Management.Domain.Entities
{
    public class Breed : Entity
    {
        public Breed(Guid id, string name, WeightRange maleIdealRange, WeightRange femaleIdealRange)
        {
            Id = id;
            Name = name;
            MaleIdealWeight = maleIdealRange;
            FemaleIdealWeight = femaleIdealRange;
        }

        public string Name { get; init; } = default!;
        public WeightRange MaleIdealWeight { get; init; }
        public WeightRange FemaleIdealWeight { get; init; }
    }
}
