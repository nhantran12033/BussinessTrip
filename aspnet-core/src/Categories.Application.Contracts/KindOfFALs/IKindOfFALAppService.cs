using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Categories.KindOfFAL
{
    public interface IKindOFALAppService
    {
        public Task<List<KindOfFALDto>> GetListID(Guid id);
        public Task<List<KindOfFALDto>> GetListWhere(string kind, string des, string modifiedby);
        public Task<List<KindOfFALDto>> GetListAsync();
        public Task<KindOfFALDto> CreateListAsync(KindOfFALDto kindOfFALDto);
        public Task<KindOfFALDto> UpdateListAsync(Guid id, KindOfFALDto kindOfFALDto);
        public Task DeleteAsync(Guid id);
    }
}
