﻿using AutoMapper;
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
    public class InseminationBusiness : BaseBusiness<Inseminations, InseminationDto>, IInseminationBusiness
    {

        private IInseminationData _inseminationData;
        public InseminationBusiness(IMapper mapper, IInseminationData data) : base(mapper, data)
        {
            _inseminationData = data;
        }


        public override async Task<InseminationDto> Save(InseminationDto dto)
        {

            var entity = _mapper.Map<Inseminations>(dto);

            bool isActive = await _inseminationData.ValidateInsamination(entity);
            bool isMale = await _inseminationData.ValidateGenderAnimal(entity);

            if (isActive)
            {
                throw new InvalidOperationException("El animal tiene una inseminación activa pendiente");

            }

            if (isMale)
            {

                throw new InvalidOperationException("El animal seleccionado para la inseminación no puede ser macho.");

            }
            await _data.Save(entity);

            return _mapper.Map<InseminationDto>(entity);

        }

        public async Task<IEnumerable<AnimalDto>> GetAnimalsInsemination(int farmId)
        {
            var insemination = await _inseminationData.GetAnimalsInsemination(farmId);


            var inseminationDto = insemination.Select(n => new AnimalDto
            {
                Id = n.Id,
                Name = n.Name,
                Gender = n.Gender,
                purpose = n.purpose,
                birthDay = n.birthDay,
                Weight = n.Weight,
                Photo = n.Photo,
                LotId = n.LotId
            }).ToList();

            return inseminationDto; 
        }
    }
}
