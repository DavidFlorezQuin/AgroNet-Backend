using Business.Operational.Interface;
using Business.Operational.services;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class FarmController : BaseController<FarmDto, IFarmBusiness>
    {
        public FarmController(IFarmBusiness farmBusiness) : base(farmBusiness) { }

    }
}
