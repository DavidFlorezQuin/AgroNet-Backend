using Business.Operational.Interface;
using Business.Parameter.Interface;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Components;
using Web.Controllers.Operational.services;

namespace Web.Controllers.Parameter.Service
{
    [Route("api/[controller]")]

    public class CategoryDiseaseController : BaseController<CategoryDiseaseDto, ICategoryDiseaseBusiness>
    {
        public CategoryDiseaseController(ICategoryDiseaseBusiness categoryDiseaseBusiness) : base(categoryDiseaseBusiness) { }

    }
}
