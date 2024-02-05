using FiloKiralama_UI.Dtos.FleetRentalRequestDtos;
using FluentValidation;
using FluentValidation.Validators;
using System.Linq.Expressions;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateFleetRentalRequestValidator : AbstractValidator<CreateFleetRentalRequestDto>
    {
        public CreateFleetRentalRequestValidator()
        {

            RuleFor(x => x.MusteriTipi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.FirmaUnvani).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.VergiDairesi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.VergiNoKimlikNo).NotEmpty().WithMessage("Alan boş geçilemez");

            //RuleFor(x => x.VergiNoKimlikNo).Length(11, 11).WithMessage("Kimlik no 11 haneli olmalı");
            //RuleFor(x => x.VergiNoKimlikNo).Length(11, 11).When(x => x.MusteriTipi == "Şahıs Şirketi").WithMessage("Kimlik no 11 haneli olmalı");
            //RuleFor(x => x.VergiNoKimlikNo).Length(6, 6).When(x => x.MusteriTipi == "Ticari Şirket").WithMessage("Vergi no 6 hane olmalı");
            RuleFor(x => x.VergiNoKimlikNo).Matches(@"[0-9]{11}$").When(x => x.MusteriTipi == "Şahıs Şirketi").WithMessage("Kimlik no 11 haneli olmalı");
            RuleFor(x => x.VergiNoKimlikNo).Matches(@"[0-9]{6}$").When(x => x.MusteriTipi == "Ticari Şirket").WithMessage("Vergi no 6 hane olmalı");

            //RuleFor(x => x.VergiNoKimlikNo).Must((x,t) =>
            //{
            //    if (x.MusteriTipi == "1" && ((x.VergiNoKimlikNo.Length) < 11 || (x.VergiNoKimlikNo.Length) > 11))
            //    {
            //        return true;
            //    }
            //    else return false;
            // }).WithMessage("11 Olmali");

            RuleFor(x => x.EPosta).NotEmpty().WithMessage("Alan boş geçilemez").EmailAddress().WithMessage("Mail adresi hatalı");
            //RuleFor(x => x.Telefon).NotEmpty().WithMessage("Alan boş geçilemez").Matches(@"((\d{3}) (\d{3})-(\d{4}))$").WithMessage("Formata uygun değildir");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Alan boş geçilemez").Matches(@"\([0-9]{3}\) [0-9]{3}-[0-9]{4}$").WithMessage("Formata uygun değildir");
            //RuleFor(x => x.Telefon).Length(14, 14).WithMessage("Hatalı giriş yaptınız");

            RuleFor(x => x.MarkaKodu).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.TipKodu).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.KiralamaSuresi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.YillikKM).NotEmpty().WithMessage("Alan boş geçilemez");
            //RuleFor(x => x.MevcutAracAdedi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.TalepEdilenAracAdedi).NotEmpty().WithMessage("Alan boş yada girilmedi");

            RuleFor(x => x.MevcutAracAdedi).GreaterThanOrEqualTo(0).WithMessage("Geçerli rakam giriniz");
            RuleFor(x => x.TalepEdilenAracAdedi).GreaterThan(0).WithMessage("Geçerli rakam giriniz");

        }
    }
}
