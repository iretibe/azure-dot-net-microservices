using EternalCareHospital.Management.Domain.Entities;

namespace EternalCareHospital.Management.Domain.Services
{
    public interface IBreedService
    {
        Breed? GetBreedById(Guid id);
    }
}
