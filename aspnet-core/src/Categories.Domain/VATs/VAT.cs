using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Categories.VATs
{
    public class VAT : AuditedAggregateRoot<Guid>
    {
        public int VATs { get; set; }
        public int VATAxCode { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        
    } 
}
