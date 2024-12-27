using EternalCareHospital.Management.Domain.Entities;
using EternalCareHospital.Management.Domain.Enums;
using EternalCareHospital.Management.Domain.Services;
using EternalCareHospital.Management.Domain.ValueObjects;
using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Management.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Pet_Should_Be_Equal()
        {
            var id = Guid.NewGuid();

            var breedService = new FakeBreedService();
            var breedId = new BreedId(breedService.breeds[0].Id, breedService);

            var pet1 = new Pet(id, "Pet1", 11, "Three-Color", PetSex.Male, breedId);
            var pet2 = new Pet(id, "Pet2", 12, "Three-Color", PetSex.Female, breedId);

            Assert.True(pet1.Equals(pet2));
        }

        [Fact]
        public void Pet_Should_Be_Equal_Using_Operators()
        {
            var id = Guid.NewGuid();

            var breedService = new FakeBreedService();
            var breedId = new BreedId(breedService.breeds[0].Id, breedService);

            var pet1 = new Pet(id, "Pet1", 11, "Three-Color", PetSex.Male, breedId);
            var pet2 = new Pet(id, "Pet2", 12, "Three-Color", PetSex.Female, breedId);

            Assert.True(pet1 == pet2);
        }

        [Fact]
        public void Pet_Should_Not_Be_Equal_Using_Operators()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            var breedService = new FakeBreedService();
            var breedId = new BreedId(breedService.breeds[0].Id, breedService);

            var pet1 = new Pet(id1, "Pet1", 11, "Three-Color", PetSex.Male, breedId);
            var pet2 = new Pet(id2, "Pet2", 12, "Three-Color", PetSex.Female, breedId);

            Assert.False(pet1 != pet2);
        }

        [Fact]
        public void Weight_Should_Be_Equal()
        {
            var w1 = new Weight(20.5m);
            var w2 = new Weight(20.5m);

            Assert.True(w1 == w2);
        }

        [Fact]
        public void WeightRange_Should_Be_Equal()
        {
            var wr1 = new WeightRange(10.5m, 20.5m);
            var wr2 = new WeightRange(10.5m, 20.5m);

            Assert.True(wr1 == wr2);
        }

        [Fact]
        public void BreedId_Should_Be_Valid()
        {
            var breedService = new FakeBreedService();
            var id = breedService.breeds[0].Id;
            var breedId = new BreedId(id, breedService);

            Assert.NotNull(breedId);
        }

        [Fact]
        public void BreedId_Should_Not_Be_Valid()
        {
            var breedService = new FakeBreedService();
            var id = Guid.NewGuid();
            Assert.Throws<ArgumentException>(() =>
            {
                var breedId = new BreedId(id, breedService);
            });
        }

        [Fact]
        public void WeightClass_Should_Be_Ideal()
        {
            var breedService = new FakeBreedService();
            var breedId = new BreedId(breedService.breeds[0].Id, breedService);

            var pet = new Pet(Guid.NewGuid(), "Pet1", 11, "Three-Color", PetSex.Male, breedId);
            pet.SetWeight(10, breedService);
            Assert.True(pet.WeightClass == WeightClass.Ideal);
        }

        //[Fact]
        //public void WeightClass_Should_Be_Underweight()
        //{
        //    var breedService = new FakeBreedService();
        //    var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        //    var pet = new Pet(Guid.NewGuid(), "Pet1", 11, "Three-Color", PetSex.Male, breedId);
        //    pet.SetWeight(8, breedService);
        //    Assert.True(pet.WeightClass == WeightClass.Underweight);
        //}

        //[Fact]
        //public void WeightClass_Should_Be_Overweight()
        //{
        //    var breedService = new FakeBreedService();
        //    var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        //    var pet = new Pet(Guid.NewGuid(), "Pet1", 11, "Three-Color", PetSex.Male, breedId);
        //    pet.SetWeight(25, breedService);
        //    Assert.True(pet.WeightClass == WeightClass.Overweight);
        //}
    }
}
