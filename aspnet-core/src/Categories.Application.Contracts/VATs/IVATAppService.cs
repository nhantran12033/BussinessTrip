
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Categories.VATs
{
    public interface IVATAppService
    {
        public Task<List<VATDTO>> GetListID(Guid id);
        public Task<List<VATDTO>> GetListWhereIntAsync(int vats,int vataxcode);
        public Task<List<VATDTO>> GetListWhereStringAsync(string modifiedBy, string description);
        public Task<List<VATDTO>> GetListAsync();
        public Task<VATDTO> CreateListAsync(VATDTO VatDto);
        public Task<VATDTO> UpdateListAsync(Guid id, VATDTO VatDto);
        public Task DeleteAsync(Guid id);
    }
}
