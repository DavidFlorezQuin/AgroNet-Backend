using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Race : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryAnimalId { get; set; }
        public CategoryAnimal CategoryAnimal { get; set; }
    }
}
