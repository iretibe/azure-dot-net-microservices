using EternalCareHospital.Management.Api.Infrastructure;
using EternalCareHospital.Management.Domain.Entities;
using EternalCareHospital.Management.Domain.Services;
using EternalCareHospital.Management.Domain.ValueObjects;

namespace EternalCareHospital.Management.Api.Application
{
    public class ManagementApplicationService(IBreedService breedService, ManagementDbContext context)
    {
        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.BreedId, breedService);

            var newPet = new Pet(command.Id, command.Name,
                command.Age, command.Color, command.SexOfPet, breedId);

            await context.Pets.AddAsync(newPet);
            await context.SaveChangesAsync();
        }
    }
}
