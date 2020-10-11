using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Dtos.CreateDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASPPIC.Public.Business.Interfaces
{
    public interface ITutorialGroupService
    {
        Task<IEnumerable<TutorialGroupDto>> Get();
        Task<TutorialGroupDto> Get(Guid id);
        Task Add(TutorialGroupDto dto);

        Task Delete(Guid id);
    }
}
