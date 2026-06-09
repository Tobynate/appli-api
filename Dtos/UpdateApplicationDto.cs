using System.ComponentModel.DataAnnotations;

namespace Appli.Api.Dtos
{
    public class UpdateApplicationDto
    {
        [Required, StringLength(100, MinimumLength = 3)]
        public string Company { get; set; } = "";
        [Required, StringLength(100, MinimumLength = 3)]
        public string Role { get; set; } = "";
        [Required, Url]
        public string Link { get; set; } = "";
        [Required]
        public JobApplicationStatus Status { get; set; }
    }
}
