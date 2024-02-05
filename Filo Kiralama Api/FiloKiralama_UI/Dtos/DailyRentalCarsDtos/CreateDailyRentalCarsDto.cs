using System;

namespace FiloKiralama_UI.Dtos.DailyRentalCarsDtos
{
    public class CreateDailyRentalCarsDto
    {
        public string Plaka { get; set; }
        public int AracID { get; set; }
        public int KullaniciID { get; set; }
        public int RezerveID { get; set; }
        public int Durum { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
    }
}
