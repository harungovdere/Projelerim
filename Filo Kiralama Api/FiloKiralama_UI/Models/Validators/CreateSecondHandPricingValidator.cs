using FiloKiralama_UI.Dtos.SecondHandPricingDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateSecondHandPricingValidator:AbstractValidator<CreateSecondHandPricingDto>
    {
        public CreateSecondHandPricingValidator()
        {
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat girilmedi");

        }
    }
}
