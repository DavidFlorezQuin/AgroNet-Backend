using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto.Localitation
{
    public class CountryDto : BaseDto
    {
        public string Name { get; set; }

        public string CountryCode { get; set; }

        public int ContinentId { get; set; }

    }
}
