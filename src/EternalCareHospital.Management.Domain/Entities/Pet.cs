using EternalCareHospital.Management.Domain.Enums;
using EternalCareHospital.Management.Domain.Events;
using EternalCareHospital.Management.Domain.Services;
using EternalCareHospital.Management.Domain.ValueObjects;
using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Management.Domain.Entities
{
    public class Pet : Entity
    {
        public string Name { get; init; } = default!;
        public int Age { get; init; }
        public string Color { get; init; }
        public Weight? Weight { get; private set; }
        public WeightClass WeightClass { get; private set; }
        public PetSex PetSex { get; init; }
        public BreedId BreedId { get; init; }

        public Pet(Guid id, string name, int age,
            string color, PetSex petSex, BreedId breedId)
        {
            Id = id;
            Name = name;
            Age = age;
            Color = color;
            PetSex = petSex;
            BreedId = breedId;
        }

        public void SetWeight(Weight weight, IBreedService breedService)
        {
            Weight = weight;
            SetWeightClass(breedService);

            //Domain Event
            DomainEvents.PetWeightUpdated.Publish(new PetWeightUpdated(Id, Weight));
        }

        public void SetWeightClass(IBreedService breedService)
        {
            var desiredBreed = breedService.GetBreedById(BreedId.Value);

            var (from, to) = PetSex switch
            {
                PetSex.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
                PetSex.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
                _ => throw new NotImplementedException()
            };

            WeightClass = Weight.Value switch
            {
                _ when Weight.Value < from => WeightClass.Underweight,
                _ when Weight.Value > to => WeightClass.Overweight,
                _ => WeightClass.Ideal
            };
        }



        //public Pet(Guid id, string name, int age,
        //    string color, Weight weight, PetSex petSex, BreedId breedId)
        //{
        //    Id = id;
        //    Name = name;
        //    Age = age;
        //    Color = color;
        //    Weight = weight;
        //    PetSex = petSex;
        //    BreedId = breedId;
        //}
    }
}
