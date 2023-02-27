using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Domain.Entity;
using System.Text;

namespace Example.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => MapperRules();

        private void MapperRules()
        {
            CreateMap<CategoryEntity, CategoryResponseDto>();
            CreateMap<CategoryRequestDto, CategoryEntity>();
        }
    }
}
