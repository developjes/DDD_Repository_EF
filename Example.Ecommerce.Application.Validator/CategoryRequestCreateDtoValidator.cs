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
            RuleFor(c => c).Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty();
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty();
            RuleFor(c => c.Description).Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty();
            RuleFor(c => c.Picture).Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty();
            RuleFor(c => c.PlanId).Cascade(CascadeMode.Stop)
                .Must(pId => pId > 0)
                .When(c => c.PlanId is not null)
                .WithMessage(FluentValidationMessage.VALUE_MUST_MAJOR_ZERO);
            RuleFor(c => c.StateId).Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty().IsInEnum();
        }
    }
}
