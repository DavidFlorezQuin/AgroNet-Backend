using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InventoryController : BaseController<InventoriesDto, IInventoriesBusiness>
    {
        public InventoryController(IInventoriesBusiness inventoriesBusiness) : base(inventoriesBusiness) { }

    }
}
