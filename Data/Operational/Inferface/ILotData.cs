using Entity.Dto.Operation;
using Entity.Model.Operational;
using Entity.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface ILotData : IData<Lots>
    {
        public Task<HectareValidate> ValidateHectareas(Lots entity);
        public Task<List<LotsDto>> GetLotsAsync(int farmId); 

    }
}
