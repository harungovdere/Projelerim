using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Dtos.InsuranceDtos
{
    public class ResultInsuranceDto
    {
        public int PoliceID { get; set; }
        public string PoliceTuruAdi { get; set; }
        public int PoliceTuru { get; set; }
        public string Plaka { get; set; }
        public int  BrutPrim { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

    }
}
