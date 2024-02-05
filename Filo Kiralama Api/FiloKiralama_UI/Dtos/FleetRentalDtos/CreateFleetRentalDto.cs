using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FiloKiralama_UI.Dtos.FleetRentalDtos
{
    public class CreateFleetRentalDto
    {
        public int TeklifID { get; set; }
        public DateTime TeklifTarihi { get; set; }
        public List<string> Plaka { get; set; }
        public int AracID { get; set; }
        public int KiralanacakAracAdedi { get; set; }
        public DateTime KiraBaslangicTarihi { get; set; }
        public DateTime KiraBitisTarihi { get; set; }
        public int Durum { get; set; }

    }
}
