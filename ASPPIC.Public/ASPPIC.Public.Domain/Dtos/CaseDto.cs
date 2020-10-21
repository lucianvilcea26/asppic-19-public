using ASPPIC.Public.Domain.Dtos.GatewayDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPPIC.Public.Domain.Dtos
{
    public class CaseDto
    {
        public string County { get; set; }
        public string Siruta { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string Gender { get; set; }
        public short Age { get; set; }
    }

    public class CasesByPeriod
    {
        public int TotalCases { get; set; }
        public List<CaseByDay> Cases { get; set; }
    }

    public class CasesByCountyAndPeriod
    {
        public int TotalCases { get; set; }

        public CountyDto County { get; set; }
        public List<CaseByDay> Cases { get; set; }
    }

    public class CaseByDay
    {
        public int Total { get; set; }
        public DateTime Date { get; set; }
        public AgeGroupsDto TotalByAge { get; set; }
        public AgeGroupsDto MalesByAge { get; set; }
        public AgeGroupsDto FemalesByAge { get; set; }
    }
    public class AgeGroupsDto
    {
        public int Total { get; set; }
        public int Age0To10 { get; set; }
        public int Age11To20 { get; set; }
        public int Age21To30 { get; set; }
        public int Age31To40 { get; set; }
        public int Age41To50 { get; set; }
        public int Age51To60 { get; set; }
        public int Age61To70 { get; set; }
        public int Age71To80 { get; set; }
        public int Over80 { get; set; }
    }
}
