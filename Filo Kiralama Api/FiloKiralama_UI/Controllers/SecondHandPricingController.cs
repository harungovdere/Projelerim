using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FiloKiralama_UI.Dtos.SecondHandPricingDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using X.PagedList;
using System.Text;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecondHandPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public SecondHandPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            ViewBag.msg = TempData["Veri"];
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/SecondHandPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSecondHandPricingDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        public async Task<IActionResult> DeleteSecondHandPricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/SecondHandPricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdateSecondHandPricingDto updateSecondHandPricing, string fiyat, int aracID)
        {
            updateSecondHandPricing.AracID = aracID;
            updateSecondHandPricing.Fiyat = fiyat;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/SecondHandPricing/{aracID}");
            
            if (responseMessage.StatusCode.ToString()=="OK")
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultSecondHandPricingDto>(jsonData);

                if (ModelState.IsValid)
                {
                    var jsonData2 = JsonConvert.SerializeObject(updateSecondHandPricing);
                    StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                    var responseMessage2 = await client.PutAsync("https://localhost:44365/api/SecondHandPricing/", stringContent);
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
                    var jsonData3 = JsonConvert.SerializeObject(updateSecondHandPricing);
                    StringContent stringContent = new StringContent(jsonData3, Encoding.UTF8, "application/json");
                    var responseMessage3 = await client.PostAsync("https://localhost:44365/api/SecondHandPricing/", stringContent);
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            TempData["Veri"] = aracID;
            return RedirectToAction("Index");
        }
    }
}
