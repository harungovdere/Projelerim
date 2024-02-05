using FiloKiralama_UI.Dtos.RentalCarPricingDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class UpdateRentalCarPricingValidator:AbstractValidator<UpdateRentalCarPricingDto>
    {
        public UpdateRentalCarPricingValidator()
        {
            RuleFor(x => x.GunlukKiraFiyat).NotEmpty().WithMessage("Fiyat girilmedi");
            //RuleFor(x => x.GunlukKiraFiyat).Matches(@"((\d{4}).(\d{2}))$").WithMessage("Formata uygun değildir");
            RuleFor(x => x.GunlukKiraFiyat).Matches(@"[0-9]{2}\.[0-9]{3}\,[0-9]{2}$").When(x => x.GunlukKiraFiyat.Length > 8).WithMessage("Formata uygun değildir");
            RuleFor(x => x.GunlukKiraFiyat).Matches(@"[0-9]{1}\.[0-9]{3}\,[0-9]{2}$").When(x => x.GunlukKiraFiyat.Length == 8).WithMessage("Formata uygun değildir");
            RuleFor(x => x.GunlukKiraFiyat).Matches(@"[0-9]{3}\,[0-9]{2}$").When(x => x.GunlukKiraFiyat.Length <= 7).WithMessage("Formata uygun değildir");
        }
    }
}
