using AutoMapper;
using Business.Exceptions;
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
    public class InseminationBusiness : BaseBusiness<Inseminations, InseminationDto>, IInseminationBusiness
    {

        private IInseminationData _inseminationData;
        public InseminationBusiness(IMapper mapper, IInseminationData data) : base(mapper, data)
        {
            _inseminationData = data;
        }


        public async Task<List<InseminationDto>> GetInseminationActive(int farmId)
        {

            if (farmId == 0)
            {
                throw new FarmNotFoundException();
            }

            var InseminationAsync = await _inseminationData.GetInseminationActive(farmId);

            if (InseminationAsync == null)
            {
                throw new AnimalsNotFoundExceptions();
            }
            return InseminationAsync;
        }        
        
        public async Task<List<InseminationDto>> GetInseminationAsync(int farmId)
        {

            if (farmId == 0)
            {
                throw new FarmNotFoundException();
            }

            var InseminationAsync = await _inseminationData.GetInseminationAsync(farmId);

            if (InseminationAsync == null)
            {
                throw new AnimalsNotFoundExceptions();
            }
            return InseminationAsync;
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

        public void RegisterAbortion(int animalDiagnosticId)
        {
            if(animalDiagnosticId == 0)
            {
                throw new ArgumentException("Inseminación no encontrada");

            }
            _inseminationData.RegisterAbortion(animalDiagnosticId); 
        }

        public void RegisterBorn(int animalDiagnosticId)
        {
            if (animalDiagnosticId == 0)
            {
                throw new ArgumentException("Inseminación no encontrada");

            }
            _inseminationData.RegisterBorn(animalDiagnosticId);
        }

    }
}
