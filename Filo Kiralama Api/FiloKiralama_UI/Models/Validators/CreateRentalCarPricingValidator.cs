using FiloKiralama_UI.Dtos.RentalCarPricingDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateRentalCarPricingValidator:AbstractValidator<CreateRentalCarPricingDto>
    {
        public CreateRentalCarPricingValidator()
        {
            RuleFor(x => x.GunlukKiraFiyat).NotEmpty().WithMessage("Fiyat girilmedi");
            //RuleFor(x => x.GunlukKiraFiyat).NotEmpty().WithMessage("Alan boş geçilemez").Matches(@"((\d{1}).(\d{3}) (\d{4}))$").WithMessage("Formata uygun değildir");
        }
    }
}
