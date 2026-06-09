using System.ComponentModel.DataAnnotations;

namespace Appli.Api.Dtos
{
    public class UpdateStatusDto
    {
        [Required]
        public JobApplicationStatus Status { get; set; }
    }
}
