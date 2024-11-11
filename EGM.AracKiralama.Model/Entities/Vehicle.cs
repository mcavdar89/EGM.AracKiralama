using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class Vehicle: BaseEntity
    {
        public string Plate { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }

        public short BrandId { get; set; }

        public short? ModelId { get; set; }

        public decimal DailyPrice { get; set; }

        [ForeignKey("ModelId")]
        public virtual BrandModel? Model { get; set; }
        public virtual Brand Brand { get; set; }

    }
}
