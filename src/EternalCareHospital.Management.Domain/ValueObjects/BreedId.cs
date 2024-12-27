using EternalCareHospital.Management.Domain.Services;

namespace EternalCareHospital.Management.Domain.ValueObjects
{
    public record BreedId
    {
        private readonly IBreedService _breedService;

        public Guid Value { get; set; }

        public BreedId(Guid value)
        {
            Value = value;
        }

        public static BreedId Create(Guid value)
        {
            return new BreedId(value);
        }

        public BreedId(Guid value, IBreedService breedService)
        {
            _breedService = breedService;
            ValidateBreed(value);

            Value = value;
        }

        private void ValidateBreed(Guid value)
        {
            if (_breedService.GetBreedById(value) == null)
            {
                throw new ArgumentException("Breed is not valid!");
            }
        }
    }
}
