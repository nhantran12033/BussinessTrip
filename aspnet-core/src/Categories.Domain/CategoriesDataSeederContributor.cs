using Categories.Currencys;
using Categories.Departments;
using Categories.ExpenseCodes;
using Categories.LegalEntitys;
using Categories.Suppliers;
using Categories.Trips;
using Categories.VATs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Categories
{
    public class CategoriesDataSeederContributor: IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<VAT, Guid> _vatRepository;
        private readonly IRepository<LegalEntity, Guid> _legalEntityRepository;
        private readonly IRepository<Supplier, Guid> _supplierRepository;
        private readonly IRepository<ExpenseCode,Guid> _expenseCodeRepository;
        private readonly IRepository<Department, Guid> _departmentRepository;
        private readonly IRepository<Trip, Guid> _tripRepository;
        private readonly IRepository<Currency, Guid> _currencyRepository;
        public CategoriesDataSeederContributor(IRepository<VAT, Guid> vatRepository, 
            IRepository<LegalEntity, Guid> legalEntityRepository,
            IRepository<Supplier, Guid> supplierRepository,
            IRepository<ExpenseCode, Guid> expenseCodeRepository,
            IRepository<Department, Guid> departmentRepository,
            IRepository<Trip, Guid> tripRepository,
            IRepository<Currency, Guid> currencyRepository)
        {
            _vatRepository= vatRepository;
            _legalEntityRepository= legalEntityRepository;
            _supplierRepository= supplierRepository;
            _expenseCodeRepository = expenseCodeRepository;
            _departmentRepository= departmentRepository;
            _tripRepository= tripRepository;
            _currencyRepository= currencyRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await _expenseCodeRepository.InsertAsync(
                new ExpenseCode
                {
                    Code = "E05_08",
                    Description = "CP chuyen phat nhanh (xoa bo)",
                    ImportBy = "",
                },autoSave: true);
            await _expenseCodeRepository.InsertAsync(
                new ExpenseCode
                {
                    Code = "E05_010",
                    Description = "Chi phi van phong khac (xoa bo)",
                    ImportBy = "",
                }, autoSave: true);
            await _expenseCodeRepository.InsertAsync(
                new ExpenseCode
                {
                    Code = "E06_01",
                    Description = "Deskphone cost",
                    ImportBy = "",
                }, autoSave: true);
            var ex = await _expenseCodeRepository.InsertAsync(
                new ExpenseCode
                {
                    Code = "E06_02",
                    Description = "Handphone cost",
                    ImportBy = "",
                }, autoSave: true);
            var depart = await _departmentRepository.InsertAsync(
                new Department
                {
                    Code = "02_01",
                    Description = "NS South",
                    ImportBy = "thanh.nguyen@navigosgroup.com"
                },autoSave:true);
            if (await _vatRepository.GetCountAsync() <= 0)
            {
                await _vatRepository.InsertAsync(
                    new VAT
                    {
                        VATs = 5,
                        VATAxCode = 5,
                        Description = "5",
                        Modified = new DateTime(2023, 9, 12),
                        ModifiedBy = "123"
                    }, autoSave: true);
            }
            var legal = await _legalEntityRepository.InsertAsync(
                new LegalEntity
                {
                    Code = "N07",
                    Description = "Navigos Hà Nội",
                    ImportBy = "nhantran12033@gmail.com"
                }, autoSave: true);
            var legal1 = await _legalEntityRepository.InsertAsync(
                new LegalEntity
                {
                    Code = "N08",
                    Description = "Navigos ",
                    ImportBy = "nhantran12033@gmail.com"
                }, autoSave: true);
            var legal2 = await _legalEntityRepository.InsertAsync(
                new LegalEntity
                {
                    Code = "N09",
                    Description = "Hà Nội",
                    ImportBy = "nhantran12033@gmail.com"
                }, autoSave: true);
            await _supplierRepository.InsertAsync(
                new Supplier
                {
                    LegalID = legal.Id,
                    VendorAccount = "VD00000035",
                    VendorName = "Bao Dau Tu (VIR)",
                    VendorHold = "No",
                    BeneficiaryName = "Bao Dau Tu",
                    BeneficiaryAccount = "21210",
                    BeneficiaryBankName = "BIDV - CN Tay Ho",
                    Phone = "0349528312",
                    Email = "nhantran12033@gmail.com",
                    TaxCode = "0304117088",
                    ImportBy = "thanh.nguyen@navigosgroup.com"
                }, autoSave: true);
            await _supplierRepository.InsertAsync(
                new Supplier
                {
                    LegalID = legal1.Id,
                    VendorAccount = "VD00000035",
                    VendorName = "Bao Dau Tu (VIR)",
                    VendorHold = "No",
                    BeneficiaryName = "Bao Dau Tu",
                    BeneficiaryAccount = "21210",
                    BeneficiaryBankName = "BIDV - CN Tay Ho",
                    Phone = "0349528312",
                    Email = "nhantran12033@gmail.com",
                    TaxCode = "0304117088",
                    ImportBy = "thanh.nguyen@navigosgroup.com"
                }, autoSave: true);
            await _supplierRepository.InsertAsync(
                new Supplier
                {
                    LegalID = legal2.Id,
                    VendorAccount = "VD00000035",
                    VendorName = "Bao Dau Tu (VIR)",
                    VendorHold = "No",
                    BeneficiaryName = "Bao Dau Tu",
                    BeneficiaryAccount = "21210",
                    BeneficiaryBankName = "BIDV - CN Tay Ho",
                    Phone = "0349528312",
                    Email = "nhantran12033@gmail.com",
                    TaxCode = "0304117088",
                    ImportBy = "thanh.nguyen@navigosgroup.com"
                }, autoSave: true);
          
            await _currencyRepository.InsertAsync(
                new Currency
                {
                    Code= "AUD",
                    Title= "Aust Dollar",
                    ExchangeRate= 16309.9f,
                    ModifiedBy= "",
                }, autoSave: true);
            await _currencyRepository.InsertAsync(
                new Currency
                {
                    Code= "USD",
                    Title= "US Dollar",
                    ExchangeRate= 23.660f,
                    ModifiedBy= "",
                }, autoSave: true);
            await _currencyRepository.InsertAsync(
                new Currency
                {
                    Code= "VND",
                    Title= "Vietnam Dong",
                    ExchangeRate= 1.0f,
                    ModifiedBy= "",
                }, autoSave: true);
            await _currencyRepository.InsertAsync(
                new Currency
                {
                    Code= "SGD",
                    Title= "Singapore Dollar",
                    ExchangeRate= 17870.21f,
                    ModifiedBy= "",
                }, autoSave: true);
        }
    }

}
