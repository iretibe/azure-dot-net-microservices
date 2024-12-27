using EternalCareHospital.Management.Domain.Entities;
using EternalCareHospital.Management.Domain.Services;
using EternalCareHospital.Management.Domain.ValueObjects;

namespace EternalCareHospital.Management.Api.Infrastructure
{
    public class BreedService : IBreedService
    {
        public readonly List<Breed> breeds =
        [
            new Breed(Guid.NewGuid(), "Beagle", new WeightRange(10, 20), new WeightRange(11m, 18m)),
            new Breed(Guid.NewGuid(), "Staffordshire Terrier", new WeightRange(28, 40), new WeightRange(24m, 34m))
        ];

        public Breed GetBreedById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Breed is not valid!");
            }

            var result = breeds.Find(breeds => breeds.Id == id);

            return result ?? throw new ArgumentException("Breed was not found!");
        }
    }
}
