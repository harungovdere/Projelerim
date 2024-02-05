using System;
using System.ComponentModel.DataAnnotations;

namespace FiloKiralama_Api.Dtos.UsersDtos
{
    public class GetByIDUsersDto
    {
        public int KullaniciID { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string EhliyetNo { get; set; }
        public string EhliyetSinifi { get; set; }
        public string Email { get; set; }
        public string CepTel { get; set; }
        public string Sifre { get; set; }
        public string Role { get; set; }

    }
}
