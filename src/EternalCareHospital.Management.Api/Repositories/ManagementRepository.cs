using EternalCareHospital.Management.Api.Infrastructure;
using EternalCareHospital.Management.Domain.Entities;

namespace EternalCareHospital.Management.Api.Repositories
{
    public class ManagementRepository : IManagementRepository
    {
        private readonly ManagementDbContext _context;

        public ManagementRepository(ManagementDbContext context)
        {
            _context = context;
        }

        public void Create(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public Pet GetPetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
