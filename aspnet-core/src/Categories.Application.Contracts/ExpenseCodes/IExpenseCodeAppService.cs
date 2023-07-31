using Categories.Currencys;
using Categories.KindOfFAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Categories.ExpenseCodes
{
    public interface IExpenseCodeAppService
    {
        public Task<List<ExpenseCodeDto>> GetListID(Guid id);
        public Task<List<ExpenseCodeDto>> GetWhereList(string code, string des, string importBy);
        public Task<List<ExpenseCodeDto>> GetListAsync();
        public Task<ExpenseCodeDto> CreateListAsync(ExpenseCodeDto expenseCodeDto);
        public Task<ExpenseCodeDto> UpdateListAsync(Guid id, ExpenseCodeDto expenseCodeDto);
        public Task DeleteAsync(Guid id);
    }
}
