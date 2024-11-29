using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class MarketUrunDto : BaseEntity<short>
    {
        public Guid Id { get; set; }
        public int MarketId { get; set; }
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Stok { get; set; }
        public decimal Puan { get; set; }

    }
}
