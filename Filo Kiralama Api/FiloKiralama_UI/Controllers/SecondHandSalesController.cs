using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FiloKiralama_UI.Dtos.UsersDtos;
using FiloKiralama_UI.Dtos.SecondHandSalesDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using X.PagedList;
using System.Text;
using FluentValidation;
using FiloKiralama_UI.Dtos.SoldCarsDtos;
using FiloKiralama_UI.Dtos.CarStatusDtos;


namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SecondHandSalesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public SecondHandSalesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/SecondHandSales");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSecondHandSalesDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        public async Task<IActionResult> CreateSales(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Users");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultUsersDto>>(jsonData);
            List<SelectListItem> Uyeler = (from x in value.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = (x.Ad+" "+x.Soyad),
                                                    Value = x.KullaniciID.ToString()
                                                }).ToList();

            
            ViewBag.Uyeler = Uyeler;
            ViewBag.aracID = id;

            var responseMessage2 = await client.GetAsync($"https://localhost:44365/api/SecondHandSales/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultSecondHandSalesDto>(jsonData2);
                ViewBag.plaka = value2.Plaka;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSales(CreateSecondHandSalesDto createSecondHandSalesDto,UpdateStatusDto updateStatusDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (!ModelState.IsValid)
            {
                ViewBag.aracID = createSecondHandSalesDto.AracID;
                ViewBag.plaka = createSecondHandSalesDto.Plaka;
                var responseMessage = await client.GetAsync("https://localhost:44365/api/Users");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultUsersDto>>(jsonData);
                List<SelectListItem> Uyeler = (from x in value.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = (x.Ad + " " + x.Soyad),
                                                   Value = x.KullaniciID.ToString()
                                               }).ToList();

                ViewBag.Uyeler = Uyeler;

                return View();
            }

            var jsonData2 = JsonConvert.SerializeObject(createSecondHandSalesDto);
            StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:44365/api/SecondHandSales/", stringContent);
            if (responseMessage2.IsSuccessStatusCode)
            {
                //Aracın statüsü satıldı olarak güncelleniyor
                updateStatusDto.AracID = createSecondHandSalesDto.AracID;
                updateStatusDto.Durum = createSecondHandSalesDto.Durum;
                var jsonData3 = JsonConvert.SerializeObject(updateStatusDto);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage3 = await client.PutAsync("https://localhost:44365/api/CarStatus/", stringContent2);
                if (responseMessage3.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> SoldCarsList(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/SoldCars");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSoldCarsDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));

            }
            return View();
        }
    }
}
