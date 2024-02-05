using FiloKiralama_UI.Dtos.CarDtos;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace FiloKiralama_UI.Models.Validators
{
    public class UpdateCarValidator:AbstractValidator<UpdateCarDto>
    {
        public UpdateCarValidator()
        {
            RuleFor(x => x.Plaka).NotNull().WithMessage("Plaka alanı boş geçilemez");
            RuleFor(x => x.Plaka).NotEmpty().WithMessage("Plaka alanı boş geçilemez");
            RuleFor(x => x.Plaka).MaximumLength(8).WithMessage("Plaka 8 karakterden fazla olamaz");
            RuleFor(x => x.Plaka).MinimumLength(8).WithMessage("Plaka 8 karakterden az olamaz");
            RuleFor(x => x.MarkaKodu).NotEmpty().WithMessage("Marka alanı boş geçilemez");
            RuleFor(x => x.TipKodu).NotEmpty();
            RuleFor(x => x.ModelYili).NotNull();
            RuleFor(x => x.ModelYili).NotEmpty();
            RuleFor(x => x.KM).NotNull().NotEmpty().WithMessage("KM alanı boş geçilemez");
            RuleFor(x => x.Renk).NotEmpty().WithMessage("Renk alanı boş geçilemez");
            RuleFor(x => x.Plaka).NotEmpty().WithMessage("Plaka alanı boş geçilemez");
            RuleFor(x => x.Sanziman).NotEmpty().WithMessage("Şanzıman alanı boş geçilemez");
            RuleFor(x => x.YakitTipi).NotEmpty().WithMessage("Yakıt Tipi alanı boş geçilemez");
            RuleFor(x => x.Durum).NotEmpty().WithMessage("Durum alanı boş geçilemez");

        }
    }
}
