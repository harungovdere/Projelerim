using FiloKiralama_UI.Dtos.BrandsDtos;
using FiloKiralama_UI.Dtos.CarDtos;
using FiloKiralama_UI.Dtos.ModelsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using FluentValidation;
using FiloKiralama_UI.Dtos.ModelYearDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;



namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string ara,string durum, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                if (!string.IsNullOrEmpty(durum))
                {
                    value = value.Where(x => x.Durum.Contains(durum)).ToList();
                }
                
                //if (ara == null && durum == null && page > 1)
                //{
                //    return PartialView("~/Views/Car/_AllCarList.cshtml", value.ToPagedList(page, 10));
                //}
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {

            List<SelectListItem> sanziman = new List<SelectListItem>();
            sanziman.Add(new SelectListItem { Text = "OTOMATİK", Value = "OTOMATİK" });
            sanziman.Add(new SelectListItem { Text = "MANUEL", Value = "MANUEL" });

            List<SelectListItem> yakit = new List<SelectListItem>();
            yakit.Add(new SelectListItem { Text = "DİZEL", Value = "DİZEL" });
            yakit.Add(new SelectListItem { Text = "BENZİN", Value = "BENZİN" });
            yakit.Add(new SelectListItem { Text = "HİBRİT", Value = "HİBRİT" });

            List<SelectListItem> renk = new List<SelectListItem>();
            renk.Add(new SelectListItem { Text = "BEYAZ", Value = "BEYAZ" });
            renk.Add(new SelectListItem { Text = "GRİ", Value = "GRİ" });
            renk.Add(new SelectListItem { Text = "SİYAH", Value = "SİYAH" });

            List<SelectListItem> durum = new List<SelectListItem>();
            durum.Add(new SelectListItem { Text = "FİLO KİRALIK", Value = "2" });
            durum.Add(new SelectListItem { Text = "GÜNLÜK KİRALIK", Value = "4" });
            //durum.Add(new SelectListItem { Text = "STOKDA", Value = "6" });

            ViewBag.s = sanziman;
            ViewBag.y = yakit;
            ViewBag.r = renk;
            ViewBag.d = durum;

            return View();
        }

        public async Task<JsonResult> MarkaGetir()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> markaValues = (from x in value.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.MarkaAdi,
                                                    Value = x.MarkaKodu.ToString()
                                                }).ToList();
            return Json(markaValues);
        }
        public async Task<JsonResult> ModelGetir(int MarkaKodu)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Model");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<List<ResultModelDto>>(jsonData2);

            List<SelectListItem> modelValues = (from x in value2.ToList()
                                                where x.MarkaKodu == MarkaKodu
                                                select new SelectListItem
                                                {
                                                    Text = x.TipAdi,
                                                    Value = x.TipKodu.ToString()
                                                }).ToList();

            return Json(modelValues);

            //return Json(new { data = modelValues }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> ModelYilGetir(int MarkaKodu, int TipKodu)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/ModelYear?MarkaID=" + MarkaKodu + "&TipID=" + TipKodu);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<GetByIDModelYearDto>>(jsonData);

            List<SelectListItem> modelYearValues = (from x in value.ToList()
                                                    where x.MarkaKodu == MarkaKodu
                                                    where x.TipKodu == TipKodu
                                                    select new SelectListItem
                                                    {
                                                        Text = x.ModelYili.ToString(),
                                                        Value = x.ModelYili.ToString()
                                                    }).ToList();
            return Json(modelYearValues);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            string plaka = "";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
            foreach (var item in value)
            {
                if (createCarDto.Plaka == item.Plaka)
                {
                    plaka = item.Plaka;
                    if (plaka != "")
                    {
                        ViewBag.plaka = "Plaka daha önce kayıt edilmiş.";

                        List<SelectListItem> sanziman = new List<SelectListItem>();
                        sanziman.Add(new SelectListItem { Text = "OTOMATİK", Value = "OTOMATİK" });
                        sanziman.Add(new SelectListItem { Text = "MANUEL", Value = "MANUEL" });

                        List<SelectListItem> yakit = new List<SelectListItem>();
                        yakit.Add(new SelectListItem { Text = "DİZEL", Value = "DİZEL" });
                        yakit.Add(new SelectListItem { Text = "BENZİN", Value = "BENZİN" });
                        yakit.Add(new SelectListItem { Text = "HİBRİT", Value = "HİBRİT" });

                        List<SelectListItem> renk = new List<SelectListItem>();
                        renk.Add(new SelectListItem { Text = "BEYAZ", Value = "BEYAZ" });
                        renk.Add(new SelectListItem { Text = "GRİ", Value = "GRİ" });
                        renk.Add(new SelectListItem { Text = "SİYAH", Value = "SİYAH" });

                        List<SelectListItem> durum = new List<SelectListItem>();
                        durum.Add(new SelectListItem { Text = "FİLO KİRALIK", Value = "2" });
                        durum.Add(new SelectListItem { Text = "GÜNLÜK KİRALIK", Value = "4" });
                        //durum.Add(new SelectListItem { Text = "STOKDA", Value = "6" });

                        ViewBag.s = sanziman;
                        ViewBag.y = yakit;
                        ViewBag.r = renk;
                        ViewBag.d = durum;
                        return View();
                    }
                }
            }
            
            if (ModelState.IsValid)
            {

                var jsonData2 = JsonConvert.SerializeObject(createCarDto);
                StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PostAsync("https://localhost:44365/api/Car", stringContent);

                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/Car/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/Car/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
            var markaKodu = value.MarkaKodu;
            var tipKodu = value.TipKodu;

            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Brands");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData2);

            var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Model");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var value3 = JsonConvert.DeserializeObject<List<ResultModelDto>>(jsonData3);

            var responseMessage4 = await client.GetAsync("https://localhost:44365/api/ModelYear?MarkaID=" + markaKodu + "&TipID=" + tipKodu);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            var value4 = JsonConvert.DeserializeObject<List<GetByIDModelYearDto>>(jsonData4);

            List<SelectListItem> markaValues = (from x in value2.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.MarkaAdi,
                                                    Value = x.MarkaKodu.ToString()
                                                }).ToList();

            List<SelectListItem> modelValues = (from x in value3.ToList()
                                                    //join y in value2.ToList() on x.MarkaKodu equals y.MarkaKodu
                                                where x.MarkaKodu == markaKodu
                                                select new SelectListItem
                                                {
                                                    Text = x.TipAdi,
                                                    Value = x.TipKodu.ToString()
                                                }).ToList();


            List<SelectListItem> modelYearValues = (from x in value4.ToList()
                                                    where x.MarkaKodu == markaKodu
                                                    where x.TipKodu == tipKodu
                                                    select new SelectListItem
                                                    {
                                                        Text = x.ModelYili.ToString(),
                                                        Value = x.ModelYili.ToString()
                                                    }).ToList();
            List<SelectListItem> sanziman = new List<SelectListItem>();
            sanziman.Add(new SelectListItem { Text = "OTOMATİK", Value = "OTOMATİK" });
            sanziman.Add(new SelectListItem { Text = "MANUEL", Value = "MANUEL" });

            List<SelectListItem> yakit = new List<SelectListItem>();
            yakit.Add(new SelectListItem { Text = "DİZEL", Value = "DİZEL" });
            yakit.Add(new SelectListItem { Text = "BENZİN", Value = "BENZİN" });
            yakit.Add(new SelectListItem { Text = "HİBRİT", Value = "HİBRİT" });

            List<SelectListItem> renk = new List<SelectListItem>();
            renk.Add(new SelectListItem { Text = "BEYAZ", Value = "BEYAZ" });
            renk.Add(new SelectListItem { Text = "GRİ", Value = "GRİ" });
            renk.Add(new SelectListItem { Text = "SİYAH", Value = "SİYAH" });

            List<SelectListItem> durum = new List<SelectListItem>();
            //durum.Add(new SelectListItem { Text = "FİLO KİRADA", Value = "1" });
            durum.Add(new SelectListItem { Text = "FİLO KİRALIK", Value = "2" });
            //durum.Add(new SelectListItem { Text = "GÜNLÜK KİRADA", Value = "3" });
            durum.Add(new SelectListItem { Text = "GÜNLÜK KİRALIK", Value = "4" });
            //durum.Add(new SelectListItem { Text = "İKİNCİ EL", Value = "5" });
            //durum.Add(new SelectListItem { Text = "STOKDA", Value = "6" });
            //durum.Add(new SelectListItem { Text = "SATILDI", Value = "7" });
            //durum.Add(new SelectListItem { Text = "PERT", Value = "8" });

            ViewBag.v = markaValues;
            ViewBag.m = modelValues;
            ViewBag.n = modelYearValues;
            ViewBag.s = sanziman;
            ViewBag.y = yakit;
            ViewBag.r = renk;
            ViewBag.d = durum;

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonData = await responseMessage.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            string plaka = "";
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
            foreach (var item in value)
            {
                if (updateCarDto.Plaka == item.Plaka && updateCarDto.AracID != item.AracID)
                {
                    plaka = item.Plaka;
                    if (plaka != "")
                    {
                        ViewBag.plaka = "Plaka daha önce kayıt edilmiş.";

                        int id = updateCarDto.AracID;
                        var responseMessage5 = await client.GetAsync($"https://localhost:44365/api/Car/{id}");
                        var jsonData6 = await responseMessage5.Content.ReadAsStringAsync();
                        var value6 = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData6);
                        var markaKodu = value6.MarkaKodu;
                        var tipKodu = value6.TipKodu;

                        var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Brands");
                        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                        var value2 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData2);

                        var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Model");
                        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                        var value3 = JsonConvert.DeserializeObject<List<ResultModelDto>>(jsonData3);

                        var responseMessage4 = await client.GetAsync("https://localhost:44365/api/ModelYear?MarkaID=" + markaKodu + "&TipID=" + tipKodu);
                        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                        var value4 = JsonConvert.DeserializeObject<List<GetByIDModelYearDto>>(jsonData4);

                        List<SelectListItem> markaValues = (from x in value2.ToList()
                                                            select new SelectListItem
                                                            {
                                                                Text = x.MarkaAdi,
                                                                Value = x.MarkaKodu.ToString()
                                                            }).ToList();

                        List<SelectListItem> modelValues = (from x in value3.ToList()
                                                                //join y in value2.ToList() on x.MarkaKodu equals y.MarkaKodu
                                                            where x.MarkaKodu == markaKodu
                                                            select new SelectListItem
                                                            {
                                                                Text = x.TipAdi,
                                                                Value = x.TipKodu.ToString()
                                                            }).ToList();


                        List<SelectListItem> modelYearValues = (from x in value4.ToList()
                                                                where x.MarkaKodu == markaKodu
                                                                where x.TipKodu == tipKodu
                                                                select new SelectListItem
                                                                {
                                                                    Text = x.ModelYili.ToString(),
                                                                    Value = x.ModelYili.ToString()
                                                                }).ToList();

                        List<SelectListItem> sanziman = new List<SelectListItem>();
                        sanziman.Add(new SelectListItem { Text = "OTOMATİK", Value = "OTOMATİK" });
                        sanziman.Add(new SelectListItem { Text = "MANUEL", Value = "MANUEL" });

                        List<SelectListItem> yakit = new List<SelectListItem>();
                        yakit.Add(new SelectListItem { Text = "DİZEL", Value = "DİZEL" });
                        yakit.Add(new SelectListItem { Text = "BENZİN", Value = "BENZİN" });
                        yakit.Add(new SelectListItem { Text = "HİBRİT", Value = "HİBRİT" });

                        List<SelectListItem> renk = new List<SelectListItem>();
                        renk.Add(new SelectListItem { Text = "BEYAZ", Value = "BEYAZ" });
                        renk.Add(new SelectListItem { Text = "GRİ", Value = "GRİ" });
                        renk.Add(new SelectListItem { Text = "SİYAH", Value = "SİYAH" });

                        List<SelectListItem> durum = new List<SelectListItem>();
                        //durum.Add(new SelectListItem { Text = "FİLO KİRADA", Value = "1" });
                        durum.Add(new SelectListItem { Text = "FİLO KİRALIK", Value = "2" });
                        //durum.Add(new SelectListItem { Text = "GÜNLÜK KİRADA", Value = "3" });
                        durum.Add(new SelectListItem { Text = "GÜNLÜK KİRALIK", Value = "4" });
                        //durum.Add(new SelectListItem { Text = "İKİNCİ EL", Value = "5" });
                        //durum.Add(new SelectListItem { Text = "STOKDA", Value = "6" });
                        //durum.Add(new SelectListItem { Text = "SATILDI", Value = "7" });
                        //durum.Add(new SelectListItem { Text = "PERT", Value = "8" });

                        ViewBag.v = markaValues;
                        ViewBag.m = modelValues;
                        ViewBag.n = modelYearValues;
                        ViewBag.s = sanziman;
                        ViewBag.y = yakit;
                        ViewBag.r = renk;
                        ViewBag.d = durum;
                        return View();
                    }
                }
            }
            
            
            if (ModelState.IsValid)
            {
                var jsonData2 = JsonConvert.SerializeObject(updateCarDto);
                StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PutAsync("https://localhost:44365/api/Car/", stringContent);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
