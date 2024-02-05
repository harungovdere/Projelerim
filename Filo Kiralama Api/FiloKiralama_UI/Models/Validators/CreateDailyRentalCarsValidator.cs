using FiloKiralama_UI.Dtos.DailyRentalCarsDtos;
using FluentValidation;
namespace FiloKiralama_UI.Models.Validators
{
    public class CreateDailyRentalCarsValidator:AbstractValidator<CreateDailyRentalCarsDto>
    {
        public CreateDailyRentalCarsValidator()
        {
            RuleFor(x => x.Plaka).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.RezerveID).NotEmpty().WithMessage("Alan boş geçilemez");
            RuleFor(x => x.KullaniciID).NotEmpty().WithMessage("Alan boş geçilemez");

        }
    }
}
