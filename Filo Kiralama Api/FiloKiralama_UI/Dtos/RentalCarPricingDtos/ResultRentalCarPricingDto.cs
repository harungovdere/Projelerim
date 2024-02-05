namespace FiloKiralama_UI.Dtos.RentalCarPricingDtos
{
    public class ResultRentalCarPricingDto
    {
        public int MarkaKodu { get; set; }
        public string MarkaAdi { get; set; }
        public int ModelTipID { get; set; }
        public int TipKodu { get; set; }
        public string TipAdi { get; set; }
        public string Sanziman { get; set; }
        public string YakitTipi { get; set; }
        public string GunlukKiraFiyat { get; set; }
    }
}
