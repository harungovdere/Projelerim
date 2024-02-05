using System;

namespace FiloKiralama_Api.Dtos.CarStatusDtos
{
    public class ResultTransactionsDto
    {
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public string MarkaAdi { get; set; }
        public string TipAdi { get; set; }
        public int ModelYili { get; set; }
        public int KM { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
        public DateTime DonusTarihi { get; set; }
        public string Durum { get; set; }
        public int DurumID { get; set; }
        public int IslemTipleri { get; set; }

        public int ModelTipID { get; set; }
        public int TipKodu { get; set; }
        public string Renk { get; set; }
        public string Sanziman { get; set; }
        public string YakitTipi { get; set; }
        public string DosyaAdi { get; set; }
        public string Fiyat { get; set; }
        public string GunlukKiraFiyat { get; set; }
    }
}
