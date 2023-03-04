﻿using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface
{
    public interface ICategoryApplication
    {
        Task<Response<int?>> Create(CategoryRequestCreateDto categoryDto);
        Task<Response<bool>> Edit(int categoryId, CategoryRequestUpdateDto categoryDto);
    }
}
