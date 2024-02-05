using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using FiloKiralama_UI.Dtos.CarReturnDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using FiloKiralama_UI.Dtos.CarDtos;
using System.Linq;
using X.PagedList;
using FiloKiralama_UI.Dtos.CarStatusDtos;
using System;
using FiloKiralama_Api.Dtos.CarDtos;
using System.Text;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarReturnController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public CarReturnController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/CarStatus/1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 10));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarReturn(CreateCarReturnDto createCarReturnDto, UpdateStatusDto updateStatusDto, int KM, int aracID, DateTime donusTarih, int durum)
        {
            var client = _httpClientFactory.CreateClient();

            createCarReturnDto.AracID = aracID;
            createCarReturnDto.KM = KM;
            createCarReturnDto.DonusTarihi = donusTarih;

            var jsonData = JsonConvert.SerializeObject(createCarReturnDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44365/api/CarReturn", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                //Aracın statüsü Kiradan döndü olarak güncelleniyor
                updateStatusDto.AracID = aracID;
                updateStatusDto.Durum = durum;
                var jsonData2 = JsonConvert.SerializeObject(updateStatusDto);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PutAsync("https://localhost:44365/api/CarStatus/", stringContent2);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();
        }
    }
}
