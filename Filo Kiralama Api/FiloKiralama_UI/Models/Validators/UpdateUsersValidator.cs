using FiloKiralama_UI.Dtos.UsersDtos;
using FluentValidation;

namespace FiloKiralama_UI.Models.Validators
{
    public class UpdateUsersValidator:AbstractValidator<UpdateUsersDto>
    {
        public UpdateUsersValidator()
        {
            //RuleFor(x => x.TC).MaximumLength(11).WithMessage("Kimlik no 11 karakterden fazla olamaz");
            //RuleFor(x => x.TC).MinimumLength(11).WithMessage("Kimlik no 11 karakterden az olamaz");
            //RuleFor(x => x.TC).Length(11, 11).WithMessage("Kimlik no hatalı");
            RuleFor(x => x.TC).Matches(@"[0-9]{11}$").WithMessage("Kimlik no 11 hane olmalıdır");
            RuleFor(x => x.TC).NotEmpty().WithMessage("Kimlik no giriniz"); 
            RuleFor(x => x.TC).NotNull();
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Adınızı giriniz");
            RuleFor(x => x.Ad).NotNull();
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyadınızı giriniz");
            RuleFor(x => x.Soyad).NotNull();
            RuleFor(x => x.DogumTarihi).NotEmpty().WithMessage("Doğum tarihinizi giriniz");
            RuleFor(x => x.DogumTarihi).NotNull().WithMessage("Doğum tarihinizi giriniz");
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage("Cinsiyet seçiniz");
            RuleFor(x => x.Cinsiyet).NotNull();
            RuleFor(x => x.EhliyetNo).NotEmpty().WithMessage("Ehliyet numaranızı giriniz");
            RuleFor(x => x.EhliyetNo).NotNull();
            //RuleFor(x => x.EhliyetNo).MaximumLength(6).MinimumLength(6).WithMessage("Ehliyet no 6 hane olmalıdır");
            RuleFor(x => x.EhliyetNo).Matches(@"[0-9]{6}$").WithMessage("Ehliyet no 6 hane olmalıdır");
            RuleFor(x => x.EhliyetSinifi).NotEmpty().WithMessage("Ehliyet sınıfınızı seçiniz");
            RuleFor(x => x.EhliyetSinifi).NotNull();
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresinizi giriniz");
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli mail adresi giriniz");
            //RuleFor(x => x.CepTel).Matches(@"((\d{3}) (\d{3})-(\d{4}))$").WithMessage("Formata uygun değildir");
            RuleFor(x => x.CepTel).NotEmpty().WithMessage("Alan boş geçilemez").Matches(@"\([0-9]{3}\) [0-9]{3}-[0-9]{4}$").WithMessage("Formata uygun değildir");
            //RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre tanımlayınız");
            //RuleFor(x => x.Sifre).NotNull();
            //RuleFor(x => x.Sifre2).Equal(x => x.Sifre).When(x => x.Sifre != "").WithMessage("Girilen şifreler uyumsuz");

        }
    }
}
