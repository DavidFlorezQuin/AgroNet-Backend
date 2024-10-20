﻿using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IAnimalSaleData : IData<AnimalSales>
    {

        Task<List<AnimalSaleDto>> GetAnimalSaleAsync(int farmId); 
    }
}
