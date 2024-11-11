using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class Rent:BaseEntity<Guid>
    {
        public Guid VehicleId { get; set; }
        public Guid UserId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal Price { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual User User { get; set; }
    }
}
