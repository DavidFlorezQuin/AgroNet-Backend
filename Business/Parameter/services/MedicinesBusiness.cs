using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class MedicinesBusiness : IMedicinesBusiness
    {
        private readonly IMedicinesData data;

        public MedicinesBusiness(IMedicinesData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<MedicinesDto>> GetAll()
        {
            var medicines = await data.GetAll();
            var medicinesDto = new List<MedicinesDto>();

            foreach (var medicine in medicines)
            {
                var medicineDto = new MedicinesDto
                {
                    Id = medicine.Id,
                    Name = medicine.Name,
                    MedicationAdministration = medicine.MedicationAdministration,
                    UnitMeasure = medicine.UnitMeasure,
                    CategoryMedicinesId = medicine.CategoryMedicinesId


                };

                medicinesDto.Add(medicineDto);
            }
            return medicinesDto;
        }
        public async Task<MedicinesDto> GetById(int id)
        {
            Medicines medicines = await data.GetById(id);
            MedicinesDto medicinesDto = new MedicinesDto();

            medicinesDto.Id = medicinesDto.Id;
            medicinesDto.Name = medicinesDto.Name;
            medicinesDto.MedicationAdministration = medicinesDto.MedicationAdministration;
            medicinesDto.UnitMeasure = medicinesDto.UnitMeasure;
            medicinesDto.CategoryMedicinesId = medicinesDto.CategoryMedicinesId;
            medicinesDto.state = medicinesDto.state;



            return medicinesDto;
        }

        private Medicines mapearDatos(Medicines entity, MedicinesDto dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.MedicationAdministration = dto.MedicationAdministration;
            entity.UnitMeasure = dto.UnitMeasure;
            entity.CategoryMedicinesId = dto.CategoryMedicinesId;
            entity.state = dto.state;


            return entity;
        }
        public async Task<Medicines> Save(MedicinesDto entity)
        {
            Medicines medicines = new Medicines();
            medicines = mapearDatos(medicines, entity);

            return await data.Save(medicines);
        }

        public async Task Update(int id, MedicinesDto entity)
        {
            Medicines medicines = await data.GetById(id);

            if (medicines == null)
            {
                throw new Exception("Registro no encontrado");
            }

            medicines = mapearDatos(medicines, entity);
            await data.Update(medicines);
        }
    }
}
