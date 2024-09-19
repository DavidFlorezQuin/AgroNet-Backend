using Business.Localitation.Interface;
using Entity.Dto.Localitation;
using Microsoft.AspNetCore.Components;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Localitation.services
{
    [Route("api/[controller]")]

    public class DepartamentController : BaseController<DepartamentDto, IDepartamentBusiness>
    {
        public DepartamentController(IDepartamentBusiness departamentBusiness) : base(departamentBusiness) { }
    }
}
