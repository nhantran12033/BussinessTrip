using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Categories.TripExpenses;
namespace Categories.Trips
{
    public interface ITripInformationAppService
    {
        public Task DeleteListAsync(Guid id);
        public Task<TripInformationDto> CreateTripInformationAsync(TripInformationDto dto);
        public Task<TripInformationDto> UpdateListAsync(Guid id, TripInformationDto dto);
        public Task<TripInformationDto> GetListIDAsync(Guid id);
        public Task<List<TripInformationDto>> GetTripInformationAsync();
    }
}
