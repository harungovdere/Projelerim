using FiloKiralama_UI.Dtos.InsuranceDtos;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace FiloKiralama_UI.Models.Validators
{
    public class UpdateInsuranceValidator:AbstractValidator<UpdateInsuranceDto>
    {
        public UpdateInsuranceValidator()
        {
            RuleFor(x => x.Plaka).NotNull().WithMessage("Plaka alanı boş geçilemez");
            RuleFor(x => x.Plaka).NotEmpty().WithMessage("Plaka alanı boş geçilemez");
            RuleFor(x => x.Plaka).MaximumLength(8).WithMessage("Plaka 8 karakterden fazla olamaz");
            RuleFor(x => x.Plaka).MinimumLength(8).WithMessage("Plaka 8 karakterden az olamaz");
            RuleFor(x => x.PoliceTuru).NotEmpty().NotNull().WithMessage("Poliçe seçiniz");
            RuleFor(x => x.BrutPrim).NotEmpty().WithMessage("Brüt Prim alanı boş geçilemez");
            RuleFor(x => x.BrutPrim).NotNull().WithMessage("Brüt Prim alanı boş geçilemez");
            RuleFor(x => x.BaslangicTarihi).NotNull().NotEmpty();
            RuleFor(x => x.BitisTarihi).NotNull().NotEmpty();
        }
    }
}
