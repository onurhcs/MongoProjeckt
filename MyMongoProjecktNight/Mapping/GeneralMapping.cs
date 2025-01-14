using AutoMapper;
using MyMongoProjecktNight.Dtos.CustomerDtos;
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
        }
    }
}
