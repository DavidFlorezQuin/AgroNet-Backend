using Entity.Dto.Operation;
using Entity.Model.Operational;

namespace Data.Operational.Inferface
{
    public interface IProductionsData : IData<Productions>
    {
         Task<bool> ValidProduction(Productions entity);
         Task isSale(Productions entity);
         Task<List<ProductionDto>> GetProductionAnimals(int farmId); 

    }
}
