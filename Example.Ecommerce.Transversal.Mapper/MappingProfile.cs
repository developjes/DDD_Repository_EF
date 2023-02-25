using AutoMapper;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => MapperRules();

        private void MapperRules()
        {
            CreateMap<CategoryEntity, CategoryResponseDto>().ReverseMap();
        }
    }
}
