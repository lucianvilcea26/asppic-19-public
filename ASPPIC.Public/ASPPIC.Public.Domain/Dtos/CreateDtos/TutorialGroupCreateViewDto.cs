using System.ComponentModel.DataAnnotations;

namespace ASPPIC.Public.Domain.Dtos.CreateDtos
{
    public class TutorialGroupCreateViewDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}
