using System;
using System.Collections.Generic;

namespace ASPPIC.Public.Domain.Dtos
{
    public class TutorialGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<TutorialDto> Tutorials { get; set; }
    }
}
