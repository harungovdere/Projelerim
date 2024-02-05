using Microsoft.AspNetCore.Http;

namespace FiloKiralama_Api.Dtos.CarImageDtos
{
    public class UpdateImageDto
    {
        public int ResimID { get; set; }
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public string DosyaAdi { get; set; }
        //public IFormFile Dosya { get; set; }

    }
}
