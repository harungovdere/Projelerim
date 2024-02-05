using FiloKiralama_UI.Dtos.FleetRentalDtos;
using FluentValidation;
using System;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateFleetRentalValidator:AbstractValidator<CreateFleetRentalDto>
    {
        public CreateFleetRentalValidator()
        {
            RuleFor(x => x.Plaka).NotEmpty().WithMessage("Seçim yapınız");
            RuleFor(x => x.KiraBaslangicTarihi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.KiraBitisTarihi).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.Plaka.Count).Equal(x=>x.KiralanacakAracAdedi).WithMessage("Eksik yada fazla seçim yaptınız");
            RuleFor(x => x.KiraBaslangicTarihi).GreaterThanOrEqualTo(x => x.TeklifTarihi).WithMessage("Teklif tarihinden küçük olamaz");
            RuleFor(x => x.KiraBaslangicTarihi).Must(d => d.Date <= DateTime.Now.Date).WithMessage("Gelecek tarihe işlem yapılamaz");
        }
    }
}
