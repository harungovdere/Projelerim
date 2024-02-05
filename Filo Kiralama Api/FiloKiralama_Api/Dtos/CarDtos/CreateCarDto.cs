using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Dtos.CarDtos
{
    public class CreateCarDto
    {
        public string Plaka { get; set; }
        public int MarkaKodu { get; set; }
        public int TipKodu { get; set; }
        public int ModelYili { get; set; }
        public int KM { get; set; }
        public string Renk { get; set; }
        public string Sanziman { get; set; }
        public string YakitTipi { get; set; }
        public int Durum { get; set; }

    }
}
