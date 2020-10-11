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
        public async Task<DashboardDto> GetDashboardInfo()
        {
            var dto = new DashboardDto();
            var lastDays = await _gateway.GetStatsForLastDays(2);
            var lastDay = await _gateway.GetStatsForLastDays(1);
            dto.LastStatistics = lastDay;
            dto.NewCases = lastDay.SelectMany(x => x.DailyStats).Sum(x => x.NewCases);
            dto.TotalCases = lastDay.SelectMany(x => x.DailyStats).Sum(x => x.TotalCases);
            dto.NewDeaths = lastDay.SelectMany(x => x.DailyStats).Sum(x => x.NewDeaths);
            dto.TotalDeaths = lastDay.SelectMany(x => x.DailyStats).Sum(x => x.TotalDeaths);
            dto.Date = lastDay.First().DailyStats.First().Date;
            return dto;
        }
    }
}
