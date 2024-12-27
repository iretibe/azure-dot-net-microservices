using EternalCareHospital.Management.Domain.Enums;

namespace EternalCareHospital.Management.Api.Application
{
    public record CreatePetCommand(Guid Id, string Name, int Age, string Color, PetSex SexOfPet, Guid BreedId);
}
