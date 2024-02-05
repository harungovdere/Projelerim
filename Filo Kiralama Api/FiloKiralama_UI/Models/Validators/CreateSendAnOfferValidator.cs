using FiloKiralama_UI.Dtos.FleetOfferDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateSendAnOfferValidator:AbstractValidator<CreateSendAnOfferDto>
    {
        public CreateSendAnOfferValidator()
        {
            RuleFor(x => x.FiloTalepID).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.AylikKiraFiyati).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.YillikKiraFiyati).NotEmpty().WithMessage("Alan boş geçilemez");
        }
    }
}
