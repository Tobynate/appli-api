using Appli.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private static readonly List<JobApplication> _applications = new List<JobApplication>
        {
            new JobApplication
            {
                Id = Guid.NewGuid(),
                Company = "Google",
                Role = "Software Engineer",
                Link = "https://careers.google.com/jobs/results/123456-software-engineer/",
                Status = JobApplicationStatus.Applied

            },
            new JobApplication
            {
                Id = Guid.NewGuid(),
                Company = "Microsoft",
                Role = "Program Manager",
                Link = "https://careers.microsoft.com/us/en/job/123456/Program-Manager",
                Status = JobApplicationStatus.Interviewing
            }
        };
        [HttpGet]
        public ActionResult<IEnumerable<ApplicationResponseDto>> GetApplications()
        {
            var response = _applications.Select(a => new ApplicationResponseDto
            {
                Id = a.Id,
                Company = a.Company,
                Role = a.Role,
                Link = a.Link,
                Status = a.Status
            });
            return Ok(response);
        }
        [HttpGet("{id}")]
        public ActionResult<ApplicationResponseDto> GetApplication(Guid id)
        {
            var response = _applications.Where(a=> a.Id == id).Select(a => new ApplicationResponseDto
            {
                Id = a.Id,
                Company = a.Company,
                Role = a.Role,
                Link = a.Link,
                Status = a.Status
            }).FirstOrDefault();
            if (response == null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public ActionResult<ApplicationResponseDto> AddApplication(CreateApplicationDto application)
        {
            JobApplication app = new JobApplication
            {
                Id = Guid.NewGuid(),
                Company = application.Company,
                Role = application.Role,
                Link = application.Link,
                Status = application.Status
            };

            _applications.Add(app);

            var response = new ApplicationResponseDto
            {
                Id = app.Id,
                Company = app.Company,
                Role = app.Role,
                Link = app.Link,
                Status = app.Status
            };
            return CreatedAtAction(nameof(GetApplication), new { id = app.Id }, response);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateApplication(Guid id, UpdateApplicationDto updatedAppDto)
        {
            var existingApp = _applications.FirstOrDefault(a => a.Id == id);

            if (existingApp == null)
                return NotFound();
            
            existingApp.Company = updatedAppDto.Company;
            existingApp.Role = updatedAppDto.Role;
            existingApp.Link = updatedAppDto.Link;
            existingApp.Status = updatedAppDto.Status;
            return NoContent();
        }
        [HttpPut("{id}/status")]
        public ActionResult UpdateApplicationStatus(Guid id, UpdateStatusDto statusDto)
        {
            var existingApp = _applications.FirstOrDefault(a => a.Id == id);
            if (existingApp == null)
                return NotFound();
            existingApp.Status = statusDto.Status;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteApplication(Guid id)
        {
            var app = _applications.FirstOrDefault(a => a.Id == id);
            if (app == null)
                return NotFound();
            _applications.Remove(app);
            return NoContent();
        }
    }
}
