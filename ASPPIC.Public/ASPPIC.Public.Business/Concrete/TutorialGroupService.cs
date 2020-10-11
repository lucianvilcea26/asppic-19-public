using ASPPIC.Public.Business.Helpers;
using ASPPIC.Public.Business.Interfaces;
using ASPPIC.Public.Data;
using ASPPIC.Public.Data.Gateways;
using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Dtos.CreateDtos;
using ASPPIC.Public.Domain.Dtos.GatewayDtos;
using ASPPIC.Public.Domain.Helpers;
using Microsoft.Extensions.Options;
using RestEase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ASPPIC.Public.Business.Concrete
{
    public class TutorialGroupService : ITutorialGroupService
    {
        private readonly ITutorialGroupGateway _gateway;
        public TutorialGroupService(IOptions<APIConfiguration> config)
        {
            _gateway = RestClient.For<ITutorialGroupGateway>(config.Value.TrainingAPIUrl);
            
        }
        public async Task Add(TutorialGroupDto dto)
        {
            //var uniqueFileName = FileHelper.GetUniqueFileName(dto.Thumbnail.FileName);
            //var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            //var filePath = Path.Combine(uploads, uniqueFileName);
            //dto.Thumbnail.CopyTo(new FileStream(filePath, FileMode.Create));


            var gatewayDto = new TutorialGroupCreateDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                //Thumbnail = uniqueFileName
            };
            await _gateway.Add(gatewayDto);
        }

        public async Task<IEnumerable<TutorialGroupDto>> Get()
        {
            var result = await _gateway.Get();
            return result;
        }

        public async Task<TutorialGroupDto> Get(Guid id)
        {
            var result = await _gateway.Get(id);
            return result;
        }

        public async Task Delete(Guid id)
        {
            await _gateway.Delete(id);
        }
    }
}
