using FiloKiralama_Api.Models.DapperContext;
using Microsoft.AspNetCore.Http;

namespace FiloKiralama_Api.Dtos.CarImageDtos
{
    public class CreateImageDto
    {
        
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public string DosyaAdi { get; set; }
        //public IFormFile Dosya { get; set; }

    }
}
