using System;

namespace FiloKiralama_Api.Dtos.FleetRentalDtos
{
    public class ResultFleetRentalDto
    {
        public int FiloID { get; set; }
        public DateTime FiloEklemeTarihi { get; set; }
        public int TeklifID { get; set; }
        public int MusteriID { get; set; }
        public string FirmaUnvani { get; set; }
        public int AracID { get; set; }
        public string MarkaAdi { get; set; }
        public string TipAdi { get; set; }
        public string Plaka { get; set; }
        public int KiralamaSuresi { get; set; }
        public int YillikKM { get; set; }
        public int ToplamAracAdedi { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
    }
}
