using FiloKiralama_UI.Dtos.RentalCarReservedDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using X.PagedList;
using System.Text;


namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RentalCarReservedController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentalCarReservedController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/RentalCarReserved");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultRentalCarReservedDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.Ad.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        

        
    }
}
