using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class PersonelSepetUrunDto : BaseDto
    {
        public Guid Id { get; set; }
        public Guid PersonelSepetId { get; set; }
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public decimal Miktar { get; set; }
        public decimal Tutar { get; set; }
        public DateTime LastTransactionDate { get; set; }

    }
}
