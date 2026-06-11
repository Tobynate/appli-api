using Appli.Api.Dtos;

namespace Appli.Api.Extensions
{
    public static class JobApplicationExtensions
    {
        public static ApplicationResponseDto ToDto(this JobApplication jobApplication) => new()
        {
            Id = jobApplication.Id,
            Company = jobApplication.Company,
            Role = jobApplication.Role,
            Link = jobApplication.Link,
            Status = jobApplication.Status
        };
    }
}
