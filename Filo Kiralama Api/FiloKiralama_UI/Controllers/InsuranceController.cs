using FiloKiralama_UI.Dtos.CarDtos;
using FiloKiralama_UI.Dtos.InsuranceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;


namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InsuranceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InsuranceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Insurance");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultInsuranceDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateInsurance()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
            List<SelectListItem> plakaValues = (from x in value.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Plaka,
                                                    Value = x.Plaka
                                                }).ToList();

            List<SelectListItem> police = new List<SelectListItem>();
            police.Add(new SelectListItem { Text = "TRAFİK SİGORTASI", Value = "1" });
            police.Add(new SelectListItem { Text = "KASKO SİGORTASI", Value = "2" });
            police.Add(new SelectListItem { Text = "İMM SİGORTASI", Value = "3" });

            ViewBag.t = police;
            ViewBag.p = plakaValues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsurance(CreateInsuranceDto createInsuranceDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (!ModelState.IsValid)
            {
                var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                List<SelectListItem> plakaValues = (from x in value.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Plaka,
                                                        Value = x.Plaka
                                                    }).ToList();

                List<SelectListItem> police = new List<SelectListItem>();
                police.Add(new SelectListItem { Text = "TRAFİK SİGORTASI", Value = "1" });
                police.Add(new SelectListItem { Text = "KASKO SİGORTASI", Value = "2" });
                police.Add(new SelectListItem { Text = "İMM SİGORTASI", Value = "3" });

                ViewBag.t = police;
                ViewBag.p = plakaValues;
                return View();
            }

            var jsonData2 = JsonConvert.SerializeObject(createInsuranceDto);
            StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:44365/api/Insurance", stringContent);
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteInsurance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/Insurance/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInsurance(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/Insurance/{id}");

            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Car");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData2);
            List<SelectListItem> plakaValues = (from x in value2.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Plaka,
                                                    Value = x.Plaka
                                                }).ToList();
            List<SelectListItem> police = new List<SelectListItem>();
            police.Add(new SelectListItem { Text = "TRAFİK SİGORTASI", Value = "1" });
            police.Add(new SelectListItem { Text = "KASKO SİGORTASI", Value = "2" });
            police.Add(new SelectListItem { Text = "İMM SİGORTASI", Value = "3" });

            ViewBag.p = plakaValues;
            ViewBag.t = police;
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateInsuranceDto>(jsonData);

                return View(value);
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInsurance(UpdateInsuranceDto updateInsuranceDto)
        {
            var client = _httpClientFactory.CreateClient();

            if(!ModelState.IsValid)
            {
                var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                List<SelectListItem> plakaValues = (from x in value.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Plaka,
                                                        Value = x.Plaka
                                                    }).ToList();
                List<SelectListItem> police = new List<SelectListItem>();
                police.Add(new SelectListItem { Text = "TRAFİK SİGORTASI", Value = "1" });
                police.Add(new SelectListItem { Text = "KASKO SİGORTASI", Value = "2" });
                police.Add(new SelectListItem { Text = "İMM SİGORTASI", Value = "3" });

                ViewBag.p = plakaValues;
                ViewBag.t = police;
                return View();
            }

            var jsonData2 = JsonConvert.SerializeObject(updateInsuranceDto);
            StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PutAsync("https://localhost:44365/api/Insurance/", stringContent);
            if (responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

