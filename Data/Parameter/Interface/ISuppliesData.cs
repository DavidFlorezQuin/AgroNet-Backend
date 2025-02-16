using Data.Operational.Inferface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface ISuppliesData : IData<Supplies>
    {

        public Task<List<SuppliesDto>> GetSuppliesAsync(int farmId);
    }
}
