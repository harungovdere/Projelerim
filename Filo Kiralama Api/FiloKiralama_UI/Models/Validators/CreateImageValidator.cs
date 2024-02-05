using FiloKiralama_UI.Dtos.CarImageDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateImageValidator:AbstractValidator<CreateImageDto>
    {
        public CreateImageValidator()
        {
            RuleFor(x => x.MarkaKodu).NotEmpty().WithMessage("Marka alanı boş geçilemez");
            RuleFor(x => x.MarkaKodu).NotNull();
            RuleFor(x => x.TipKodu).NotEmpty().WithMessage("Model alanı boş geçilemez"); ;
            RuleFor(x => x.TipKodu).NotNull();
            RuleFor(x => x.Dosya).NotEmpty().WithMessage("Dosya alanı boş geçilemez"); ;
            RuleFor(x => x.Dosya).NotNull();

        }
    }
}
