using FiloKiralama_UI.Dtos.RentalCarPricingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RentalCarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public RentalCarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            ViewBag.msg = TempData["Veri"];
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/RentalCarPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultRentalCarPricingDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.MarkaAdi.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdateRentalCarPricingDto updateRentalCarPricingDto, string GunlukKiraFiyat, int modelTipID)
        {
            updateRentalCarPricingDto.ModelTipID = modelTipID;
            updateRentalCarPricingDto.GunlukKiraFiyat = GunlukKiraFiyat;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/RentalCarPricing/{modelTipID}");

            if (responseMessage.StatusCode.ToString() == "OK")
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultRentalCarPricingDto>(jsonData);

                if (ModelState.IsValid)
                {
                    var jsonData2 = JsonConvert.SerializeObject(updateRentalCarPricingDto);
                    StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                    var responseMessage2 = await client.PutAsync("https://localhost:44365/api/RentalCarPricing/", stringContent);
                    if (responseMessage2.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var jsonData3 = JsonConvert.SerializeObject(updateRentalCarPricingDto);
                    StringContent stringContent = new StringContent(jsonData3, Encoding.UTF8, "application/json");
                    var responseMessage3 = await client.PostAsync("https://localhost:44365/api/RentalCarPricing/", stringContent);
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            TempData["Veri"] = "mesaj";
            return RedirectToAction("Index");
        }
    }
}
