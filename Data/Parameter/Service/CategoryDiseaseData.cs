﻿using Data.Operational.services;
using Data.Parameter.Interface;
using Entity.Context;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Service
{
    public class CategoryDiseaseData : ABaseData<CategoryDisieses>, ICategoryDiseaseData
    {
        public CategoryDiseaseData(AplicationDbContext context) : base(context) { }

    }
}
