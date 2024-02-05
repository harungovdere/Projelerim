using FluentValidation;
using FiloKiralama_UI.Dtos.SecondHandAppointmentDtos;
using System;


namespace FiloKiralama_UI.Models.Validators
{
    public class UpdateSecondHandAppointmentValidator : AbstractValidator<UpdateSecondHandAppointmentDto>
    {
        public UpdateSecondHandAppointmentValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Alan boş geçilemez").EmailAddress().WithMessage("Mail adresi hatalı");
            RuleFor(x => x.CepTel).NotEmpty().WithMessage("Alan boş geçilemez").Matches(@"((\d{3}) (\d{3}) (\d{4}))$").WithMessage("Formata uygun değildir");
            //RuleFor(x => x.CepTel).Matches(@"(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$").WithMessage("Formata uygun değildir");
            RuleFor(x => x.RandevuTarihi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.RandevuSaati).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(c => c.RandevuTarihi).Must(d => d.Year >= DateTime.Now.Year && d.Month >= DateTime.Now.Month && d.Day>=DateTime.Now.Day).WithMessage("Geçmiş tarih seçilemez");
           
            RuleFor(c => c.RandevuSaati).GreaterThan(DateTime.Now.Hour.ToString()).When(x => x.RandevuTarihi==DateTime.Now.Date).WithMessage("Geçmiş saat seçilemez");
            
            //RuleFor(c => c.RandevuSaati).GreaterThan(DateTime.Now.Minute.ToString()).When(x => x.RandevuTarihi == DateTime.Now.Date).WithMessage("Geçmiş dakika seçilemez");
            //RuleFor(c => c.RandevuTarihi).Must(d => d.Year >= DateTime.Now.Year).WithMessage("Geçmiş yıl tarih seçilemez");
            //RuleFor(c => c.RandevuTarihi).Must(d => d.Month >= DateTime.Now.Month).WithMessage("Geçmiş ay tarih seçilemez");
            //RuleFor(c => c.RandevuTarihi).Must(d => d.Day >= DateTime.Now.Day).WithMessage("Geçmiş gün tarih seçilemez");

            //RuleFor(x=> x.RandevuTarihi).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Geçmiş tarih seçilemez");
            //RuleFor(c => c.Soyad).NotEmpty().When(c => c.Id != 1).WithMessage("Lütfen soyadı boş geçmeyiniz.");

            //RuleFor(x => x.RandevuTarihi)
            //    .Must((x, context) =>
            //    {
            //        var gunLimit = DateTime.Now.Day;
            //        var ayLimit = DateTime.Now.Month;
            //        var yilLimit = DateTime.Now.Year;

            //        if (x.RandevuTarihi.Day < gunLimit && x.RandevuTarihi.Month < ayLimit && x.RandevuTarihi.Year < yilLimit)
            //            return false;
            //        return true;
            //    }).WithMessage("Geçmiş tarih seçilemez");
        }
    }
}
