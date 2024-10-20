using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public class InventoryRecordsBusiness : BaseBusiness<InventoryRecords, InventoryRecordsDto>, IInventoryRecordsBusiness
    {
        private readonly IInventoryRecordsData _data;
        public InventoryRecordsBusiness(IMapper mapper, IInventoryRecordsData data) : base(mapper, data) {
            _data = data;
        }


        public async Task<List<InventoryRecordsDto>> GetRecordsAsync(int inventoryId)
        {
            if (inventoryId == 0)
            {
                throw new Exception("Parámetro inválido");
            }
           return await _data.GetRecordsAsync(inventoryId); 

        }
    }
}