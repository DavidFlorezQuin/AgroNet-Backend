using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class SaleData : ABaseData<Sales>, ISaleData
    {
        public SaleData(AplicationDbContext context) : base(context) { }

    }
}
