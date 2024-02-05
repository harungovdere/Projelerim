

namespace FiloKiralama_UI.Dtos.CarDtos
{
    public class CreateCarDto
    {
       // [Required(ErrorMessage ="plaka giriniz..")]
        public string Plaka { get; set; }
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public string ModelYili { get; set; }
        public int KM { get; set; }
        public string Renk { get; set; }
        public string Sanziman { get; set; }
        public string YakitTipi { get; set; }
        public int Durum { get; set; }
    }
}
