using AutoMapper;
using TestMest.Models.Entitys;
using TestMest.Models.Views;

namespace TestMest.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarView>();

        CreateMap<IQueryable<Car>, IQueryable<CarView>>();
    }
    
    
}