
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Currencys
{
    public interface ICurrencyAppService
    {
        public Task<List<CurrencyDto>> GetListID(Guid id);
        public Task<List<CurrencyDto>> GetListWhereAsync(string code, string title, float ex, string modified);
        public Task<List<CurrencyDto>> GetListAsync();
        public Task<CurrencyDto> CreateListAsync(CurrencyDto currencyDto);
        public Task<CurrencyDto> UpdateListAsync(Guid id, CurrencyDto currencyDto);
        public Task DeleteAsync(Guid id);
    }
}
