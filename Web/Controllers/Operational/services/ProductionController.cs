using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class ProductionController : BaseController<ProductionDto, IProductionsBusiness>
    {
        public ProductionController(IProductionsBusiness productionsBusiness) : base(productionsBusiness) { }

    }
}
