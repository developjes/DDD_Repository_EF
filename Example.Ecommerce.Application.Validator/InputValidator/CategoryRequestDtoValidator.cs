using Example.Ecommerce.Application.DTO.Request;
using FluentValidation;

namespace Example.Ecommerce.Application.Validator.InputValidator
{
    public class CategoryRequestDtoValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryRequestDtoValidator() => ValidatorRules();

        private void ValidatorRules()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Description).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(c => c.Picture).NotNull().NotEmpty();
        }
    }
}
