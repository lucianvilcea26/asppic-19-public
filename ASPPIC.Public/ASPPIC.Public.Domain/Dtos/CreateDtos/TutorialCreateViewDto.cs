using System;
using System.ComponentModel.DataAnnotations;

namespace ASPPIC.Public.Domain.Dtos.CreateDtos
{
    public class TutorialCreateViewDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
             
        [Required]
        public Guid TutorialGroupId { get; set; }
    }
}
