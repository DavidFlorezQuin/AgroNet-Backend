using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class TreatmentController : BaseController<TreatmentDto, ITreatmentsBusiness>
    {

        public TreatmentController(ITreatmentsBusiness treatmentsBusiness) : base(treatmentsBusiness) { }

    }
}
