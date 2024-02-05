using System;

namespace FiloKiralama_UI.Dtos.SecondHandAppointmentDtos
{
    public class ResultSecondAppointmentHandDto
    {
        public int RandevuID { get; set; }
        public int KullaniciID { get; set; }
        public DateTime RandevuTalepTarihi { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string CepTel { get; set; }
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string RandevuSaati { get; set; }
        public string Durum { get; set; }

    }
}
