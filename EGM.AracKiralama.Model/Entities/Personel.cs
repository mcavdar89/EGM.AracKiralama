using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class Personel : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UnvanId { get; set; }
        public int BirimId { get; set; }

        public virtual Unvan? Unvan { get; set; }

        public virtual Birim? Birim { get; set; }

        public virtual PersonelSepet PersonelSepet { get; set; }
    }
}
