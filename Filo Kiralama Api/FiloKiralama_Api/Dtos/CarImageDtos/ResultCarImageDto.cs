using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Dtos.CarImageDtos{
    public class ResultCarImageDto
    {
        public int ResimID { get; set; }
        public int MarkaKodu { get; set; }
        public string MarkaAdi { get; set; }
        public int TipKodu { get; set; }
        public string TipAdi { get; set; }
        public string DosyaAdi { get; set; }
    }
}
