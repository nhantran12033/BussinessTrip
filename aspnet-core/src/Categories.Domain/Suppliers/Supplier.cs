using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Categories.Suppliers
{
    public class Supplier: AuditedAggregateRoot<Guid>
    {
        public Guid LegalID { get; set; }
        public string VendorAccount { get; set; }
        public string VendorName { get; set; }
        public string VendorHold { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string BeneficiaryBankName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TaxCode { get; set; }
        public string ImportBy { get; set; }
    }
}
