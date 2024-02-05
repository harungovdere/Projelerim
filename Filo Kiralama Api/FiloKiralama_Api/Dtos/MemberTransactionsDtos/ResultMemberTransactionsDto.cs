using System;

namespace FiloKiralama_Api.Dtos.MemberTransactionsDtos
{
    public class ResultMemberTransactionsDto
    {
        public int RezerveID { get; set; }
        public int RandevuID { get; set; }
        public int AracID { get; set; }
        public DateTime AracRezerveTalepTarihi { get; set; }
        public DateTime RandevuTalepTarihi { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string RandevuSaati { get; set; }
        public string RandevuSahibi { get; set; }
        public int KullaniciID { get; set; }
        public string Kullanici { get; set; }
        public string Plaka { get; set; }
        public string MarkaAdi { get; set; }
        public string TipAdi { get; set; }
        public string TeslimAlmaKonumu { get; set; }
        public string TeslimEtmeKonumu { get; set; }
        public DateTime TeslimAlmaTarihi { get; set; }
        public DateTime TeslimEtmeTarihi { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
        public DateTime SatisTarihi { get; set; }
        public string Fiyat { get; set; }
        public int ModelYili { get; set; }
        public string TeslimAlmaSaati { get; set; }
        public string TeslimEtmeSaati { get; set; }
        public string GunlukKira { get; set; }
        public int ToplamGunSayisi { get; set; }
        public string ToplamTutar { get; set; }
        public string Durum { get; set; }

    }
}
