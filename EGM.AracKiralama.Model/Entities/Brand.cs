using Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class Brand : BaseEntity<short>
    {
        public string Name { get; set; }
    }
}
