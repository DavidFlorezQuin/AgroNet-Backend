using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{


    public class LotsBusiness : BaseBusiness<Lots, LotsDto>, ILotBusiness
    {
        private  readonly ILotData _lotData;
        public LotsBusiness(IMapper mapper, ILotData data): base(mapper, data) {
            _lotData = data;
        }


        public override async Task<LotsDto> Save(LotsDto dto)
        {

            var entityDto = _mapper.Map<Lots>(dto);



            var entity = await _lotData.ValidateHectareas(entityDto); 


            if (entity.FarmMaxHectareareas < entity.TotalHectareas)
            {
                throw new InvalidOperationException("El tamaño de lote supera el tamaño de la finca");

            }

            await _data.Save(entityDto);

            return _mapper.Map<LotsDto>(entityDto);

        }
    }

}
