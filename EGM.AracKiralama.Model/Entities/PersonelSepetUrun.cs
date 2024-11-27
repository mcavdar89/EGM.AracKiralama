using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class PersonelSepetUrun : BaseEntity<Guid>
    {
        public Guid PersonelSepetId { get; set; }
        public int UrunId { get; set; }
        public decimal Miktar { get; set; }
        public decimal Tutar { get; set; }
    }
}
