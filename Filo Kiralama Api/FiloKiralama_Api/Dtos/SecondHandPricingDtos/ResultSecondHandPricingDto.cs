using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Dtos.SecondHandPricingDtos
{
    public class ResultSecondHandPricingDto
    {
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public int MarkaKodu { get; set; }

        public string MarkaAdi { get; set; }
        public int ModelTipID { get; set; }
        public int TipKodu { get; set; }

        public string TipAdi { get; set; }
        public int ModelYili { get; set; }
        public int KM { get; set; }
        public string Renk { get; set; }
        public string Sanziman { get; set; }
        public string YakitTipi { get; set; }
        public string Durum { get; set; }
        public string Fiyat { get; set; }

    }
}
