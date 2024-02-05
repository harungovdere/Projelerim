using FluentValidation;
using FiloKiralama_UI.Dtos.RentalCarReservedDtos;
using System;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateRentalCarReservedValidator:AbstractValidator<CreateRentalCarReservedDto>
    {
        public CreateRentalCarReservedValidator()
        {
           
            //RuleFor(x => x.Ad).NotEmpty().WithMessage("Alan boş geçilemez");
            //RuleFor(x => x.Soyad).NotEmpty().WithMessage("Alan boş geçilemez");
            //RuleFor(x => x.Email).NotEmpty().WithMessage("Alan boş geçilemez").EmailAddress().WithMessage("Mail adresi hatalı");
            //RuleFor(x => x.CepTel).NotEmpty().WithMessage("Alan boş geçilemez").Matches(@"((\d{3}) (\d{3}) (\d{4}))$").WithMessage("Formata uygun değildir");
            RuleFor(x => x.TeslimAlmaKonumu).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.TeslimEtmeKonumu).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.TeslimAlmaTarihi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.TeslimAlmaTarihi).Must(d => d.Year >= DateTime.Now.Year && d.Month >= DateTime.Now.Month && d.Day >= DateTime.Now.Day).WithMessage("Geçmiş tarih seçilemez");
            RuleFor(x => x.TeslimEtmeTarihi).NotEmpty().WithMessage("Alan boş geçilemez");
            //RuleFor(c => c.TeslimEtmeTarihi).Must(d => d.Year >= DateTime.Now.Year && d.Month >= DateTime.Now.Month && d.Day >= DateTime.Now.Day).WithMessage("Geçmiş tarih seçilemez");
            RuleFor(x => x.TeslimEtmeTarihi).GreaterThanOrEqualTo(x => x.TeslimAlmaTarihi).WithMessage("Teslim alma tarihinden küçük olamaz");
            RuleFor(x => x.TeslimAlmaSaati).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.TeslimEtmeSaati).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.GunlukKira).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.ToplamGunSayisi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.ToplamTutar).NotEmpty().WithMessage("Alan boş geçilemez");

            RuleFor(x => x.ToplamGunSayisi).LessThanOrEqualTo(365).WithMessage("365 günden fazla olamaz");

            RuleFor(x => x.TeslimEtmeSaati).GreaterThan(x => x.TeslimAlmaSaati).When(x => x.TeslimAlmaTarihi == x.TeslimEtmeTarihi).WithMessage("Teslim etme saati hatalı");
        }
    }
}
