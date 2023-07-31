using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Json.SystemTextJson.JsonConverters;

namespace Categories.Suppliers
{
    public interface ISupplierAppService
    {
        public Task<List<SupplierDto>> GetListAsync();
        public Task<List<SupplierDto>> GetIDListAsync(Guid id);
        public Task<SupplierDto> CreateListAsync(SupplierDto supplierDto);
        public Task<SupplierDto> UpdateListAsync(Guid id ,SupplierDto supplierDto);
        public Task DeleteListAsync(Guid id);
        public Task<List<SupplierDto>> GetListWhereAsync(string code, string description
            , string vendorName, string vendorAccount, string vendorHold, string beneficiaryAccount,
            string beneficiaryBankName, string beneficiaryName, string phone, string email,
            string taxCode, string importBy);

    }
}
