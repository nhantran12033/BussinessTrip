using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categories.KindOfFAL;
using Categories.KindOfFALs;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Categories.KindOfFALs
{
    public class KindOfFALService: ApplicationService, IKindOFALAppService
    {
        private readonly IRepository<KindOfFAL, Guid> _kindoffalRepository;
        public KindOfFALService(IRepository<KindOfFAL, Guid> kindoffalRepository)
        {
            _kindoffalRepository = kindoffalRepository;
        }

        public async Task<KindOfFALDto> CreateListAsync(KindOfFALDto kindOfFALDto)
        {
            KindOfFAL kind = new KindOfFAL
            {
                KindOfFal = kindOfFALDto.KindofFal,
                Description = kindOfFALDto.Description,
                ModifiedBy = kindOfFALDto.ModifiedBy
            };
            await _kindoffalRepository.InsertAsync(kind);
            var create = new KindOfFALDto
            {
                Id = kind.Id,
                KindofFal = kind.KindOfFal,
                Description = kind.Description,
                ModifiedBy = kind.ModifiedBy
            };
            return create;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _kindoffalRepository.DeleteAsync(id);
        }

        public async Task<List<KindOfFALDto>> GetListAsync()
        {
            var items = await _kindoffalRepository.GetListAsync();
            return items.Select(b => new KindOfFALDto
            {
                Id= b.Id,
                Description= b.Description,
                KindofFal = b.KindOfFal,
                ModifiedBy = b.ModifiedBy
            }).ToList();
        }

        public async Task<List<KindOfFALDto>> GetListID(Guid id)
        {
            var items = await _kindoffalRepository.GetListAsync();
            return items.Where(b => b.Id.Equals(id)).Select(b => new KindOfFALDto
            {
                Id = b.Id,
                KindofFal = b.KindOfFal,
                Description = b.Description,
                ModifiedBy = b.ModifiedBy
            }).ToList();
        }

        public async Task<List<KindOfFALDto>> GetListWhere(string kind, string des, string modifiedby)
        {
            var items = await _kindoffalRepository.GetListAsync();
            return items.Where(b => b.KindOfFal.StartsWith(kind) || b.Description.StartsWith(des) || b.ModifiedBy.StartsWith(modifiedby))
                .Select(b => new KindOfFALDto
                {
                    Id = b.Id,
                    KindofFal = b.KindOfFal,
                    Description = b.Description,
                    ModifiedBy = b.ModifiedBy,
                }).ToList();
        }

        public async Task<KindOfFALDto> UpdateListAsync(Guid id, KindOfFALDto kindOfFALDto)
        {
            var items = await _kindoffalRepository.FindAsync(id);
            items.KindOfFal = kindOfFALDto.KindofFal;
            items.Description = kindOfFALDto.Description;
            items.ModifiedBy = kindOfFALDto.ModifiedBy;
            await _kindoffalRepository.UpdateAsync(items);
            var update = new KindOfFALDto
            {
                Id = items.Id,
                KindofFal = items.KindOfFal,
                Description = items.Description,
                ModifiedBy = items.ModifiedBy
            };
            return update;
        }
    }
}
