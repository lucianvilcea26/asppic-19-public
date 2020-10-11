using ASPPIC.Public.Business.Interfaces;
using ASPPIC.Public.Data.Gateways;
using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Helpers;
using Microsoft.Extensions.Options;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPPIC.Public.Business.Concrete
{
    public class TutorialService : ITutorialService
    {
        private readonly ITutorialGateway _tutorialGateway;
        private readonly ITutorialGroupGateway _tutorialGroupGateway;
        public TutorialService(IOptions<APIConfiguration> config)
        {
            _tutorialGateway = RestClient.For<ITutorialGateway>(config.Value.TrainingAPIUrl);
            _tutorialGroupGateway = RestClient.For<ITutorialGroupGateway>(config.Value.TrainingAPIUrl);
        }
        public async Task Add(TutorialDto dto)
        {
            await _tutorialGateway.Add(dto);            
        }

        public async Task<IEnumerable<TutorialDto>> GetByGroupId(Guid groupId)
        {
            return await _tutorialGroupGateway.GetByGroupId(groupId);
        }

        public async Task<TutorialDto> GetById(Guid id)
        {
            return await _tutorialGateway.Get(id);
        }

        public async Task Delete(Guid id)
        {
            await _tutorialGateway.Delete(id);
        }
    }
}
