using System;

namespace FiloKiralama_UI.Dtos.DailyRentalCarsDtos
{
    public class ResultDailyRentalCarsDto
    {
        public int ID { get; set; }
        public int AracID { get; set; }
        public int KullaniciID { get; set; }
        public int RezerveID { get; set; }
        public string Kullanici { get; set; }
        public string Plaka { get; set; }
        public string MarkaAdi { get; set; }
        public string TipAdi { get; set; }
        public string ToplamGunSayisi { get; set; }
        public string GunlukKira { get; set; }
        public string ToplamTutar { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
    }
}
