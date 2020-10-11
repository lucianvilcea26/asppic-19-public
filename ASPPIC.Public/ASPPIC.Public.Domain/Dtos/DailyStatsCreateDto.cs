using System;
using System.Collections.Generic;
using System.Text;

namespace ASPPIC.Public.Domain.Dtos
{
    public class DailyStatsCreateDto
    {
        public DateTime Date { get; set; }
        public List<DailyStatsDetailsDto> Stats { get; set; }
    }
}
