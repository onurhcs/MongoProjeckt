using AutoMapper;
using MyMongoProjecktNight.Dtos.CustomerDtos;
using MyMongoProjecktNight.Dtos.DepartmentDtos;
using MyMongoProjecktNight.Entities;

namespace MyMongoProjecktNight.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();

            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Department, ResultDepartmentDto>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentDto>().ReverseMap();


        }
    }
}
