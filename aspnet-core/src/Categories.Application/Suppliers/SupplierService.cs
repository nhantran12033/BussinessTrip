using Categories.LegalEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static Volo.Abp.UI.Navigation.DefaultMenuNames.Application;

namespace Categories.Suppliers
{
    public class SupplierService: ApplicationService, ISupplierAppService
    {
        private readonly IRepository<Supplier, Guid> _supplierRepository;
        private readonly IRepository<LegalEntity, Guid> _legalEntityRepository;
        public SupplierService(IRepository<Supplier, Guid> supplierRepository, IRepository<LegalEntity, Guid> legalEntityRepository)
        {
            _supplierRepository = supplierRepository;
            _legalEntityRepository = legalEntityRepository;
        }

        public async Task<SupplierDto> CreateListAsync(SupplierDto supplierDto)
        {
            var legals = await _legalEntityRepository.GetListAsync();

            Supplier sup = new Supplier
            {
                LegalID = (Guid)(legals.FirstOrDefault(legal => legal.Code == supplierDto.Code)?.Id),
                VendorAccount = supplierDto.VendorAccount,
                VendorName = supplierDto.VendorName,
                VendorHold = supplierDto.VendorHold,
                BeneficiaryName = supplierDto.BeneficiaryName,
                BeneficiaryAccount = supplierDto.BeneficiaryAccount,
                BeneficiaryBankName = supplierDto.BeneficiaryBankName,
                Phone = supplierDto.Phone,
                Email = supplierDto.Email,
                TaxCode = supplierDto.TaxCode,
                ImportBy = supplierDto.ImportBy
            };
            await _supplierRepository.InsertAsync(sup);
            string description = legals.FirstOrDefault(legal => legal.Id == sup.LegalID).Description;
            var create = new SupplierDto
            {
                Id = sup.Id,
                Code = legals.FirstOrDefault(legal => legal.Id == sup.LegalID).Code,
                Description = description,
                VendorAccount = sup.VendorAccount,
                VendorName = sup.VendorName,
                VendorHold = sup.VendorHold,
                BeneficiaryName =   sup.BeneficiaryName,
                BeneficiaryAccount = sup.BeneficiaryAccount,
                BeneficiaryBankName = sup.BeneficiaryBankName,
                Phone = sup.Phone,
                Email = sup.Email,
                TaxCode = sup.TaxCode,
                ImportBy = sup.ImportBy
            };
            return create;
        }

        public async Task DeleteListAsync(Guid id)
        {
            await _supplierRepository.DeleteAsync(id);
        }

        public async Task<List<SupplierDto>> GetIDListAsync(Guid id)
        {
            var items = await _supplierRepository.GetListAsync();
            var legals = await _legalEntityRepository.GetListAsync();
            return items.Where(b=>b.Id.Equals(id)).Select(b => new SupplierDto
            {
                Id = b.Id,
                Code = legals.FirstOrDefault(legal => legal.Id == b.LegalID)?.Code,
                VendorAccount = b.VendorAccount,
                VendorName = b.VendorName,
                VendorHold = b.VendorHold,
                BeneficiaryName = b.BeneficiaryName,
                BeneficiaryAccount = b.BeneficiaryAccount,
                BeneficiaryBankName = b.BeneficiaryBankName,
                Phone = b.Phone,
                Email = b.Email,
                TaxCode = b.TaxCode,
                ImportBy = b.ImportBy

            }).ToList();
        }


        public async Task<List<SupplierDto>> GetListAsync()
        {
            var items = await _supplierRepository.GetListAsync();
            var legals = await _legalEntityRepository.GetListAsync();
            return items.Select(b => new SupplierDto
            {
                Id = b.Id,
                Code = legals.FirstOrDefault(legal => legal.Id == b.LegalID)?.Code,
                Description = legals.FirstOrDefault(legal => legal.Id == b.LegalID)?.Description,
                VendorAccount = b.VendorAccount,
                VendorName = b.VendorName,
                VendorHold = b.VendorHold,
                BeneficiaryName = b.BeneficiaryName,
                BeneficiaryAccount = b.BeneficiaryAccount,
                BeneficiaryBankName = b.BeneficiaryBankName,
                Phone = b.Phone,
                Email = b.Email,
                TaxCode = b.TaxCode,
                ImportBy = b.ImportBy

            }).ToList();
        }

        public async Task<List<SupplierDto>> GetListWhereAsync(string code, string description, string vendorName, string vendorAccount, string vendorHold, string beneficiaryAccount, string beneficiaryBankName, string beneficiaryName, string phone, string email, string taxCode, string importBy)
        {
            var items = await _supplierRepository.GetListAsync();
            var legals = await _legalEntityRepository.GetListAsync();
            return items.Where(b => b.VendorAccount.StartsWith(vendorAccount) || b.VendorHold.StartsWith(vendorHold) ||
            b.VendorName.StartsWith(vendorName) || b.BeneficiaryAccount.StartsWith(beneficiaryAccount) ||
            b.BeneficiaryName.StartsWith(beneficiaryName) || b.BeneficiaryBankName.StartsWith(beneficiaryBankName) ||
            b.Phone.StartsWith(phone) || b.Email.StartsWith(email) || b.TaxCode.StartsWith(taxCode) ||
            b.ImportBy.StartsWith(importBy) || b.LegalID == ((legals.FirstOrDefault(legal => legal.Code == code)?.Id))
            || b.LegalID == ((legals.FirstOrDefault(legal => legal.Description == description)?.Id))).Select(b => new SupplierDto
            {
                Id = b.Id,
                Code = legals.FirstOrDefault(legal => legal.Id == b.LegalID)?.Code,
                Description = legals.FirstOrDefault(legal => legal.Id == b.LegalID)?.Description,
                VendorAccount = b.VendorAccount,
                VendorName = b.VendorName,
                VendorHold = b.VendorHold,
                BeneficiaryName = b.BeneficiaryName,
                BeneficiaryAccount = b.BeneficiaryAccount,
                BeneficiaryBankName = b.BeneficiaryBankName,
                Phone = b.Phone,
                Email = b.Email,
                TaxCode = b.TaxCode,
                ImportBy = b.ImportBy

            }).ToList();
        }

        public async Task<SupplierDto> UpdateListAsync(Guid id ,SupplierDto supplierDto)
        {
            var items = await _supplierRepository.FindAsync(id);
            var legals = await _legalEntityRepository.GetListAsync();

            items.LegalID = (Guid)(legals.FirstOrDefault(legal => legal.Code == supplierDto.Code)?.Id);
            items.VendorAccount = supplierDto.VendorAccount;
            items.VendorName = supplierDto.VendorName;
            items.VendorHold = supplierDto.VendorHold;
            items.BeneficiaryName = supplierDto.BeneficiaryName;
            items.BeneficiaryAccount = supplierDto.BeneficiaryAccount;
            items.BeneficiaryBankName = supplierDto.BeneficiaryBankName;
            items.Phone = supplierDto.Phone;
            items.Email = supplierDto.Email;
            items.TaxCode = supplierDto.TaxCode;
            items.ImportBy = supplierDto.ImportBy;

            await _supplierRepository.UpdateAsync(items);
            var update = new SupplierDto
            {
                Id = items.Id,
                Code = legals.FirstOrDefault(legal => legal.Id == items.LegalID)?.Code,
                VendorAccount = items.VendorAccount,
                VendorName = items.VendorName,
                VendorHold = items.VendorHold,
                BeneficiaryName = items.BeneficiaryName,
                BeneficiaryAccount = items.BeneficiaryAccount,
                BeneficiaryBankName = items.BeneficiaryBankName,
                Phone = items.Phone,
                Email = items.Email,
                TaxCode = items.TaxCode,
                ImportBy = items.ImportBy
            };
            return update;
        }
    }
}
