using System;

namespace FiloKiralama_Api.Dtos.FleetRentalDtos
{
    public class CreateFleetRentalDto
    {
        public int TeklifID { get; set; }
        public int MusteriID { get; set; }
        public int AracID { get; set; }
        public int KiralamaSuresi { get; set; }
        public int YillikKM { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }

    }
}
