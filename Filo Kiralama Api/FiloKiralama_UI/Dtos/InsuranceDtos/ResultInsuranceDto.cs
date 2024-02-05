using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_UI.Dtos.InsuranceDtos
{
    public class ResultInsuranceDto
    {
        public int PoliceID { get; set; }
        public string PoliceTuruAdi { get; set; }

        public int PoliceTuru { get; set; }
        public string Plaka { get; set; }
        public int  BrutPrim { get; set; }

        //[DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime BaslangicTarihi { get; set; }
        //[DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime BitisTarihi { get; set; }

    }
}
