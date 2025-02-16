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
    public class AnimalSalesData : ABaseData<AnimalSales>, IAnimalSaleData
    {

        public AnimalSalesData(AplicationDbContext context) : base(context) { }

        
        public override async Task<AnimalSales> Save(AnimalSales entity)
        {
            entity.state = true;
            entity.created_at = DateTime.Now;

            var moneda = await context.Animals
            .Where(a => a.Id == entity.AnimalsId)
            .Select(a => a.Lot.Farm.City.Departament.Country.Simbolo)
            .FirstOrDefaultAsync();

            if (moneda == null)
            {
                throw new Exception("No se encontró la moneda asociada.");
            }

            entity.Currency = moneda;

            var animal = await context.Animals.FindAsync(entity.AnimalsId); 

            if(animal == null)
            {
                throw new Exception("Animal no registrado"); 
            }

            animal.state = false;

            context.AnimalSales.Add(entity);
            context.Animals.Update(animal); 
            await context.SaveChangesAsync();
            return entity; 
        }

        public async Task<List<AnimalSaleDto>> GetAnimalSaleAsync(int farmId)
        {
            var AnimalSale = await context.AnimalSales
                .Include(a => a.Animals)
                .Where(a => a.Animals.Lot.Farm.Id == farmId && a.Animals.Lot.Farm.state == true)
                .Select(a => new AnimalSaleDto
                {
                    Id = a.Id,
                    Price = a.Price,
                    Currency = a.Currency,
                    AnimalsId = a.AnimalsId,
                    Weight = a.Weight,
                    Animals = a.Animals.Name
                }).ToListAsync(); 

            return AnimalSale;
        }

    }
}
