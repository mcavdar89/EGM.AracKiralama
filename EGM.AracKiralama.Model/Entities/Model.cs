using Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class Model : BaseEntity<short>
    {
        public string Name { get; set; }

        public short BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
