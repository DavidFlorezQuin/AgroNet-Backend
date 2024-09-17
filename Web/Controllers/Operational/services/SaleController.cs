using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class SaleController : BaseController<SaleDto, ISaleBusiness>
    {
        public SaleController(ISaleBusiness saleBusiness) : base(saleBusiness) { }

    }
}
