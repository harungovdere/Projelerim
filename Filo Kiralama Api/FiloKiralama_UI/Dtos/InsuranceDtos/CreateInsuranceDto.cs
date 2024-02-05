using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_UI.Dtos.InsuranceDtos
{
    public class CreateInsuranceDto
    {
        public int PoliceTuru { get; set; }
        public string Plaka { get; set; }
        public int BrutPrim { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
