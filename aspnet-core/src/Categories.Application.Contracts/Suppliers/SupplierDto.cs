using System;

namespace Categories.Suppliers
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
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
