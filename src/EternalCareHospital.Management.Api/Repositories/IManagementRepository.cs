using EternalCareHospital.Management.Domain.Entities;

namespace EternalCareHospital.Management.Api.Repositories
{
    public interface IManagementRepository
    {
        Pet? GetPetById(Guid id);
        IEnumerable<Pet> GetAllPets();
        void Create(Pet pet);
        void Update(Pet pet);
        void Delete(Pet pet);
    }
}
