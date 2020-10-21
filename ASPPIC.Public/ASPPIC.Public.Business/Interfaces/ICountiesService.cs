using ASPPIC.Public.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASPPIC.Public.Business.Interfaces
{
    public interface ICountyService
    {
        Task<List<CasesByCountyAndPeriod>> GetDashboardInfo();
    }
}
