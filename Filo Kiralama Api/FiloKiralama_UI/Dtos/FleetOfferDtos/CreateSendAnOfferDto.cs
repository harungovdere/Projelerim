namespace FiloKiralama_UI.Dtos.FleetOfferDtos
{
    public class CreateSendAnOfferDto
    {
        public int FiloTalepID { get; set; }
        public string TalepTarihi { get; set; }
        public string FirmaUnvani { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string YillikKM { get; set; }
        public string KiralamaSuresi { get; set; }
        public string Email { get; set; }
        public string MevcutArac { get; set; }
        public string TalepArac { get; set; }
        public string AylikKiraFiyati { get; set; }
        public string YillikKiraFiyati { get; set; }
    }
}
