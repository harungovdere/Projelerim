using System;

namespace FiloKiralama_Api.Dtos.SecondHandSalesDtos
{
    public class CreateSecondHandSalesDto
    {
        public int AracID { get; set; }
        public int KullaniciID { get; set; }
        public DateTime SatisTarihi { get; set; }

    }
}
