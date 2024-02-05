using FiloKiralama_UI.Dtos.SecondHandPricingDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class UpdateSecondHandPricingValidator : AbstractValidator<UpdateSecondHandPricingDto>
    {
        public UpdateSecondHandPricingValidator()
        {
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat girilmedi");
            RuleFor(x => x.Fiyat).NotNull().WithMessage("Fiyat girilmedi");
            RuleFor(x => x.Fiyat).Matches(@"[0-9]{1}\.[0-9]{3}\.[0-9]{3}$").When(x => x.Fiyat.Length > 7).WithMessage("Formata uygun değildir");
            RuleFor(x => x.Fiyat).Matches(@"[0-9]{3}\.[0-9]{3}$").When(x => x.Fiyat.Length <= 7).WithMessage("Formata uygun değildir");

            //RuleFor(x => x.Fiyat).Must((x, t) =>
            //{
            //    if (x.Fiyat != null)
            //    {
            //        return true;
            //    }
            //    else return false;
            //}).Matches(@"[0-9]{1}\.[0-9]{3}\.[0-9]{3}$").WithMessage("Formata uygun değildir");

            //RuleFor(x => x.Fiyat).Must((x, t) =>
            //{
            //    if (x.Fiyat != null)
            //    {
            //        return true;
            //    }
            //    else return false;
            //}).Matches(@"[0-9]{3}\.[0-9]{3}$").WithMessage("Formata uygun değildir");

        }
    }
}
