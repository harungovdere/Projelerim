using System;

namespace FiloKiralama_UI.Dtos.SoldCarsDtos
{
    public class ResultSoldCarsDto
    {
        public int SatisID { get; set; }
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public string MarkaAdi { get; set; }
        public string TipAdi { get; set; }
        public int ModelYili { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Durum { get; set; }
        public string Fiyat { get; set; }
        public DateTime SatisTarihi { get; set; }
    }
}
