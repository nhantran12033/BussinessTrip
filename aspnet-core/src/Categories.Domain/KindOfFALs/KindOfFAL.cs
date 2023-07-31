using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Categories.KindOfFALs
{
    public class KindOfFAL: AuditedAggregateRoot<Guid>
    {
        public string KindOfFal { get; set; }
        public string Description { get; set; }
        public string ModifiedBy { get; set; }
        
    }
    
}
