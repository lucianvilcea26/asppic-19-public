using System;
using System.Collections.Generic;
using System.Text;

namespace ASPPIC.Public.Domain.Dtos.GatewayDtos
{
    public class CountyDto
    {
        public Guid Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public List<DailyStatsDto> DailyStats { get; set; }
    }
}
