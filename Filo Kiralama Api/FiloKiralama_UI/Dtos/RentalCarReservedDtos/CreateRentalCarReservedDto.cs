﻿using System;

namespace FiloKiralama_UI.Dtos.RentalCarReservedDtos
{
    public class CreateRentalCarReservedDto
    {
        public int RezerveID { get; set; }
        public int KullaniciID { get; set; }
        public DateTime AracRezerveTalepTarihi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string CepTel { get; set; }
        public int TipID { get; set; }
        public int AracID { get; set; }
        public string Plaka { get; set; }
        public string TeslimAlmaKonumu { get; set; }
        public string TeslimEtmeKonumu { get; set; }
        public DateTime TeslimAlmaTarihi { get; set; }
        public string TeslimAlmaSaati { get; set; }
        public DateTime TeslimEtmeTarihi { get; set; }

        public string TeslimEtmeSaati { get; set; }
        public string GunlukKira { get; set; }
        public int ToplamGunSayisi { get; set; }
        public string ToplamTutar { get; set; }


    }
}
