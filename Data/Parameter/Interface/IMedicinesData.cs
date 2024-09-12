using Entity.Model.Parameter;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface IMedicinesData
    {
        Task Delete(int id);
        Task<Medicines> Save(Medicines entity);
        Task Update(Medicines entity);
        Task<IEnumerable<Medicines>> GetAll();

        Task<Medicines> GetById(int id);
    }
}
