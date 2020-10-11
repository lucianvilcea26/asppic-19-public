using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Dtos.CreateDtos;
using ASPPIC.Public.Domain.Dtos.GatewayDtos;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPPIC.Public.Data.Gateways
{
    public interface ITutorialGateway
    {      
        [Get("tutorials/{id}")]
        Task<TutorialDto> Get([Path("id")] Guid id);

        [Post("tutorials")]
        Task Add([Body] TutorialDto dto);

        [Delete("tutorials/{id}")]
        Task Delete([Path("id")] Guid id);
    }
}
