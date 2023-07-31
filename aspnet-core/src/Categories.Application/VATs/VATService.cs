using AutoMapper.Internal.Mappers;
using Categories.Departments;
using Categories.LegalEntitys;
using Scriban.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Categories.VATs
{
    public class VATService: ApplicationService, IVATAppService
    {
        public readonly IRepository<VAT, Guid> _vatRepository;
        public VATService(IRepository<VAT, Guid> vatRepository)
        {
            _vatRepository = vatRepository;
        }
        public async Task<VATDTO> CreateListAsync(VATDTO VatDto)
        {

            VAT vat = new VAT
            {
                VATs = VatDto.VATs,
                VATAxCode = VatDto.VATAxCode,
                Description = VatDto.Description,
                Modified = VatDto.Modified,
                ModifiedBy = VatDto.ModifiedBy

            };
            await _vatRepository.InsertAsync(vat);

            var create = new VATDTO
            {
                Id = vat.Id,
                VATs = vat.VATs,
                VATAxCode = vat.VATAxCode,
                Description = vat.Description,
                Modified = vat.Modified,
                ModifiedBy = vat.ModifiedBy,
            };
            return create;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _vatRepository.DeleteAsync(id);
        }

        public async Task<List<VATDTO>> GetListAsync()
        {
            var items = await _vatRepository.GetListAsync();
            return items.Select(b => new VATDTO
                {
                    Id = b.Id,
                    VATs = b.VATs,
                    VATAxCode = b.VATAxCode,
                    Description = b.Description,
                    Modified = b.Modified,
                    ModifiedBy = b.ModifiedBy,
                }).ToList();
        }

        public async Task<List<VATDTO>> GetListID(Guid id)
        {
            var items = await _vatRepository.GetListAsync();
            return items.Where(b => b.Id.Equals(id)).Select(b => new VATDTO
            {
                Id = b.Id,
                VATs= b.VATs,
                VATAxCode= b.VATAxCode,
                Description = b.Description,
                Modified = b.Modified,
                ModifiedBy = b.ModifiedBy,
            }).ToList();
        }
        public async Task<List<VATDTO>> GetListWhereIntAsync(int vats,int vataxcode)
        {
            var items = await _vatRepository.GetListAsync();
            return items.Where(b=>b.VATAxCode == vataxcode || b.VATs == vats)
                .Select(b => new VATDTO
            {
                Id = b.Id,
                VATs = b.VATs,
                VATAxCode = b.VATAxCode,
                Description = b.Description,
                Modified = b.Modified,
                ModifiedBy = b.ModifiedBy,
            }).ToList();
        }
        public async Task<List<VATDTO>> GetListWhereStringAsync(string description, string modifiedBy)
        {
            var items = await _vatRepository.GetListAsync();
            return items.Where(b => b.Description.StartsWith(description) || b.ModifiedBy.StartsWith(modifiedBy))
                .Select(b => new VATDTO
                {
                    Id = b.Id,
                    VATs = b.VATs,
                    VATAxCode = b.VATAxCode,
                    Description = b.Description,
                    Modified = b.Modified,
                    ModifiedBy = b.ModifiedBy,
                }).ToList();
        }
        public async Task<VATDTO> UpdateListAsync(Guid id, VATDTO VatDto)
        {
            var items = await _vatRepository.FindAsync(id);
            items.VATs = VatDto.VATs;
            items.VATAxCode = VatDto.VATAxCode;
            items.Description= VatDto.Description;
            var update = await _vatRepository.UpdateAsync(items);
            var updateDto = new VATDTO
            {
               VATs = update.VATs,
               VATAxCode= update.VATAxCode,
               Description= update.Description,
               ModifiedBy = update.ModifiedBy,
               Modified= update.Modified,
            };
            return updateDto;
        }
    }
}
