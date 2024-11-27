using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class Urun : BaseEntity
    {
        public string Ad { get; set; }
        public int MiktarTurId { get; set; }
    }
}
