using System;

namespace FiloKiralama_Api.Dtos.FleetRentalRequestDtos
{
    public class CreateFleetRentalRequestDto
    {
        public int FiloTalepID { get; set; }
        public DateTime FiloTalepTarihi { get; set; }
        public int MusteriID { get; set; }
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public int YillikKM { get; set; }
        public int KiralamaSuresi { get; set; }
        public int MevcutAracAdedi { get; set; }
        public int TalepEdilenAracAdedi { get; set; }
    }
}
