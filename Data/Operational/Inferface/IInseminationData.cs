using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IInseminationData : IData<Inseminations>
    {
         Task<bool> ValidateGenderAnimal(Inseminations entity);
         Task<bool> ValidateInsamination(Inseminations entity);
    }
}
