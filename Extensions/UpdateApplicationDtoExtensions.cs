using Appli.Api.Dtos;

namespace Appli.Api.Extensions
{
    public static class UpdateApplicationDtoExtensions
    {
        public static JobApplication ToModel(this UpdateApplicationDto dto) => new()
        {
            Company = dto.Company,
            Role = dto.Role,
            Link = dto.Link,
            Status = dto.Status
        };
    }
}
