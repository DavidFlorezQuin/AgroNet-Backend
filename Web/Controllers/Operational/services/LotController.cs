using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class LotController : BaseController<LotsDto, ILotBusiness>
    {
        public LotController(ILotBusiness lotBusiness) : base(lotBusiness) { }

    }
}
