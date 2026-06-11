using Appli.Api.Dtos;

namespace Appli.Api.Extensions
{
    public static class CreateApplicationDtoExtensions
    {
        public static JobApplication ToModel(this CreateApplicationDto dto) => new()
        {
            Company = dto.Company,
            Role = dto.Role,
            Link = dto.Link,
            Status = dto.Status
        };
    }
}
