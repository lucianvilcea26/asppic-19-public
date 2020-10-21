using ASPPIC.Public.Business.Interfaces;
using ASPPIC.Public.Data;
using ASPPIC.Public.Data.Gateways;
using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Helpers;
using Microsoft.Extensions.Options;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPIC.Public.Business.Concrete
{
    public class CountyService : ICountyService
    {
        private ICountyGateway _gateway;
        public CountyService(IOptions<APIConfiguration> config)
        {
            _gateway = RestClient.For<ICountyGateway>(config.Value.StatsAPIUrl);
        }
        public async Task<List<CasesByCountyAndPeriod>> GetDashboardInfo()
        {
            return await _gateway.GetCasesByCountyForLastDay();
        }
    }
}
