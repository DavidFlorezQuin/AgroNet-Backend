
using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InventorySuppliesController : BaseController<InventorySuppliesDto, IInventorySuppliesBusiness>
    {
        public InventorySuppliesController(IInventorySuppliesBusiness inventorySuppliesBusiness) : base(inventorySuppliesBusiness) { }

    }
}
