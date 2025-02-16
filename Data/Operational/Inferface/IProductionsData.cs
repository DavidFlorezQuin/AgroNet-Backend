using Entity.Dto.Operation;
using Entity.Dto.Utilities;
using Entity.Model.Operational;

namespace Data.Operational.Inferface
{
    public interface IProductionsData : IData<Productions>
    {
         Task<bool> ValidProduction(Productions entity);
         Task<List<ProductionDto>> GetProductionAnimals(int farmId);
        Task<List<DataProductionDto>> GetMonthlyMilkProductionAsync(int farmId); 

    }
}
