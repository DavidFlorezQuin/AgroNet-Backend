using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class VaccineAnimalController : BaseController<VaccineAnimalDto, IVaccineAnimalBusiness>
    {
        public VaccineAnimalController(IVaccineAnimalBusiness vaccineAnimalBusiness) : base(vaccineAnimalBusiness) { }

    }
}
