using System;

namespace FiloKiralama_UI.Dtos.FleetOfferDtos
{
    public class ResultFleetOfferDto
    {
        public int TeklifID { get; set; }
        public DateTime TeklifTarihi { get; set; }
        public DateTime FiloTalepTarihi { get; set; }
        public int TalepID { get; set; }
        public string FirmaUnvani { get; set; }
        public string AylikKiraFiyati { get; set; }
        public string YillikKiraFiyati { get; set; }
        public int KiralamaSuresi { get; set; }
        public int YillikKM { get; set; }
        public int MusteriID { get; set; }
        public string MarkaAdi { get; set; }
        public string TipAdi { get; set; }
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public int TalepEdilenAracAdedi { get; set; }
        public int MevcutAracAdedi { get; set; }

    }
}
