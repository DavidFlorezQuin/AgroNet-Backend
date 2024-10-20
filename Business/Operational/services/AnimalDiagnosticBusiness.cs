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
    public class AnimalDiagnosticBusiness : BaseBusiness<AnimalDiagnostics, AnimalDiagnosticDto>, IAnimalDiagnosticBusiness
    {
        private readonly IAnimalDiagnosticData _data;
        public AnimalDiagnosticBusiness(IMapper mapper, IAnimalDiagnosticData data) : base(mapper, data)
        {

            _data = data;
        }

        public async Task RegisterAlive(int animalDiagnosticId)
        {
            if (animalDiagnosticId == 0)
            {
                throw new ArgumentException("Diagnósitico no encontrado");

            }
            await _data.RegisterAlive(animalDiagnosticId);
        }

        public async Task RegisterDead(int animalDiagnosticId)
        {

            if (animalDiagnosticId == 0)
            {
                throw new ArgumentException("Diagnósitico no encontrado");

            }
            await _data.RegisterDead(animalDiagnosticId);
        }
    }
}
