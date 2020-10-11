using System;
using System.Collections.Generic;
using System.Text;

namespace ASPPIC.Public.Domain.Dtos.GatewayDtos
{
    public class TutorialCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid TutorialGroupId { get; set; }
    }
}
