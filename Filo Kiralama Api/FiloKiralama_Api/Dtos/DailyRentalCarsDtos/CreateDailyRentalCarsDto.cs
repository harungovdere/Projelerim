using System;

namespace FiloKiralama_Api.Dtos.DailyRentalCarsDtos
{
    public class CreateDailyRentalCarsDto
    {
        public int AracID { get; set; }
        public int KullaniciID { get; set; }
        public int RezerveID { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
    }
}
