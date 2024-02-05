using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_UI.Dtos.CarDtos
{
    public class GetByIDCarDto
    {
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public int MarkaKodu { get; set; }
        public string MarkaAdi { get; set; }
        public int TipKodu { get; set; }

        public string TipAdi { get; set; }
        public int ModelYili { get; set; }
        public int KM { get; set; }
        public string Renk { get; set; }
        public string Sanziman { get; set; }
        public string YakitTipi { get; set; }
        public string Durum { get; set; }
        public int DurumID { get; set; }

    }
}
