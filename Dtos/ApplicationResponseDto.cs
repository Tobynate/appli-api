using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Appli.Api.Dtos
{
    public class ApplicationResponseDto
    {
        public Guid Id { get; set; }
        public string Company { get; set; } = "";
        public string Role { get; set; } = "";
        public string Link { get; set; } = "";
        public JobApplicationStatus Status { get; set; }
    }

   
}
