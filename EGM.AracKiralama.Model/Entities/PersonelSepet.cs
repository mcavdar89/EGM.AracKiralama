using Infra.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Entities
{
    public class PersonelSepet : BaseEntity<Guid>
    {
        public int PersonelId { get; set; }

        public virtual Personel Personel { get; set; }
        public virtual ICollection<PersonelSepetUrun> PersonelSepetUrunList {  get; set; }

    }

}
