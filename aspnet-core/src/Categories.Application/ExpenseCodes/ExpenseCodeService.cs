using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Categories.ExpenseCodes
{
    public class ExpenseCodeService: ApplicationService, IExpenseCodeAppService
    {
        private readonly IRepository<ExpenseCode, Guid> _expensecodeRepository;
        public ExpenseCodeService(IRepository<ExpenseCode, Guid> expensecodeRepository)
        {
            _expensecodeRepository = expensecodeRepository;
        }

        public async Task<ExpenseCodeDto> CreateListAsync(ExpenseCodeDto expenseCodeDto)
        {
            ExpenseCode ex = new ExpenseCode
            {
                Code = expenseCodeDto.Code,
                Description= expenseCodeDto.Description,
                ImportBy = expenseCodeDto.ImportBy,
            };
            await _expensecodeRepository.InsertAsync(ex);
            var create = new ExpenseCodeDto
            {
                Id = ex.Id,
                Code = ex.Code,
                Description = ex.Description,
                ImportBy = ex.ImportBy,
            };
            return create;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _expensecodeRepository.DeleteAsync(id);
        }

        public async Task<List<ExpenseCodeDto>> GetListAsync()
        {
            var items = await _expensecodeRepository.GetListAsync();
            return items.Select(b=> new ExpenseCodeDto
            {
                Id = b.Id,
                Code = b.Code,
                Description = b.Description,
                ImportBy = b.ImportBy,
            }).ToList();
        }

        public async Task<List<ExpenseCodeDto>> GetListID(Guid id)
        {
            var items = await _expensecodeRepository.GetListAsync();
            return items.Where(b=>b.Id.Equals(id)).Select(b=> new ExpenseCodeDto
            {
                Id = b.Id,
                Code = b.Code,
                Description = b.Description,
                ImportBy = b.ImportBy,
            }).ToList();
        }

        public async Task<List<ExpenseCodeDto>> GetWhereList(string code, string des, string importBy)
        {
            var items = await _expensecodeRepository.GetListAsync();
            return items.Where(b => b.Code.StartsWith(code) || b.Description.StartsWith(des) || b.ImportBy.StartsWith(importBy)).Select(b => new ExpenseCodeDto
            {
                Id = b.Id,
                Code = b.Code,
                Description = b.Description,
                ImportBy = b.ImportBy,
            }).ToList();
        }

        public async Task<ExpenseCodeDto> UpdateListAsync(Guid id, ExpenseCodeDto expenseCodeDto)
        {
            var items = await _expensecodeRepository.FindAsync(id);
            items.Code = expenseCodeDto.Code;
            items.Description = expenseCodeDto.Description;
            items.ImportBy = expenseCodeDto.ImportBy;
            
            await _expensecodeRepository.UpdateAsync(items);
            var update = new ExpenseCodeDto
            {
                Id = items.Id,
                Code = items.Code,
                Description = items.Description,
                ImportBy = items.ImportBy,
            };
            return update;
        }
    }
}
