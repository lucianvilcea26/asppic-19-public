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
}
