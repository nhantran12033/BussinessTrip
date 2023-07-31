using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Categories.ExpenseCodes
{
    public class ExpenseCode: AuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string ImportBy { get; set; }
    }
}
