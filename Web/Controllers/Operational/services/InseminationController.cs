using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class InseminationController : BaseController<InseminationDto, IInseminationBusiness>
    {
        public InseminationController(IInseminationBusiness inseminationBusiness) : base(inseminationBusiness) { }

    }
}
