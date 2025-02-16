using AutoMapper;
using Entity.Dto.Localitation;
using Entity.Dto.Operation;
using Entity.Dto.Parameter;
using Entity.Model.Localitation;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //OPERATIONAL
            CreateMap<AlertDto , Alerts>().ReverseMap();
            CreateMap<AnimalDto, Animals>().ReverseMap();
            CreateMap<AnimalDiagnosticDto, AnimalDiagnostics>().ReverseMap();
            CreateMap<BirthDto, Births>().ReverseMap();
            CreateMap<FarmDto, Farms>().ReverseMap();
            CreateMap<FarmUserDto, FarmUser>().ReverseMap();
            CreateMap<InseminationDto, Inseminations>().ReverseMap();
            CreateMap<InventoriesDto, Inventories>().ReverseMap();
            CreateMap<InventorySuppliesDto, InventorySupplies>().ReverseMap();
            CreateMap<LotsDto, Lots>().ReverseMap();
            CreateMap<ProductionDto, Productions>().ReverseMap();
            CreateMap<SaleDto, Sales>().ReverseMap();
            CreateMap<TreatmentDto, Treatments>().ReverseMap();
            CreateMap<TreatmentMedicineDto, TreatmentsMedicines>().ReverseMap();
            CreateMap<VaccineAnimalDto, VaccineAnimals>().ReverseMap();
            CreateMap<InventoryRecordsDto, InventoryRecords>().ReverseMap();
            CreateMap<CategoryAlertDto, CategoryAlert>().ReverseMap();
            CreateMap<CategoryDiseaseDto, CategoryDiseases>().ReverseMap();
            CreateMap<CategoryMedicinesDto, CategoryMedicines>().ReverseMap();
            CreateMap<CategorySuppliesDto, CategorySupplies>().ReverseMap();
            CreateMap<VaccineDto, Vaccines>().ReverseMap();
            CreateMap<DiseaseDto, Diseases>().ReverseMap();
            CreateMap<MedicinesDto, Medicines>().ReverseMap();
            CreateMap<AnimalSaleDto, AnimalSales>().ReverseMap(); 
            CreateMap<SuppliesDto, Supplies>().ReverseMap();
            
            //LOCALITATION
            CreateMap<DepartamentDto, Departament>().ReverseMap();
        }

    }
}
