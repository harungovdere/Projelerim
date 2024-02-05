using FiloKiralama_UI.Dtos.SecondHandSalesDtos;
using FluentValidation;
using System;

namespace FiloKiralama_UI.Models.Validators
{
    public class CreateSecondHandSalesValidator:AbstractValidator<CreateSecondHandSalesDto>
    {
        public CreateSecondHandSalesValidator()
        {
            RuleFor(x => x.AracID).NotEmpty().WithMessage("AracID bilgisi alınamadı");
            RuleFor(x => x.KullaniciID).NotEmpty().WithMessage("Üye seçiniz");

            RuleFor(x => x.SatisTarihi).NotEmpty().WithMessage("Satış tarihi giriniz");
            RuleFor(x => x.SatisTarihi).Must(d => d.Year <= DateTime.Now.Year && d.Month <= DateTime.Now.Month && d.Day <= DateTime.Now.Day).WithMessage("İleri tarih seçilemez");

        }
    }
}
