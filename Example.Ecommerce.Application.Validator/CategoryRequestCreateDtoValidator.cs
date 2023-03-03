using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Transversal.Common.Struct;
using FluentValidation;

namespace Example.Ecommerce.Application.Validator
{
    public class CategoryRequestCreateDtoValidator : AbstractValidator<CategoryRequestCreateDto>
    {
        public CategoryRequestCreateDtoValidator() => ValidatorRules();

        private void ValidatorRules()
        {
            RuleFor(c => c).NotNull().NotEmpty();
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Description).NotNull().NotEmpty();
            RuleFor(c => c.Picture).NotNull().NotEmpty();
            RuleFor(c => c.PlanId).Must(pId => pId > 0)
                .When(c => c.PlanId is not null).WithMessage(FluentValidationMessage.VALUE_MUST_MAJOR_ZERO);
            RuleFor(c => c.StateId).NotNull().NotEmpty().IsInEnum();
        }
    }
}
