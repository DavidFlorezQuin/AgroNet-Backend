using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;

namespace Web.Controllers.Operational.services
{
    public class AnimalSalesController : BaseController<AnimalSaleDto, IAnimalSaleBusiness>
    {
        public AnimalSalesController(IAnimalSaleBusiness animalSaleBusiness) : base(animalSaleBusiness  ) { }
    }
}
