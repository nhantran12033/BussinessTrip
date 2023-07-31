using Categories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Categories.Currencys
{
    public class CurrencyService : ApplicationService, ICurrencyAppService
    {
        private readonly IRepository<Currency, Guid> _currencyRepository;
        public CurrencyService(IRepository<Currency, Guid> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        public async Task<List<CurrencyDto>> GetListWhereAsync(string code, string title, float ex, string modified)
        {
            var items = await _currencyRepository.GetListAsync();
            return items.Where(b => b.Code.StartsWith(code) ||
            b.Title.StartsWith(title) || b.ModifiedBy.StartsWith(modified) || b.ExchangeRate.Equals(ex))
                .Select(b => new CurrencyDto
                {
                    Id = b.Id,
                    Code = b.Code,
                    Title = b.Title,
                    ExchangeRate = b.ExchangeRate,
                    ModifiedBy = b.ModifiedBy,
                }).ToList();
        }
        public async Task<List<CurrencyDto>> GetListAsync()
        {
            var items = await _currencyRepository.GetListAsync();
            return items.Select(item => new CurrencyDto
            {
                Id = item.Id,
                Code = item.Code,
                Title = item.Title,
                ExchangeRate = item.ExchangeRate,
                ModifiedBy = item.ModifiedBy,
            }).ToList();
        }
        public async Task<CurrencyDto> CreateListAsync(CurrencyDto currencyDto)
        {
            var items = await _currencyRepository.GetListAsync();
            Currency currency = new Currency
            {
                Code = currencyDto.Code,
                Title = currencyDto.Title,
                ExchangeRate = currencyDto.ExchangeRate,
                ModifiedBy = currencyDto.ModifiedBy,

            };
            await _currencyRepository.InsertAsync(currency);

            var create = new CurrencyDto
            {
                Id = currency.Id,
                Code = currency.Code,
                Title = currency.Title,
                ExchangeRate = currency.ExchangeRate,
                ModifiedBy = currency.ModifiedBy,
            };
            return create;
        }
        public async Task<CurrencyDto> UpdateListAsync(Guid id, CurrencyDto currencyDto)
        {
            var items = await _currencyRepository.FindAsync(id);
            items.Code = currencyDto.Code;
            items.Title = currencyDto.Title;
            items.ExchangeRate = currencyDto.ExchangeRate;
            items.ModifiedBy = currencyDto.ModifiedBy;
            var update = await _currencyRepository.UpdateAsync(items);
            var updateDto = new CurrencyDto
            {
                Id = items.Id,
                Code = items.Code,
                Title = items.Title,
                ExchangeRate = items.ExchangeRate,
                ModifiedBy = items.ModifiedBy
            };
            return updateDto;
        }
        public async Task DeleteAsync(Guid id)
        {
            await _currencyRepository.DeleteAsync(id);
        }

        public async Task<List<CurrencyDto>> GetListID(Guid id)
        {
            var items = await _currencyRepository.GetListAsync();
            return items.Where(b => b.Id.Equals(id)).Select(b => new CurrencyDto
            {
                Id = b.Id,
                Code= b.Code,
                ModifiedBy = b.ModifiedBy,
                ExchangeRate= b.ExchangeRate,
                Title= b.Title,
            }).ToList();
        }
    }
}
