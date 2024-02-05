using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Dtos.ModelsDtos
{
    public class GetByIDModelDto
    {
        public int TipID { get; set; }
        
        public int TipKodu { get; set; }

        public string TipAdi { get; set; }
        public int MarkaKodu { get; set; }

        public string MarkaAdi { get; set; }

    }
}
