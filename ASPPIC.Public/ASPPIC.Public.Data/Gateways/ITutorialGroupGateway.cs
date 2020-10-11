using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Dtos.CreateDtos;
using ASPPIC.Public.Domain.Dtos.GatewayDtos;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPPIC.Public.Data.Gateways
{
    public interface ITutorialGroupGateway
    {
        [Get("tutorial-groups")]
        Task<IEnumerable<TutorialGroupDto>> Get();

        [Get("tutorial-groups/{id}")]
        Task<TutorialGroupDto> Get([Path("id")] Guid id);

        [Get("tutorial-groups/{id}/tutorials")]
        Task<IEnumerable<TutorialDto>> GetByGroupId([Path("id")] Guid groupId);

        [Post("tutorial-groups")]
        Task Add([Body] TutorialGroupCreateDto dto);

        [Delete("tutorial-groups/{id}")]
        Task Delete([Path("id")] Guid id);
    }
}
