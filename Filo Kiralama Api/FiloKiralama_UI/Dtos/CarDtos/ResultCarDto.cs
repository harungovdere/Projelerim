using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_UI.Dtos.CarDtos
{
    public class ResultCarDto
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
        public int DurumID { get; set; }
        public string Durum { get; set; }
        public string DosyaAdi { get; set; }
        public string Fiyat { get; set; }
        public string GunlukKiraFiyat { get; set; }
    }
}
