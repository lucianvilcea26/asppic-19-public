using ASPPIC.Public.Domain.Dtos;
using ASPPIC.Public.Domain.Dtos.GatewayDtos;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASPPIC.Public.Data.Gateways
{
    public interface ICountyGateway
    {
        [Get("counties-with-data")]
        Task<IEnumerable<CountyDto>> GetCountiesWithData();
        [Get("counties")]
        Task<IEnumerable<CountyDto>> GetCounties();

        [Get("counties/last-days/{days}")]
        Task<IEnumerable<CountyDto>> GetStatsForLastDays([Path("days")] int days);

        [Get("counties/{id}")]
        Task<CountyDto> GetCounty([Path("id")] string id);

        [Get("stats/{date}")]
        Task<IEnumerable<DailyStatsDetailsDto>> GetStatsForDate([Path("date")] string date);

        [Post("stats")]
        Task Add([Body] List<DailyStatsDto> model);

        [Post("cases/batch")]
        Task AddCasesAsBatch([Body] List<CaseDto> model);

        [Get("/cases/counties/last-day")]
        Task<List<CasesByCountyAndPeriod>> GetCasesByCountyForLastDay();
    }
}
