using System;
using System.Collections.Generic;

namespace ASPPIC.Public.Domain.Dtos
{
    public class TutorialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid TutorialGroupId { get; set; }
        public TutorialGroupDto TutorialGroup { get; set; }
    }
}
