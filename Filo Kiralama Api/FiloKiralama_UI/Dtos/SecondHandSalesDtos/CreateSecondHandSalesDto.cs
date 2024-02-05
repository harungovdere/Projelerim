using System;

namespace FiloKiralama_UI.Dtos.SecondHandSalesDtos
{
    public class CreateSecondHandSalesDto
    {

        public int AracID { get; set; }
        public string Plaka { get; set; }
        public int KullaniciID { get; set; }
        public DateTime SatisTarihi { get; set; }
        public int Durum { get; set; }
    }
}
