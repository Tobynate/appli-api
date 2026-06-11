using Appli.Api.Dtos;
using Appli.Api.Extensions;
using Appli.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ApplicationResponseDto>> GetApplications() => Ok(_applicationService.GetAll().Select(a=>a.ToDto()));

        [HttpGet("{id}")]
        public ActionResult<ApplicationResponseDto> GetApplication(Guid id)
        {
            var response = _applicationService.GetById(id);

            if (response == null)
                return NotFound();
            return Ok(response.ToDto());
        }
        [HttpPost]
        public ActionResult<ApplicationResponseDto> AddApplication(CreateApplicationDto application)
        {            
            JobApplication app = _applicationService.Add(application.ToModel());

            var response = app.ToDto();
            return CreatedAtAction(nameof(GetApplication), new { id = app.Id }, response);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateApplication(Guid id, UpdateApplicationDto updatedAppDto)
        {
            bool output = _applicationService.Update(id, updatedAppDto.ToModel());
            if (!output) return NotFound();
            return NoContent();
        }
        [HttpPut("{id}/status")]
        public ActionResult UpdateApplicationStatus(Guid id, UpdateStatusDto statusDto)
        {
            bool output = _applicationService.UpdateStatus(id, statusDto.Status);
            if (!output)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteApplication(Guid id)
        {
            bool output = _applicationService.Delete(id);
            if (!output)
                return NotFound();
            return NoContent();
        }
    }
}
