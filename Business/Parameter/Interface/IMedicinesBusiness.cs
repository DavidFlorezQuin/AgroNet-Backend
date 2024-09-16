using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface IMedicinesBusiness
    {
        Task<Medicines> Save(MedicinesDto entity);
        Task Delete(int id);
        Task Update(int id, MedicinesDto entity);
        Task <IEnumerable<MedicinesDto>> GetAll();
        Task<MedicinesDto> GetById(int id);


    }
}
