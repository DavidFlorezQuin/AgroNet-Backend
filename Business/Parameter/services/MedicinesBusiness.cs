﻿using AutoMapper;
using Business.Operational.services;
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
    public class MedicinesBusiness : BaseBusiness<Medicines, MedicinesDto>, IMedicinesBusiness
    {
        public MedicinesBusiness(IMapper mapper, IMedicinesData data) : base (mapper, data ){ }
    }
}
