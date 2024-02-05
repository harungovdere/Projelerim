using FiloKiralama_UI.Dtos.CarDtos;
using FiloKiralama_UI.Dtos.CarStatusDtos;
using FiloKiralama_UI.Dtos.FleetOfferDtos;
using FiloKiralama_UI.Dtos.FleetRentalDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using static FSharp.Compiler.Syntax.SynSimplePat;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FleetRentalController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FleetRentalController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/FleetRental");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFleetRentalDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.FirmaUnvani.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFleetRental(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44365/api/FleetOffer/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultFleetOfferDto>(jsonData);

            ViewBag.teklifID = value.TeklifID;
            ViewBag.teklifTarih = value.TeklifTarihi;
            ViewBag.firma = value.FirmaUnvani;
            ViewBag.marka = value.MarkaAdi;
            ViewBag.model = value.TipAdi;
            ViewBag.km = value.YillikKM;
            ViewBag.sure = value.KiralamaSuresi;
            ViewBag.aylikKira = value.AylikKiraFiyati;
            ViewBag.yillikKira = value.YillikKiraFiyati;
            ViewBag.kiralanacakAracAdedi = value.TalepEdilenAracAdedi;

            var markaKodu = value.MarkaKodu;
            var tipKodu = value.TipKodu;

            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Car/");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData2);

            List<SelectListItem> plakalar = (from x in value2.ToList()
                                             where x.DurumID == 6
                                             where x.MarkaKodu == markaKodu
                                             where x.TipKodu == tipKodu
                                             select new SelectListItem
                                             {
                                                 Text = x.Plaka,
                                                 Value = x.AracID.ToString()
                                             }).ToList();
            ViewBag.plakalar = plakalar;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateFleetRental(CreateFleetRentalDto createFleetRentalDto, UpdateStatusDto updateStatusDto)
        {
            var tarih = DateTime.Now.Date;
            var client = _httpClientFactory.CreateClient();
            
            if (ModelState.IsValid)
            {
                foreach (var item in createFleetRentalDto.Plaka)
                {
                    createFleetRentalDto.AracID = Convert.ToInt16(item);
                    var jsonData = JsonConvert.SerializeObject(createFleetRentalDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:44365/api/FleetRental/", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        //Aracın statüsü Filo Kirada olarak güncelleniyor
                        updateStatusDto.AracID = Convert.ToInt16(item);
                        updateStatusDto.Durum = createFleetRentalDto.Durum;
                        var jsonData4 = JsonConvert.SerializeObject(updateStatusDto);
                        StringContent stringContent4 = new StringContent(jsonData4, Encoding.UTF8, "application/json");
                        var responseMessage4 = await client.PutAsync("https://localhost:44365/api/CarStatus/", stringContent4);
                    }

                }
                return RedirectToAction("Index", "FleetOffer");

            }
            else
            {
                var responseMessage2 = await client.GetAsync($"https://localhost:44365/api/FleetOffer/{createFleetRentalDto.TeklifID}");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultFleetOfferDto>(jsonData2);

                ViewBag.teklifID = value2.TeklifID;
                ViewBag.teklifTarih = value2.TeklifTarihi;
                ViewBag.firma = value2.FirmaUnvani;
                ViewBag.marka = value2.MarkaAdi;
                ViewBag.model = value2.TipAdi;
                ViewBag.km = value2.YillikKM;
                ViewBag.sure = value2.KiralamaSuresi;
                ViewBag.aylikKira = value2.AylikKiraFiyati;
                ViewBag.yillikKira = value2.YillikKiraFiyati;
                ViewBag.kiralanacakAracAdedi = value2.TalepEdilenAracAdedi;

                var markaKodu = value2.MarkaKodu;
                var tipKodu = value2.TipKodu;

                var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Car/");
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var value3 = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData3);

                List<SelectListItem> plakalar = (from x in value3.ToList()
                                                 where x.DurumID == 6
                                                 where x.MarkaKodu == markaKodu
                                                 where x.TipKodu == tipKodu
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Plaka,
                                                     Value = x.AracID.ToString()
                                                 }).ToList();
                ViewBag.plakalar = plakalar;
                return View();
            }
            

        }
    }
}
