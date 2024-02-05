using FiloKiralama_UI.Dtos.RentalCarReservedDtos;
using FiloKiralama_UI.Dtos.DailyRentalCarsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FiloKiralama_UI.Dtos.CarDtos;
using System.Linq;
using System;
using X.PagedList;
using FiloKiralama_UI.Dtos.CarStatusDtos;


namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DailyRentalCarsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DailyRentalCarsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/DailyRentalCars");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultDailyRentalCarsDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Kullanici.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }

        public async Task<IActionResult> CreateDailyRentalCar(int id)
        {
            var modelTipID = 0;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/RentalCarReserved/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultRentalCarReservedDto>(jsonData);

            ViewBag.kullaniciID = value.KullaniciID;
            ViewBag.rezerveID = value.RezerveID;
            ViewBag.rezerveTarih = value.AracRezerveTalepTarihi;
            ViewBag.ad = value.Ad;
            ViewBag.soyad = value.Soyad;
            ViewBag.mail = value.Email;
            ViewBag.tel = value.CepTel;
            ViewBag.tAlma = value.TeslimAlmaKonumu;
            ViewBag.tAlmaTarih = value.TeslimAlmaTarihi;
            ViewBag.tAlmaSaati = value.TeslimAlmaSaati;
            ViewBag.tEtme = value.TeslimEtmeKonumu;
            ViewBag.tEtmeTarih = value.TeslimEtmeTarihi;
            ViewBag.tEtmeSaati = value.TeslimEtmeSaati;
            ViewBag.gunlukKira = value.GunlukKira;
            ViewBag.toplamGun = value.ToplamGunSayisi;
            ViewBag.toplamTutar = value.ToplamTutar;
            modelTipID = value.TipID;

            var tipID = value.TipID;
            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/CarStatus/4");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData2);
            foreach (var item in value2)
            {
                if (tipID == item.ModelTipID)
                {
                    ViewBag.markaAdi = item.MarkaAdi;
                    ViewBag.tipAdi = item.TipAdi;
                }
            }

            var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Car/");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var value3 = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData3);

            List<SelectListItem> plakalar = (from x in value3.ToList()
                                             where x.DurumID == 4
                                             where x.ModelTipID == modelTipID
                                             select new SelectListItem
                                             {
                                                 Text = x.Plaka,
                                                 Value = x.AracID.ToString()
                                             }).ToList();

            ViewBag.plaka = plakalar;
            ViewBag.aracID = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDailyRentalCar(CreateDailyRentalCarsDto createDailyRentalCarsDto,UpdateStatusDto updateStatusDto)
        {
            var client = _httpClientFactory.CreateClient();
            if (ModelState.IsValid)
            {
                createDailyRentalCarsDto.AracID = Convert.ToInt32(createDailyRentalCarsDto.Plaka);
                var jsonData2 = JsonConvert.SerializeObject(createDailyRentalCarsDto);
                StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PostAsync("https://localhost:44365/api/DailyRentalCars/", stringContent);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    //Aracın statüsü Günlük Kirada olarak güncelleniyor
                    updateStatusDto.AracID = createDailyRentalCarsDto.AracID;
                    updateStatusDto.Durum = createDailyRentalCarsDto.Durum;
                    var jsonData3 = JsonConvert.SerializeObject(updateStatusDto);
                    StringContent stringContent2 = new StringContent(jsonData3, Encoding.UTF8, "application/json");
                    var responseMessage3 = await client.PutAsync("https://localhost:44365/api/CarStatus/", stringContent2);
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index","RentalCarReserved");
                    }
                }
            }
            return View();
        }
    }
}
