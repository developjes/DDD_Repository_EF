using AutoMapper;
using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Domain.DTO.Request.Category;
using Example.Ecommerce.Domain.DTO.Response.Category;
using Example.Ecommerce.Domain.DTO.Response.Message;
using Example.Ecommerce.Domain.Entity;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => MapperRules();

        private void MapperRules()
        {
            CreateMap<MessageResponseDomainDto, ResponseMessage>();
            CreateMap<MessageEntity, MessageResponseDomainDto>();

            CreateMap<CategoryRequestCreateDto, CategoryRequestCreateDomainDto>();
            CreateMap<CategoryRequestCreateDomainDto, CategoryEntity>();
            CreateMap<CategoryRequestUpdateDto, CategoryRequestUpdateDomainDto>();
            CreateMap<CategoryRequestUpdateDomainDto, CategoryEntity>();

            CreateMap<CategoryEntity, CategoryResponseDomainDto>();
            CreateMap<CategoryResponseDomainDto, CategoryResponseDto>();
        }
    }
}