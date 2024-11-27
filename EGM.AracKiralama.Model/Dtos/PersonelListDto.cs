using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class PersonelListDto
    {
        public int Id { get; set; }
        public byte StatusId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UnvanId { get; set; }
        public string UnvanAd { get; set; }
        public int BirimId { get; set; }
        public string BirimAd { get; set; }
        public DateTime LastTransactionDate { get; set; }

    }
}
