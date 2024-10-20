using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class TreatmentMedicinesData : ABaseData<TreatmentsMedicines>, ITreatmentsMedicinesData
    {

        public TreatmentMedicinesData(AplicationDbContext context) : base(context) { }

        public async Task<List<TreatmentMedicineDto>> GetTreatmentMedicineAsync(int farmId)
        {
            var treatmentMedicine = await context.TreatmentsMedicines
                .Include(b => b.Treatment)
                .Include(b => b.Medicines)
                .Where(b => b.Treatment.AnimalDiagnostics.Animal.Lot.Farm.Id == farmId && b.Treatment.AnimalDiagnostics.Animal.Lot.Farm.state == true && b.deleted_at == null)
                .Select(b => new TreatmentMedicineDto
                {
                    Id = b.Id,
                    Description = b.Description,
                    state = b.state,
                    Medicines = b.Medicines.Name,
                    PeriocityDay = b.PeriocityDay,
                    Treatment = b.Treatment.Name,
                    MedicinesId = b.TreatmentId,
                    TreatmentId = b.TreatmentId
                }).ToListAsync();
            return treatmentMedicine; 
        }

        public async Task<List<TreatmentMedicineDto>> GetMedicineForTreatments(int treatmentId)
        {
            var medicine = await context.TreatmentsMedicines
                .Include(b => b.Treatment)
                .Include(b => b.Medicines)
                .Where(b => b.TreatmentId == treatmentId)
                .Select(b => new TreatmentMedicineDto
                {
                    Id = b.Id,
                    Description = b.Description,
                    state = b.state,
                    Medicines = b.Medicines.Name,
                    PeriocityDay = b.PeriocityDay,
                    Treatment = b.Treatment.Name,
                    MedicinesId = b.TreatmentId,
                    TreatmentId = b.TreatmentId
                }).ToListAsync();

            return medicine; 
        }

    }
}
