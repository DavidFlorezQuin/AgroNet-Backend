﻿using Business.Operational.Interface;
using Entity.Dto.Operation;
using Microsoft.AspNetCore.Components;

namespace Web.Controllers.Operational.services
{
    [Route("api/[controller]")]

    public class TreatmentMedicinesController : BaseController<TreatmentMedicineDto, ITreatmentsMedicinesBusiness>
    {
        public TreatmentMedicinesController(ITreatmentsMedicinesBusiness treatmentsMedicinesBusiness) : base(treatmentsMedicinesBusiness) { }

    }
}
