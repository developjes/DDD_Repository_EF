using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Domain.DTO.Request;
using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => MapperRules();

        private void MapperRules()
        {
            CreateMap<CategoryRequestCreateDto, CategoryRequestCreateDomainDto>();
            CreateMap<CategoryRequestCreateDomainDto, CategoryEntity>();

            CreateMap<CategoryRequestUpdateDto, CategoryRequestUpdateDomainDto>();
            CreateMap<CategoryRequestUpdateDomainDto, CategoryEntity>();
        }
    }
}