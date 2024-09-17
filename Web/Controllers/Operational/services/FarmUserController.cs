using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class FarmUserController : BaseController<FarmUserDto, IFarmUserBusiness>
    {
        public FarmUserController(IFarmUserBusiness farmUserBusiness) : base(farmUserBusiness) { }

    }
}
