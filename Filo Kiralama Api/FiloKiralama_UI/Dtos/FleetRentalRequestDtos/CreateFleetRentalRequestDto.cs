using System;

namespace FiloKiralama_UI.Dtos.FleetRentalRequestDtos
{
    public class CreateFleetRentalRequestDto
    {
        public int FiloTalepID { get; set; }
        public DateTime FiloTalepTarihi { get; set; }
        public int MusteriID { get; set; }
        public string MusteriTipi { get; set; }
        public string FirmaUnvani { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNoKimlikNo { get; set; }
        public string EPosta { get; set; }
        public string Telefon { get; set; }
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public int YillikKM { get; set; }
        public int KiralamaSuresi { get; set; }
        public int MevcutAracAdedi { get; set; }
        public int TalepEdilenAracAdedi { get; set; }
        
    }
}
