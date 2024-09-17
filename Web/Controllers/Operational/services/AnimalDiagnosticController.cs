using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AnimalDiagnosticController : BaseController<AnimalDiagnosticDto, IAnimalDiagnosticBusiness>
    {
        public AnimalDiagnosticController(IAnimalDiagnosticBusiness animalDiagnosticBusiness) : base(animalDiagnosticBusiness) { }

    }
}
