using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model.Entities
{
    public abstract class BaseEntity<TKey> : Entity
    {
        public BaseEntity()
        {
            StatusId = 1;
        }

        [Key]
        [Column(Order = 0)]
        public TKey Id { get; set; }
        public byte StatusId { get; set; }      

        public DateTime LastTransactionDate { get; set; }

    }
    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
