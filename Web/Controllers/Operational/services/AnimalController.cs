using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class AnimalController : BaseController<AnimalDto, IAnimalBusiness>
    {
        public AnimalController(IAnimalBusiness animalBusiness) : base(animalBusiness) { }

    }
}
