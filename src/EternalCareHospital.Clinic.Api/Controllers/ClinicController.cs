using EternalCareHospital.Clinic.Api.Application;
using EternalCareHospital.Clinic.Api.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EternalCareHospital.Clinic.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicController(ClinicApplicationService _applicationService, ILogger<ClinicController> _logger) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post(StartConsultationCommand command)
        {
            try
            {
                var id = await _applicationService.Handle(command);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpPost("end")]
        public async Task<ActionResult> Post(EndConsultationCommand command)
        {
            try
            {
                await _applicationService.Handle(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpPut("diagnosis")]
        public async Task<ActionResult> Put(SetDiagnosisCommand command)
        {
            try
            {
                await _applicationService.Handle(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }
        [HttpPut("treatment")]
        public async Task<ActionResult> Put(SetTreatmentCommand command)
        {
            try
            {
                await _applicationService.Handle(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpPut("weight")]
        public async Task<ActionResult> Put(SetWeightCommand command)
        {
            try
            {
                await _applicationService.Handle(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }

        [HttpPut("administerDrug")]
        public async Task<ActionResult> Put(AdministerDrugCommand command)
        {
            try
            {
                await _applicationService.Handle(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }


        [HttpPut("registerVitalSigns")]
        public async Task<ActionResult> Put(RegisterVitalSignsCommand command)
        {
            try
            {
                await _applicationService.Handle(command);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
