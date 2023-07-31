using Categories.ExpenseCodes;
using Categories.LegalEntitys;
using Categories.Departments;
using Categories.TripExpenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities.Events.Distributed;


namespace Categories.Trips
{
    public class TripInformationService: ApplicationService, ITripInformationAppService
    {
        private readonly IRepository<Trip, Guid> _TripInformationRepository;
        private readonly IRepository<TripExpense, Guid> _TripExRepository;
        private readonly IRepository<ExpenseCode, Guid> _expenseCodeRepository;
        private readonly IRepository<Department, Guid> _departmentRepository;
        private readonly IRepository<LegalEntity, Guid> _legalRepository;
        public TripInformationService(IRepository<Trip, Guid> TripInformationRepository,
            IRepository<ExpenseCode, Guid> expenseCodeRepository,
            IRepository<LegalEntity, Guid> legalRepository,
            IRepository<Department, Guid> departmentRepository,
            IRepository<TripExpense, Guid> tripExRepository)
        {
            _legalRepository = legalRepository;
            _expenseCodeRepository = expenseCodeRepository;
            _TripInformationRepository = TripInformationRepository;
            _departmentRepository = departmentRepository;
            _TripExRepository = tripExRepository;
        }

        public async Task<TripInformationDto> CreateTripInformationAsync(TripInformationDto dto)
        {
            var legals = await _legalRepository.GetListAsync();
            var expenses = await _expenseCodeRepository.GetListAsync();
            var departments = await _departmentRepository.GetListAsync();
            Trip trip = new Trip
            {
                OperaterName = dto.OperaterName,
                VerifierName = dto.VerifierName,
                VerifierUsername = dto.VerifierUsername,
                BusinessType = dto.BusinessType,
                Notes = dto.Notes,
                RequestedDate = dto.RequestedDate,
                RequestNumber = dto.RequestNumber,
                DepartmentID = (Guid)departments.FirstOrDefault(d => d.Code == dto.Department)?.Id,
                ExpenseCodeID = (Guid)expenses.FirstOrDefault(d => d.Code == dto.ExpenseCode)?.Id,
                LegalID = (Guid)legals.FirstOrDefault(d => d.Code == dto.LegalEntity)?.Id,
                TotalAmount = dto.TotalAmount,
                TripExpenseDetail = new List<TripExpense>() // Initialize an empty list
            };

            foreach (var expenseDto in dto.TripExpenseDetail)
            {
                TripExpense tripExpense = new TripExpense
                {
                    Id = expenseDto.Id,
                    TripId = trip.Id,
                    Purpose = expenseDto.Purpose,
                    Destination = expenseDto.Destination,
                    CheckinTime = expenseDto.CheckinTime,
                    CheckoutTime = expenseDto.CheckoutTime,
                    TotalNights = expenseDto.TotalNights,
                    Item = expenseDto.Item,
                    Specification = expenseDto.Specification,
                    OriginalCurrency = expenseDto.OriginalCurrency,
                    OriginalUnit = expenseDto.OriginalUnit,
                    Volume = expenseDto.Volume,
                    OriginalAmount = expenseDto.OriginalAmount,
                    EquivalentInVND = expenseDto.EquivalentInVND,
                    Notes = expenseDto.Notes
                };
                trip.TripExpenseDetail.Add(tripExpense);
            }

            var item = await _TripInformationRepository.InsertAsync(trip);
            var create = new TripInformationDto
            {
                Id = item.Id,
           
                OperaterName = item.OperaterName,
                VerifierName = item.VerifierName,
                VerifierUsername = item.VerifierUsername,
                BusinessType = item.BusinessType,
                Notes = item.Notes,
                RequestedDate = item.RequestedDate,
                RequestNumber = item.RequestNumber,
                Department = departments.FirstOrDefault(d => d.Id == item.DepartmentID)?.Code,
                ExpenseCode = expenses.FirstOrDefault(d => d.Id == item.ExpenseCodeID)?.Code,
                LegalEntity = legals.FirstOrDefault(d => d.Id == item.LegalID)?.Code,
                TotalAmount = item.TotalAmount,
                TripExpenseDetail = item.TripExpenseDetail.Select(te => new TripExpenseDto
                {
                    Id = te.Id,   
                    TripId = item.Id,
                    Purpose = te.Purpose,
                    Destination = te.Destination,
                    CheckinTime = te.CheckinTime,
                    CheckoutTime = te.CheckoutTime,
                    TotalNights = te.TotalNights,
                    Item = te.Item,
                    Specification = te.Specification,
                    OriginalCurrency = te.OriginalCurrency,
                    OriginalUnit = te.OriginalUnit,
                    Volume = te.Volume,
                    OriginalAmount = te.OriginalAmount,
                    EquivalentInVND = te.EquivalentInVND,
                    Notes = te.Notes
                }).ToList()
            };
            return create;

        }
        public async Task DeleteListAsync(Guid id)
        {
            await _TripInformationRepository.DeleteAsync(id);
        }


        public async Task<List<TripInformationDto>> GetTripInformationAsync()
        {
            var legal = await _legalRepository.GetListAsync();
            var ex = await _expenseCodeRepository.GetListAsync();
            var department = await _departmentRepository.GetListAsync();
            var items = await _TripInformationRepository.GetListAsync();
            var item = await _TripExRepository.GetListAsync();
            return items.Select(e => new TripInformationDto
            {
                Id = e.Id,
                OperaterName = e.OperaterName,
                VerifierName = e.VerifierName,
                VerifierUsername = e.VerifierUsername,
                BusinessType = e.BusinessType,
                Notes = e.Notes,
                RequestedDate = e.RequestedDate,
                RequestNumber = e.RequestNumber,
                Department = department.FirstOrDefault(d => d.Id == e.DepartmentID)?.Code,
                ExpenseCode = ex.FirstOrDefault(b => b.Id == e.ExpenseCodeID)?.Code,
                LegalEntity = legal.FirstOrDefault(t => t.Id == e.LegalID)?.Code,
                TotalAmount = e.TotalAmount,
                TripExpenseDetail = item.Where(te => te.TripId == e.Id).Select(te => new TripExpenseDto
                {
                    Purpose = te.Purpose,
                    Destination = te.Destination,
                    CheckinTime = te.CheckinTime,
                    CheckoutTime = te.CheckoutTime,
                    TotalNights = te.TotalNights,
                    Item = te.Item,
                    Specification = te.Specification,
                    OriginalCurrency = te.OriginalCurrency,
                    OriginalUnit = te.OriginalUnit,
                    Volume = te.Volume,
                    OriginalAmount = te.OriginalAmount,
                    EquivalentInVND = te.EquivalentInVND,
                    Notes = te.Notes
                }).ToList()
            }).ToList();
        }
        public async Task<TripInformationDto> UpdateListAsync(Guid id, TripInformationDto dto)
        {
            var legals = await _legalRepository.GetListAsync();
            var expenses = await _expenseCodeRepository.GetListAsync();
            var departments = await _departmentRepository.GetListAsync();
            var items = await _TripInformationRepository.FindAsync(id);
            var item = await _TripExRepository.GetListAsync();
            items.OperaterName = dto.OperaterName;
            items.VerifierName = dto.VerifierName;
            items.VerifierUsername = dto.VerifierUsername;
            items.BusinessType = dto.BusinessType;
            items.Notes = dto.Notes;
            items.RequestedDate = dto.RequestedDate;
            items.RequestNumber = dto.RequestNumber;
            items.DepartmentID = (Guid)departments.FirstOrDefault(d => d.Code == dto.Department)?.Id;
            items.ExpenseCodeID = (Guid)expenses.FirstOrDefault(d => d.Code == dto.ExpenseCode)?.Id;
            items.LegalID = (Guid)legals.FirstOrDefault(d => d.Code == dto.LegalEntity)?.Id;
            items.TotalAmount = dto.TotalAmount;

            items.TripExpenseDetail.RemoveAll(x => true);
            foreach (var tripExpenseDto in dto.TripExpenseDetail)
            {
                var expense = new TripExpense
                {
                    Id = tripExpenseDto.Id,
                    TripId = items.Id,
                    Purpose = tripExpenseDto.Purpose,
                    Destination = tripExpenseDto.Destination,
                    CheckinTime = tripExpenseDto.CheckinTime,
                    CheckoutTime = tripExpenseDto.CheckoutTime,
                    TotalNights = tripExpenseDto.TotalNights,
                    Item = tripExpenseDto.Item,
                    Specification = tripExpenseDto.Specification,
                    OriginalCurrency = tripExpenseDto.OriginalCurrency,
                    OriginalUnit = tripExpenseDto.OriginalUnit,
                    Volume = tripExpenseDto.Volume,
                    OriginalAmount = tripExpenseDto.OriginalAmount,
                    EquivalentInVND = tripExpenseDto.EquivalentInVND,
                    Notes = tripExpenseDto.Notes,
                };
                items.TripExpenseDetail.Add(expense);
            }

            await _TripInformationRepository.UpdateAsync(items);
            var create = new TripInformationDto
            {
                Id = items.Id,
                OperaterName = items.OperaterName,
                VerifierName = items.VerifierName,
                VerifierUsername = items.VerifierUsername,
                BusinessType = items.BusinessType,
                Notes = items.Notes,
                RequestedDate = items.RequestedDate,
                RequestNumber = items.RequestNumber,
                Department = departments.FirstOrDefault(d => d.Id == items.DepartmentID)?.Code,
                ExpenseCode = expenses.FirstOrDefault(d => d.Id == items.ExpenseCodeID)?.Code,
                LegalEntity = legals.FirstOrDefault(d => d.Id == items.LegalID)?.Code,
                TotalAmount = items.TotalAmount,
                TripExpenseDetail = item.Where(te => te.TripId == items.Id).Select(te => new TripExpenseDto
                {
                    Id = te.Id,
                    TripId = te.TripId,
                    Purpose = te.Purpose,
                    Destination = te.Destination,
                    CheckinTime = te.CheckinTime,
                    CheckoutTime = te.CheckoutTime,
                    TotalNights = te.TotalNights,
                    Item = te.Item,
                    Specification = te.Specification,
                    OriginalCurrency = te.OriginalCurrency,
                    OriginalUnit = te.OriginalUnit,
                    Volume = te.Volume,
                    OriginalAmount = te.OriginalAmount,
                    EquivalentInVND = te.EquivalentInVND,
                    Notes = te.Notes
                }).ToList()
            };

            return create;
        }
        public async Task<TripInformationDto> GetListIDAsync(Guid id)
        {
            var legal = await _legalRepository.GetListAsync();
            var ex = await _expenseCodeRepository.GetListAsync();
            var department = await _departmentRepository.GetListAsync();
            var items = await _TripInformationRepository.GetListAsync();
            var item = await _TripExRepository.GetListAsync();
            var list = items.Where(e => e.Id.Equals(id)).Select(e => new TripInformationDto
            {
                Id = e.Id,
                OperaterName = e.OperaterName,
                VerifierName = e.VerifierName,
                VerifierUsername = e.VerifierUsername,
                BusinessType = e.BusinessType,
                Notes = e.Notes,
                RequestedDate = e.RequestedDate,
                RequestNumber = e.RequestNumber,
                Department = department.FirstOrDefault(d => d.Id == e.DepartmentID)?.Code,
                ExpenseCode = ex.FirstOrDefault(b => b.Id == e.ExpenseCodeID)?.Code,
                LegalEntity = legal.FirstOrDefault(t => t.Id == e.LegalID)?.Code,
                TotalAmount = e.TotalAmount,
                TripExpenseDetail = item.Where(te => te.TripId == e.Id).Select(te => new TripExpenseDto
                {
                    Id = te.Id,
                    TripId = te.TripId,
                    Purpose = te.Purpose,
                    Destination = te.Destination,
                    CheckinTime = te.CheckinTime,
                    CheckoutTime = te.CheckoutTime,
                    TotalNights = te.TotalNights,
                    Item = te.Item,
                    Specification = te.Specification,
                    OriginalCurrency = te.OriginalCurrency,
                    OriginalUnit = te.OriginalUnit,
                    Volume = te.Volume,
                    OriginalAmount = te.OriginalAmount,
                    EquivalentInVND = te.EquivalentInVND,
                    Notes = te.Notes
                }).ToList()
            }).FirstOrDefault();
            return list;
        }
       
    }
   
}
