using EternalCareHospital.Management.Api.Infrastructure;
using EternalCareHospital.Management.Domain.Events;
using EternalCareHospital.Management.Domain.Services;

namespace EternalCareHospital.Management.Api.Application
{
    public class SetWeightCommandHandler : ICommandHandler<SetWeightCommand>
    {
        private readonly ManagementDbContext _context;
        private readonly IBreedService _breedService;

        public SetWeightCommandHandler(ManagementDbContext context, IBreedService breedService)
        {
            _context = context;
            _breedService = breedService;

            //Add domain event
            DomainEvents.PetWeightUpdated.Subscribe((domainEvent) =>
            {
                //Send a message

            });
        }

        public async Task Handle(SetWeightCommand command)
        {
            var pet = await _context.Pets.FindAsync(command.Id);
            pet.SetWeight(command.Weight, _breedService);

            await _context.SaveChangesAsync();
        }
    }
}
