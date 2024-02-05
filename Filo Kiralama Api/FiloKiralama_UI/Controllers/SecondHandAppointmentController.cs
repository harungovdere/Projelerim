using FiloKiralama_UI.Dtos.SecondHandAppointmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X.PagedList;
using MailKit.Net.Smtp;
using FiloKiralama_UI.Dtos.CarDtos;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SecondHandAppointmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SecondHandAppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/SecondHandAppointment");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSecondAppointmentHandDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Plaka.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        public async Task<IActionResult> DeleteSecondHandAppointment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/SecondHandAppointment/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        


        [HttpGet]
        public async Task<IActionResult> UpdateSecondHandAppointment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/SecondHandAppointment/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSecondHandAppointmentDto>(jsonData);

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonData = await responseMessage.Content.ReadAsStringAsync();
                value = JsonConvert.DeserializeObject<UpdateSecondHandAppointmentDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSecondHandAppointment(UpdateSecondHandAppointmentDto updateSecondHandAppointmentDto)
        {
           
            var client = _httpClientFactory.CreateClient();

            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(updateSecondHandAppointmentDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:44365/api/SecondHandAppointment/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
