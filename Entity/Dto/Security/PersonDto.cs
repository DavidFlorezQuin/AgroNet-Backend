using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class PersonDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Document { get; set; }
        public string TypeDocument { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

    }
}
