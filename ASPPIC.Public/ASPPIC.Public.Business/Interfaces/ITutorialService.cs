using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Dtos.CreateDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASPPIC.Public.Business.Interfaces
{
    public interface ITutorialService
    {
        Task<IEnumerable<TutorialDto>> GetByGroupId(Guid groupId);
        Task<TutorialDto> GetById(Guid id);
        Task Add(TutorialDto dto);

        Task Delete(Guid id);
    }
}
