using ASPPIC.Public.Domain.Dtos.GatewayDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPPIC.Public.Domain.Dtos
{
    public class DashboardDto
    {
        public IEnumerable<CountyDto> LastStatistics { get; set; }
        public int NewCases { get; set; }
        public int TotalCases { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public DateTime Date { get; set; }
    }
}
