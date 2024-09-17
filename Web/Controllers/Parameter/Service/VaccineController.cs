using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Components;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class VaccineController : BaseController<VaccineDto, IVaccineBusiness>
    {
        public VaccineController(IVaccineBusiness vaccineBusiness) : base(vaccineBusiness) { }

    }
}
