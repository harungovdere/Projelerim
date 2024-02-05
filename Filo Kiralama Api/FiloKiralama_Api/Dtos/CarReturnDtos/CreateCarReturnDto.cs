using System;

namespace FiloKiralama_Api.Dtos.CarReturnDtos
{
    public class CreateCarReturnDto
    {
        public int AracID { get; set; }
        public int KM { get; set; }
        public int Durum { get; set; }
        public DateTime DonusTarihi { get; set; }

    }
}
