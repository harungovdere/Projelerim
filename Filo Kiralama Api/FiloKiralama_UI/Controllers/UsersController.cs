using FiloKiralama_UI.Dtos.UsersDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Users");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultUsersDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Ad.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUsersDto createUsersDto)
        {
            string mail = "";
            string kimlikNo = "";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Users");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultUsersDto>>(jsonData);
            foreach (var item in value)
            {
                if (createUsersDto.Email == item.Email || createUsersDto.TC == item.TC)
                {
                    mail = item.Email;
                    kimlikNo = item.TC;
                    if (mail != "")
                    {
                        ViewBag.msg = "Daha önce kullanıcı kaydı yapılmış.";
                        return View();
                    }
                    if (kimlikNo != "")
                    {
                        ViewBag.tc = "Daha önce kullanıcı kaydı yapılmış.";
                        return View();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var jsonData2 = JsonConvert.SerializeObject(createUsersDto);
                StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PostAsync("https://localhost:44365/api/Users", stringContent);

                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Users/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateUsersDto>(jsonData);
                //var jsonData2 = JsonConvert.SerializeObject(updateUsersDto);
                //var value2 = JsonConvert.DeserializeObject<UpdateUsersDto>(jsonData2);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUsersDto updateUsersDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Users");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<UpdateUsersDto>>(jsonData);
            foreach (var item in value)
            {
                if (updateUsersDto.KullaniciID != item.KullaniciID)
                {
                    if (updateUsersDto.Email == item.Email)
                    {
                        ViewBag.msg = "Bu mail adresi başka kullanıcı tarafından kullanılıyor";
                        return View();
                    }
                    else if (updateUsersDto.TC == item.TC)
                    {
                        ViewBag.tc = "Bu kimlik no başka kullanıcı tarafından kullanıyor";
                        return View();
                    }
                }
                if (updateUsersDto.KullaniciID == item.KullaniciID && updateUsersDto.Sifre == null)
                {
                    updateUsersDto.Sifre = item.Sifre;
                }
            }
            if (ModelState.IsValid)
            {
                var jsonData2 = JsonConvert.SerializeObject(updateUsersDto);
                StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PutAsync("https://localhost:44365/api/Users/", stringContent);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
