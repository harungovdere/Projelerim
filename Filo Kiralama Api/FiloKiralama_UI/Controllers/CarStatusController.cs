using FiloKiralama_UI.Dtos.CarStatusDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarStatusController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public CarStatusController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/CarStatus/2");
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
        public async Task<IActionResult> UpdateStatu(UpdateStatusDto updateStatusDto, int aracID, int durum)
        {
            var client = _httpClientFactory.CreateClient();

            //Aracın statüsü güncelleniyor
            updateStatusDto.AracID = aracID;
            updateStatusDto.Durum = durum;
            var jsonData = JsonConvert.SerializeObject(updateStatusDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44365/api/CarStatus/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","CarStatus");
            }

            return View();
        }
    }
}
