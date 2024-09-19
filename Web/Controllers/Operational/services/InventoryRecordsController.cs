using Business.Operational.Interface;
using Entity.Dto.Operation;

namespace Web.Controllers.Operational.services
{
    public class InventoryRecordsController : BaseController<InventoryRecordsDto, IInventoryRecordsBusiness>
    {
        public InventoryRecordsController(IInventoryRecordsBusiness inventoryRecordsBusiness) : base(inventoryRecordsBusiness) { }
    }
}
