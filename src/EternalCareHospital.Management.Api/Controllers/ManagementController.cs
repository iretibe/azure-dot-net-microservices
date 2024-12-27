using EternalCareHospital.Management.Api.Application;
using Microsoft.AspNetCore.Mvc;

namespace EternalCareHospital.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagementApplicationService _applicationService, ICommandHandler<SetWeightCommand> commandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> PostPet(CreatePetCommand command)
    {
        await _applicationService.Handle(command);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> PutWeight(SetWeightCommand command)
    {
        await commandHandler.Handle(command);

        return Ok();
    }
}
