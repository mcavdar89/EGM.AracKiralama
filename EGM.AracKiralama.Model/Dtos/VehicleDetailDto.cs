using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class VehicleDetailDto
    {
        public int Id { get; set; }
        public string BrandAd { get; set; }
        public string ModelAd { get; set; }
        
        public string Plate { get; set; }

        public string Color { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }

        public decimal DailyPrice { get; set; }

    }
}
