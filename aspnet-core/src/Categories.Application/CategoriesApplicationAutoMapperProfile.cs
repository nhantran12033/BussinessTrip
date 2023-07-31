using AutoMapper;
using Categories.Departments;
using Categories.ExpenseCodes;
using Categories.LegalEntitys;
using Categories.TripExpenses;
using Categories.Trips;
using System;
using Volo.Abp.Domain.Repositories;

namespace Categories;

public class CategoriesApplicationAutoMapperProfile : Profile
{
    public CategoriesApplicationAutoMapperProfile()
    {
        CreateMap<Trip, TripInformationDto>();
    }
}
