using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Categories.Currencys
{
    public class Currency: AuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }    
        public string Title { get; set; }
        public float ExchangeRate { get; set; }    
        public string ModifiedBy { get; set; }
    }
}
