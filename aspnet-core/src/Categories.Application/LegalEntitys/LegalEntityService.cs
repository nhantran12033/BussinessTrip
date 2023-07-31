using Categories.Currencys;
using Categories.LegalEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Categories.LegalEntitys
{

    public class LegalEntityService : ApplicationService, ILegalAppService
    {
        private readonly IRepository<LegalEntity, Guid> _legalEntityRepository;
        public LegalEntityService(IRepository<LegalEntity, Guid> legalEntityRepository)
        {
            _legalEntityRepository = legalEntityRepository;
        }
        public async Task<List<LegalEntityDto>> GetListID(Guid id)
        {
            var items = await _legalEntityRepository.GetListAsync();
            return items.Select(b => new LegalEntityDto
            {
                Id = id,
                Code= b.Code,
                Description= b.Description,
                ImportBy = b.ImportBy,
            }).ToList();
        }
        public async Task<List<LegalEntityDto>> GetListLegalAsync()
        {
            var items = await _legalEntityRepository.GetListAsync();
            return items.Select(item => new LegalEntityDto
            {
                Id = item.Id,
                Code = item.Code,
                Description = item.Description,
                ImportBy = item.ImportBy,
            }).ToList();
        }
        public async Task<LegalEntityDto> CreateListLegalAsync(LegalEntityDto legalEntityDto)
        {

            LegalEntity legalEntity = new LegalEntity
            {
                Code = legalEntityDto.Code,
                Description = legalEntityDto.Description,
                ImportBy = legalEntityDto.ImportBy,
            };
            await _legalEntityRepository.InsertAsync(legalEntity);

            var create = new LegalEntityDto
            {
                Id = legalEntity.Id,
                Code = legalEntity.Code,
                Description = legalEntity.Description,
                ImportBy = legalEntity.ImportBy,
            };
            return create;
        }
        public async Task<LegalEntityDto> UpdateListLegalAsync(Guid id, LegalEntityDto legalEntityDto)
        {
            var items = await _legalEntityRepository.FindAsync(id);
            items.Code = legalEntityDto.Code;
            items.Description = legalEntityDto.Description;
            items.ImportBy = legalEntityDto.ImportBy;
            var update = await _legalEntityRepository.UpdateAsync(items);
            var updateDto = new LegalEntityDto
            {
                Id = items.Id,
                Code = items.Code,
                Description = items.Description,
                ImportBy = items.ImportBy,
            };
            return updateDto;
        }

        public async Task DeleteLegalAsync(Guid id)
        {
            await _legalEntityRepository.DeleteAsync(id);
        }

        public async Task<List<LegalEntityDto>> GetListWhereList(string code, string description, string importBy)
        {
            var items = await _legalEntityRepository.GetListAsync();
            return items.Where(b => b.Code.StartsWith(code) ||
            b.Description.StartsWith(description) || b.ImportBy.StartsWith(importBy))
                .Select(b => new LegalEntityDto
                {
                    Id = b.Id,
                    Code = b.Code,
                    Description= b.Description,
                    ImportBy = b.ImportBy
                }).ToList();
        }
    }
}
