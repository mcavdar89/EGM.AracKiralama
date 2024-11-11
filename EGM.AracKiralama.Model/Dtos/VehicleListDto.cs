using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class VehicleListDto:BaseDto
    {
        public int Id { get; set; }
        public string BrandAd { get; set; }
        public string ModelAd { get; set; }
        public string Plate { get; set; }
    }
}
