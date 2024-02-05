using FiloKiralama_UI.Dtos.FleetOfferDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using FiloKiralama_UI.Dtos.FleetRentalRequestDtos;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FleetOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FleetOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string ara, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/FleetOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFleetOfferDto>>(jsonData);
                if (!string.IsNullOrEmpty(ara))
                {
                    value = value.Where(x => x.FirmaUnvani.Contains(ara)).ToList();
                }
                return View(value.ToPagedList(page, 5));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSendAnOffer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/FleetRentalRequest/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultFleetRentalRequestDto>(jsonData);
            ViewBag.talepID = value.FiloTalepID;
            ViewBag.talepTarih = value.FiloTalepTarihi;
            ViewBag.firma = value.FirmaUnvani;
            ViewBag.marka = value.MarkaAdi;
            ViewBag.model = value.TipAdi;
            ViewBag.km = value.YillikKM;
            ViewBag.sure = value.KiralamaSuresi;
            ViewBag.mevcutArac = value.MevcutAracAdedi;
            ViewBag.talepArac = value.TalepEdilenAracAdedi;
            ViewBag.mail = value.EPosta;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateSendAnOffer(CreateSendAnOfferDto createSendAnOfferDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(createSendAnOfferDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44365/api/FleetOffer/", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Filo Kiralama Admin", "hrngvd@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("", createSendAnOfferDto.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodybuilder = new BodyBuilder();

                    bodybuilder.HtmlBody = string.Format(@" 
                        <br><p>Merhaba,<br><br>
                        Vermiş olduğumuz filo teklif detayları aşağıdaki gibidir.<br><br>
                        Filo Talep Tarihi: {0}<br>
                        Firmanız: {1}<br>
                        İstenilen Araç: {2} {3}<br>
                        Talep Edilen Yıllık KM: {4} KM<br>
                        Talep Edilen Kiralama Süresi: {5} Ay<br>
                        Aylık Kira Fiyatı: {6} TL<br>
                        Yıllık Kira Fiyatı: {7} TL</p>", createSendAnOfferDto.TalepTarihi, createSendAnOfferDto.FirmaUnvani, createSendAnOfferDto.Marka, createSendAnOfferDto.Model, createSendAnOfferDto.YillikKM, createSendAnOfferDto.KiralamaSuresi, createSendAnOfferDto.AylikKiraFiyati, createSendAnOfferDto.YillikKiraFiyati);

                    mimeMessage.Body = bodybuilder.ToMessageBody();
                    mimeMessage.Subject = "Royal Cars Filo Kiralama";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("hrngvd@gmail.com", "hyizohpigfwdvuqg");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    return RedirectToAction("Index", "FleetRentalRequest");
                }
               
            }
            return View();

        }


    }
}
