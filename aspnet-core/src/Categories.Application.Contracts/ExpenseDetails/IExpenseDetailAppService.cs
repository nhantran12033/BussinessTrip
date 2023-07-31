using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Categories.ExpenseDetail
{
    public interface IExpenseDetailAppService
    {
        public Task<ExpenseDetailDto> CreateListAsync(int total,List<ExpenseDetailDto> dto);
        public Task<List<ExpenseDetailDto>> GetListAsync();

    }
}
