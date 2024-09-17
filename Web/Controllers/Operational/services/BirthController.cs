using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class BirthController : BaseController<BirthDto, IBirthBusiness>
    {
        public BirthController(IBirthBusiness birthBusiness) : base(birthBusiness) { }

    }
}
