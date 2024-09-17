using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AlertController : BaseController<AlertDto, IAlertBusiness>
    {
        public AlertController(IAlertBusiness alertBusiness) : base(alertBusiness) { }

    }
}
