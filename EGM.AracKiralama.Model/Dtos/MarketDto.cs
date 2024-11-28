using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class MarketDto : BaseEntity<short>
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public decimal Puan { get; set; }

    }
}
