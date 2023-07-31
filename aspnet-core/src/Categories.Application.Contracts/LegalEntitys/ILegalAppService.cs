using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Categories.LegalEntitys
{
    public interface ILegalAppService
    {
        public Task<List<LegalEntityDto>> GetListWhereList(string code, string description, string importBy);
        public Task<List<LegalEntityDto>> GetListID(Guid id);
        public Task<List<LegalEntityDto>> GetListLegalAsync();
        public Task<LegalEntityDto> CreateListLegalAsync(LegalEntityDto legalEntityDto);
        public Task<LegalEntityDto> UpdateListLegalAsync(Guid id, LegalEntityDto legalEntityDto);
        public Task DeleteLegalAsync(Guid id);
    }
}
