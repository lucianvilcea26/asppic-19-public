﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ASPPIC.Public.Domain.Dtos
{
    public class DailyStatsDetailsDto
    {
        public Guid CountyId { get; set; }
        public string CountyName { get; set; }
        public string CountyAbbreviation { get; set; }
        public int TotalCases { get; set; }
        public int TotalDeaths { get; set; }
        public int NewCases { get; set; }
        public int NewDeaths { get; set; }
        public DateTime Date { get; set; }
    }
}
