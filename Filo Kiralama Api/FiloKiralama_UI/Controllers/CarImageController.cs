using FiloKiralama_UI.Dtos.CarImageDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using FiloKiralama_UI.Dtos.BrandsDtos;
using FiloKiralama_UI.Dtos.ModelsDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CarImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IWebHostEnvironment environment;

        public CarImageController(IHttpClientFactory httpClientFactory, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            this.environment = env;
        }
        
        public async Task<IActionResult> Index(int page = 1)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44365/api/Car");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var value = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);

            //    return View(value.ToPagedList(page, 5));
            //}
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/CarImage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCarImageDto>>(jsonData);

                return View(value.ToPagedList(page, 5));
                //return View(value);
            }
            return View();
        }
        public async Task<IActionResult> DeleteImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/CarImage/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultCarImageDto>(jsonData);
            var imageFileName = value.DosyaAdi;

            var responseMessage2 = await client.DeleteAsync($"https://localhost:44365/api/CarImage/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                    try
                    {
                        var wwwPath = this.environment.WebRootPath;
                        //var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                        var path = Path.Combine(wwwPath, @"C:\\Users\\HARUN\\source\\repos\\FiloKiralama_Api\\FiloKiralama_UI\\wwwroot\\Uploads", imageFileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                            //return true;
                        }
                        //return false;
                    }
                    catch (Exception ex)
                    {
                        //return false;
                    }
                
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCarImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/CarImage/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateImageDto>(jsonData);
            var markaKodu = value.MarkaKodu;

            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Brands");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData2);

            var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Model");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var value3 = JsonConvert.DeserializeObject<List<ResultModelDto>>(jsonData3);
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
            ViewBag.v = markaValues;
            ViewBag.m = modelValues;
            if (responseMessage.IsSuccessStatusCode)
            {
                jsonData = await responseMessage.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<UpdateImageDto>(jsonData);
                return View(value);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCarImage(UpdateImageDto updateImageDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:44365/api/CarImage/{updateImageDto.ResimID}");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultCarImageDto>(jsonData);
                var imageFileName = value.DosyaAdi;


                if (responseMessage.IsSuccessStatusCode)
                {
                    try
                    {
                        var wwwPath = this.environment.WebRootPath;
                        //var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                        var path = Path.Combine(wwwPath, @"C:\\Users\\HARUN\\source\\repos\\FiloKiralama_Api\\FiloKiralama_UI\\wwwroot\\Uploads", imageFileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                            //return true;
                        }
                        //return false;
                    }
                    catch (Exception ex)
                    {
                        //return false;
                    }


                }

                var ext = Path.GetExtension(updateImageDto.Dosya.FileName);
                string name = imageFileName;
                //string name = updateImageDto.DosyaAdi;
                //updateImageDto.DosyaAdi = name + ext;
                //var jsonData2 = JsonConvert.SerializeObject(updateImageDto);
                //StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                //var responseMessage3 = await client.PutAsync("https://localhost:44365/api/CarImage", stringContent);


                if (responseMessage.IsSuccessStatusCode)
                {
                    var contentPath = this.environment.ContentRootPath;

                    //var path = Path.Combine(contentPath, "Uploads");
                    var path = Path.Combine(contentPath, @"C:\\Users\\HARUN\\source\\repos\\FiloKiralama_Api\\FiloKiralama_UI\\wwwroot\\Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //var ext = Path.GetExtension(imageFile.FileName);

                    var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                    if (!allowedExtensions.Contains(ext))
                    {
                        string msg = string.Format("Yalnızca {0} uzantıya izin veriliyor", string.Join(",", allowedExtensions));
                        return View(msg);
                    }

                    //string uniqueString = Guid.NewGuid().ToString();
                    // we are trying to create a unique filename here
                    //var newFileName = name + ext;
                    var newFileName = name;
                    //var newFileName = ext;
                    var fileWithPath = Path.Combine(path, newFileName);
                    var stream = new FileStream(fileWithPath, FileMode.Create);
                    updateImageDto.Dosya.CopyTo(stream);
                    //imageFile.CopyTo(stream);
                    stream.Close();

                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDto createImageDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var ext = Path.GetExtension(createImageDto.Dosya.FileName);
                string name = createImageDto.DosyaAdi;
                createImageDto.DosyaAdi = name + ext;
                var jsonData = JsonConvert.SerializeObject(createImageDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44365/api/CarImage", stringContent);

                var contentPath = this.environment.ContentRootPath;

                //var path = Path.Combine(contentPath, "Uploads");
                var path = Path.Combine(contentPath, @"C:\\Users\\HARUN\\source\\repos\\FiloKiralama_Api\\FiloKiralama_UI\\wwwroot\\Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //var ext = Path.GetExtension(imageFile.FileName);

                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Yalnızca {0} uzantıya izin veriliyor", string.Join(",", allowedExtensions));
                    return View(msg);
                }

                //string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = name + ext;
                //var newFileName = ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                createImageDto.Dosya.CopyTo(stream);
                //imageFile.CopyTo(stream);
                stream.Close();



                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //public Tuple<int, string> SaveCarImage(IFormFile imageFile)
        
        //{
        //    try
        //    {
        //        var contentPath = this.environment.ContentRootPath;
                
        //        var path = Path.Combine(contentPath, "Uploads");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        var ext = Path.GetExtension(imageFile.FileName);
        //        var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
        //        if (!allowedExtensions.Contains(ext))
        //        {
        //            string msg = string.Format("Yalnızca {0} uzantıya izin veriliyor", string.Join(",", allowedExtensions));
        //            return new Tuple<int, string>(0, msg);
        //        }

        //        string uniqueString = Guid.NewGuid().ToString();
        //        // we are trying to create a unique filename here
        //        var newFileName = uniqueString + ext;
        //        var fileWithPath = Path.Combine(path, newFileName);
        //        var stream = new FileStream(fileWithPath, FileMode.Create);
        //        imageFile.CopyTo(stream);
        //        //createImageDto.File.CopyTo(stream);
        //        stream.Close();

        //        return new Tuple<int, string>(1, newFileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Tuple<int, string>(0, "Hata oluştu");
        //    }
        //}
    }
}