using FiloKiralama_UI.Dtos.FleetRentalRequestDtos;
using FiloKiralama_UI.Dtos.BrandsDtos;
using FiloKiralama_UI.Dtos.UsersDtos;
using FiloKiralama_UI.Dtos.ModelsDtos;
using FiloKiralama_UI.Dtos.RentalCarReservedDtos;
using FiloKiralama_UI.Dtos.SecondHandAppointmentDtos;
using FiloKiralama_UI.Dtos.FleetRentCustomersDtos;
using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X.PagedList;
using Microsoft.AspNetCore.Identity;
using FiloKiralama_UI.Dtos.CarStatusDtos;
using FiloKiralama_UI.Dtos.MemberTransactionsDtos;




namespace FiloKiralama_UI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly UserManager<resultUsersDto> _userManager;
        //private readonly SignInManager<resultUsersDto> _signInManager;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string link = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(link);
            string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string EUR = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            string GBP = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;

            ViewBag.usd = USD;
            ViewBag.eur = EUR;
            ViewBag.gbp = GBP;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/CarStatus/4");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData);
            List<SelectListItem> kiralıkAraclar = (from x in value.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.TipAdi,
                                                    Value = x.ModelTipID.ToString()
                                                }).ToList();
            ViewBag.Araclar = kiralıkAraclar;
            return View();
        }
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CarList(int page = 1)
        {
            //Kiralık Araçlar
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/CarStatus/4");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData);

                return View(value.ToPagedList(page, 6));
            }

            return View();
        }

        public async Task<IActionResult> RentCarDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/CarStatus/4");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData);
            foreach (var item in value)
            {
                if (id == item.ModelTipID)
                {
                    ViewBag.markaAdi = item.MarkaAdi;
                    ViewBag.tipAdi = item.TipAdi;
                    ViewBag.dosyaAdi = item.DosyaAdi;
                    ViewBag.tipID = item.ModelTipID;
                    ViewBag.gunlukKira = item.GunlukKiraFiyat;
                }
            }
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;

                var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Users/" + kullaniciID);
                if (responseMessage2.StatusCode.ToString() == "OK")
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var value2 = JsonConvert.DeserializeObject<ResultUsersDto>(jsonData2);
                    ViewBag.kullaniciID = value2.KullaniciID;
                    ViewBag.ad = value2.Ad;
                    ViewBag.soyad = value2.Soyad;
                    ViewBag.mail = value2.Email;
                    ViewBag.tel = value2.CepTel;
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RentCarDetail(CreateRentalCarReservedDto createRentalCarReservedDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(createRentalCarReservedDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44365/api/RentalCarReserved", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Filo Kiralama Admin", "hrngvd@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress(createRentalCarReservedDto.Ad + " " + createRentalCarReservedDto.Soyad, createRentalCarReservedDto.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodybuilder = new BodyBuilder();
                    //bodybuilder.TextBody = "Merhaba" + " " + createRentalCarReservedDto.Ad + " " + createRentalCarReservedDto.Soyad;

                    bodybuilder.HtmlBody = string.Format(@" 
                        <br><p>Merhaba {0} {1},<br><br>
                        Rezervasyon detaylarınız aşağıdaki gibidir.<br><br>
                        Teslim Alma Konumu: {2}<br>
                        Teslim Alma Tarihi: {3}<br>
                        Teslim Alma Saati: {4}<br>
                        Teslim Etme Konumu: {5}<br>
                        Teslim Etme Tarihi: {6}<br>
                        Teslim Etme Saati: {7}<br>
                        Toplam Kiralanan Gün Sayısı: {8}<br>
                        Toplam Kira Tutarı: {9}</p>", createRentalCarReservedDto.Ad, createRentalCarReservedDto.Soyad, createRentalCarReservedDto.TeslimAlmaKonumu, createRentalCarReservedDto.TeslimAlmaTarihi, createRentalCarReservedDto.TeslimAlmaSaati, createRentalCarReservedDto.TeslimEtmeKonumu, createRentalCarReservedDto.TeslimEtmeTarihi, createRentalCarReservedDto.TeslimEtmeSaati, createRentalCarReservedDto.ToplamGunSayisi, createRentalCarReservedDto.ToplamTutar);

                    mimeMessage.Body = bodybuilder.ToMessageBody();
                    mimeMessage.Subject = "Royal Cars Filo Kiralama";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("hrngvd@gmail.com", "hyizohpigfwdvuqg");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    string mesaj = "İşlem tamamlanmıştır. Detay bilgisi mail adresinize gönderilmiştir";
                    ViewBag.mesaj = mesaj;
                    //return View();
                    //return RedirectToAction("Index");
                }
            }

            var tipID = createRentalCarReservedDto.TipID;
            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/CarStatus/4");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData2);
            foreach (var item in value)
            {
                if (tipID == item.ModelTipID)
                {
                    ViewBag.markaAdi = item.MarkaAdi;
                    ViewBag.tipAdi = item.TipAdi;
                    ViewBag.dosyaAdi = item.DosyaAdi;
                    ViewBag.tipID = item.ModelTipID;
                    ViewBag.gunlukKira = item.GunlukKiraFiyat;
                }
            }
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;

                var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Users/" + kullaniciID);
                if (responseMessage3.StatusCode.ToString() == "OK")
                {
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var value2 = JsonConvert.DeserializeObject<ResultUsersDto>(jsonData3);
                    ViewBag.kullaniciID = value2.KullaniciID;
                    ViewBag.ad = value2.Ad;
                    ViewBag.soyad = value2.Soyad;
                    ViewBag.mail = value2.Email;
                    ViewBag.tel = value2.CepTel;
                    return View();
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> FleetRentalRequest(CreateFleetRentalRequestDto createFleetRentalRequestDto, CreateFleetRentCustomersDto createFleetRentCustomersDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (ModelState.IsValid)
            {
                var responseMessage = await client.GetAsync($"https://localhost:44365/api/FleetRentCustomers/{createFleetRentalRequestDto.VergiNoKimlikNo}");

                if (responseMessage.StatusCode.ToString() != "OK")
                {

                    createFleetRentCustomersDto.MusteriTipi = createFleetRentalRequestDto.MusteriTipi;
                    createFleetRentCustomersDto.FirmaUnvani = createFleetRentalRequestDto.FirmaUnvani;
                    createFleetRentCustomersDto.VergiDairesi = createFleetRentalRequestDto.VergiDairesi;
                    createFleetRentCustomersDto.VergiNoKimlikNo = createFleetRentalRequestDto.VergiNoKimlikNo;
                    createFleetRentCustomersDto.Telefon = createFleetRentalRequestDto.Telefon;
                    createFleetRentCustomersDto.EPosta = createFleetRentalRequestDto.EPosta;

                    var jsonData = JsonConvert.SerializeObject(createFleetRentCustomersDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage2 = await client.PostAsync("https://localhost:44365/api/FleetRentCustomers", stringContent);
                }

                var responseMessage3 = await client.GetAsync($"https://localhost:44365/api/FleetRentCustomers/{createFleetRentalRequestDto.VergiNoKimlikNo}");
                var jsonData2 = await responseMessage3.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<ResultFleetRentCustomersDto>(jsonData2);
                createFleetRentalRequestDto.MusteriID = value2.FiloMusteriID;

                var jsonData3 = JsonConvert.SerializeObject(createFleetRentalRequestDto);
                StringContent stringContent2 = new StringContent(jsonData3, Encoding.UTF8, "application/json");
                var responseMessage4 = await client.PostAsync("https://localhost:44365/api/FleetRentalRequest", stringContent2);


                if (responseMessage4.IsSuccessStatusCode)
                {
                    var responseMessage5 = await client.GetAsync("https://localhost:44365/api/Brands");
                    var jsonData4 = await responseMessage5.Content.ReadAsStringAsync();
                    var value3 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData4);
                    var markaAdi = "";

                    foreach (var item in value3)
                    {
                        if (createFleetRentalRequestDto.MarkaKodu == item.MarkaKodu)
                        {
                            markaAdi = item.MarkaAdi;
                        }

                    }

                    var responseMessage6 = await client.GetAsync("https://localhost:44365/api/Model");
                    var jsonData5 = await responseMessage6.Content.ReadAsStringAsync();
                    var value4 = JsonConvert.DeserializeObject<List<ResultModelDto>>(jsonData5);
                    var tipAdi = "";

                    foreach (var item in value4)
                    {
                        if (createFleetRentalRequestDto.MarkaKodu == item.MarkaKodu && createFleetRentalRequestDto.TipKodu == item.TipKodu)
                        {
                            tipAdi = item.TipAdi;
                        }
                    }

                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Filo Kiralama Admin", "hrngvd@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress(createFleetRentalRequestDto.FirmaUnvani, createFleetRentalRequestDto.EPosta);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodybuilder = new BodyBuilder();
                    //bodybuilder.TextBody = "Merhaba" + " " + createRentalCarReservedDto.Ad + " " + createRentalCarReservedDto.Soyad;

                    bodybuilder.HtmlBody = string.Format(@" 
                        <br><p>Merhaba,<br><br>
                        Filo kiralama talebiniz alınmıştır.<br>
                        En kısa sürede teklif dönüşü yapılacaktır.<br><br>
                        Marka: {0}<br>
                        Model: {1}<br>
                        Yıllık KM: {2}<br>
                        Kiralama Süresi: {3}<br>
                        Mevcut Araç Adedi: {4}<br>
                        Talep Edilen Araç Adedi: {5}<br>
                        </p>"
                    , markaAdi, tipAdi, createFleetRentalRequestDto.YillikKM, createFleetRentalRequestDto.KiralamaSuresi, createFleetRentalRequestDto.MevcutAracAdedi, createFleetRentalRequestDto.TalepEdilenAracAdedi);

                    mimeMessage.Body = bodybuilder.ToMessageBody();
                    mimeMessage.Subject = "Royal Cars Filo Kiralama";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("hrngvd@gmail.com", "hyizohpigfwdvuqg");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    string mesaj = "İşlem tamamlanmıştır. Detay bilgisi mail adresinize gönderilmiştir";
                    ViewBag.mesaj = mesaj;
                    //return View();
                    //return RedirectToAction("Index");
                }

            }
            ViewBag.marka = createFleetRentalRequestDto.MarkaKodu;
            ViewBag.tip = createFleetRentalRequestDto.TipKodu;
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> CarList2(int page = 1)
        {
            //İkinci el araçlar
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/CarStatus/5");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData);
                return View(value.ToPagedList(page, 6));
            }
            return View();
        }

        public async Task<IActionResult> SecondHandAppointment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/CarStatus/5");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData);
            foreach (var item in value)
            {
                if (id == item.AracID)
                {
                    ViewBag.markaAdi = item.MarkaAdi;
                    ViewBag.tipAdi = item.TipAdi;
                    ViewBag.dosyaAdi = item.DosyaAdi;
                    ViewBag.aracID = item.AracID;
                }
            }
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;

                var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Users/" + kullaniciID);
                if (responseMessage2.StatusCode.ToString() == "OK")
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var value2 = JsonConvert.DeserializeObject<ResultUsersDto>(jsonData2);
                    ViewBag.kullaniciID = value2.KullaniciID;
                    ViewBag.ad = value2.Ad;
                    ViewBag.soyad = value2.Soyad;
                    ViewBag.mail = value2.Email;
                    ViewBag.tel = value2.CepTel;
                    return View();
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SecondHandAppointment(CreateSecondHandAppointmentDto createSecondHandAppointmentDto)
        {
            var client = _httpClientFactory.CreateClient();

            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(createSecondHandAppointmentDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44365/api/SecondHandAppointment", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Filo Kiralama Admin", "hrngvd@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress(createSecondHandAppointmentDto.Ad + " " + createSecondHandAppointmentDto.Soyad, createSecondHandAppointmentDto.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodybuilder = new BodyBuilder();
                    //bodybuilder.TextBody = "Merhaba" + " " + createRentalCarReservedDto.Ad + " " + createRentalCarReservedDto.Soyad;

                    bodybuilder.HtmlBody = string.Format(@" 
                        <br><p>Merhaba {0} {1},<br><br>
                        Randevu detaylarınız aşağıdaki gibidir.<br><br>
                        Randevu Tarihi: {2}<br>
                        Randevu Saati: {3}<br>
                        Araç Numarası: {4}<br></p>"
                    , createSecondHandAppointmentDto.Ad, createSecondHandAppointmentDto.Soyad, createSecondHandAppointmentDto.RandevuTarihi, createSecondHandAppointmentDto.RandevuSaati, createSecondHandAppointmentDto.AracID);
                    mimeMessage.Body = bodybuilder.ToMessageBody();
                    mimeMessage.Subject = "Royal Cars Filo Kiralama";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("hrngvd@gmail.com", "hyizohpigfwdvuqg");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    string mesaj = "İşlem tamamlanmıştır. Detay bilgisi mail adresinize gönderilmiştir";
                    ViewBag.mesaj = mesaj;
                    //return View();
                    //return RedirectToAction("Index");
                }

            }
            var aracID = createSecondHandAppointmentDto.AracID;
            var responseMessage2 = await client.GetAsync("https://localhost:44365/api/CarStatus/5");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultTransactionsDto>>(jsonData2);
            foreach (var item in value)
            {
                if (aracID == item.AracID)
                {
                    ViewBag.markaAdi = item.MarkaAdi;
                    ViewBag.tipAdi = item.TipAdi;
                    ViewBag.dosyaAdi = item.DosyaAdi;
                    ViewBag.aracID = item.AracID;
                }
            }
            if (@User.Identity.Name != null)
            {
                var id = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;

                var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Users/" + id);
                if (responseMessage3.StatusCode.ToString() == "OK")
                {
                    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                    var value2 = JsonConvert.DeserializeObject<ResultUsersDto>(jsonData3);
                    ViewBag.kullaniciID = value2.KullaniciID;
                    ViewBag.ad = value2.Ad;
                    ViewBag.soyad = value2.Soyad;
                    ViewBag.mail = value2.Email;
                    ViewBag.tel = value2.CepTel;
                    return View();
                }
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult Service()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> UserInformation()
        {
            ViewBag.sifre = TempData["sifre"];
            ViewBag.eskiSifre = TempData["eskiSifre"];
            ViewBag.yeniSifre = TempData["yeniSifre"];
            ViewBag.yeniSifreTekrar = TempData["yeniSifreTekrar"];
            ViewBag.yeniSifreTekrar2 = TempData["yeniSifreHata"];
            ViewBag.msj = TempData["msj"];
            var client = _httpClientFactory.CreateClient();
            if (@User.Identity.Name != null)
            {
                //surname kullaniciID tutuyor
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;

                var responseMessage = await client.GetAsync("https://localhost:44365/api/Users/" + kullaniciID);
                if (responseMessage.StatusCode.ToString() == "OK")
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UpdateUsersDto>(jsonData);

                    return View(value);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserInformation(UpdateUsersDto updateUsersDto)
        {
            var client = _httpClientFactory.CreateClient();

            int kullaniciID = 0;
            if (@User.Identity.Name != null)
            {
                var id = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;
                var responseMessage = await client.GetAsync("https://localhost:44365/api/Users/" + id);
                if (responseMessage.StatusCode.ToString() == "OK")
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UpdateUsersDto>(jsonData);
                    kullaniciID = value.KullaniciID;
                    if (updateUsersDto.Sifre == null || updateUsersDto.Sifre == "")
                    {
                        updateUsersDto.Sifre = value.Sifre;
                    }

                    var responseMessage2 = await client.GetAsync("https://localhost:44365/api/Users");
                    if (responseMessage2.StatusCode.ToString() == "OK")
                    {
                        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                        var value2 = JsonConvert.DeserializeObject<List<UpdateUsersDto>>(jsonData2);
                        foreach (var item in value2)
                        {
                            if (kullaniciID != item.KullaniciID)
                            {
                                if (updateUsersDto.Email == item.Email || updateUsersDto.TC == item.TC)
                                {

                                    if (updateUsersDto.Email == item.Email)
                                    {
                                        ViewBag.msg = "Bu mail adresi başka kullanıcı tarafından kullanılıyor";
                                        return View();
                                    }
                                    if (updateUsersDto.TC == item.TC)
                                    {
                                        ViewBag.tc = "Bu kimlik no başka kullanıcı tarafından kullanıyor";
                                        return View();
                                    }
                                }
                            }
                        }
                    }

                }

                if (ModelState.IsValid)
                {
                    var jsonData3 = JsonConvert.SerializeObject(updateUsersDto);
                    StringContent stringContent = new StringContent(jsonData3, Encoding.UTF8, "application/json");
                    var responseMessage3 = await client.PutAsync("https://localhost:44365/api/Users/", stringContent);
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("Index");
                        ViewBag.msj = "Yapmış olduğunuz değişiklikler kaydedilmiştir.";
                        return View();
                    }
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UpdateUserPassword(UpdateUsersDto updateUsersDto)
        {
            var client = _httpClientFactory.CreateClient();
            if (@User.Identity.Name != null)
            {
                var id = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;
                var responseMessage = await client.GetAsync("https://localhost:44365/api/Users/" + id);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateUsersDto>(jsonData);
                updateUsersDto.KullaniciID = value.KullaniciID;

                if (updateUsersDto.EskiSifre == null)
                {
                    TempData["eskiSifre"] = "Bu alan boş bırakılamaz";
                    return RedirectToAction("UserInformation");
                }
                else if (updateUsersDto.YeniSifre == null)
                {
                    TempData["yeniSifre"] = "Bu alan boş bırakılamaz";
                    return RedirectToAction("UserInformation");
                }
                else if (updateUsersDto.YeniSifreTekrar == null)
                {
                    TempData["yeniSifreTekrar"] = "Bu alan boş bırakılamaz";
                    return RedirectToAction("UserInformation");
                }
                else if (updateUsersDto.EskiSifre != value.Sifre)
                {
                    TempData["sifre"] = "Eski şifre hatalı";
                    return RedirectToAction("UserInformation");
                }
                else if (updateUsersDto.YeniSifre != updateUsersDto.YeniSifreTekrar)
                {
                    TempData["yeniSifreHata"] = "Girilen yeni şifreler uyumsuz";
                    return RedirectToAction("UserInformation");
                }
                else
                {
                    var jsonData2 = JsonConvert.SerializeObject(updateUsersDto);
                    StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                    var responseMessage2 = await client.PutAsync("https://localhost:44365/api/Users/", stringContent);
                    if (responseMessage2.IsSuccessStatusCode)
                    {
                        TempData["msj"] = "Yapmış olduğunuz şifre değişiklikliği kaydedilmiştir.";
                        return RedirectToAction("UserInformation");
                    }
                }
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult LongTerm()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult FleetRentalRequest()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult RegisterMember()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterMemberPost(CreateUsersDto createUsersDto)
        {
            createUsersDto.Role = "Uye";
            string TC = "";
            string Email = "";
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                var responseMessage3 = await client.GetAsync("https://localhost:44365/api/Users");
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<List<ResultUsersDto>>(jsonData3);
                foreach (var item in value2)
                {
                    if (createUsersDto.TC == item.TC)
                    {
                        TC = item.TC;
                        if (TC != "")
                        {
                            ViewBag.TC = "Kimlik numarası başka kullanıcı adına kayıtlı";
                            return View("RegisterMember");
                        }
                    }
                    if (createUsersDto.Email == item.Email)
                    {
                        Email = item.Email;
                        if (Email != "")
                        {
                            ViewBag.email = "Mail adresi başka kullanıcı tarafından kullanılmaktadır";
                            return View("RegisterMember");
                        }
                    }
                }

                var jsonData2 = JsonConvert.SerializeObject(createUsersDto);
                StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var responseMessage2 = await client.PostAsync("https://localhost:44365/api/Users", stringContent);

                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                return View("RegisterMember");
            }
            return View("RegisterMember");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(CreateUsersDto createUsersDto)
        {
            var client = _httpClientFactory.CreateClient();
            string Email = createUsersDto.Email;
            string Sifre = createUsersDto.Sifre;
            //bool reMembermeMe = true;
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Users/" + Email + "," + Sifre);
            if (responseMessage.StatusCode.ToString() == "OK")
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultUsersDto>(jsonData);
                var Role = value.Role;
                var kullanici = value.Ad;
                var kullaniciID = value.KullaniciID.ToString();
                if (jsonData != "" || jsonData != null)
                {

                    //var result = await _signInManager.PasswordSignInAsync(value.Email,value.Sifre,reMembermeMe,lockoutOnFailure:false);
                    ClaimsIdentity identity = null;
                    identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Role, Role));
                    identity.AddClaim(new Claim(ClaimTypes.Name, kullanici));
                    identity.AddClaim(new Claim(ClaimTypes.Email, Email));
                    identity.AddClaim(new Claim(ClaimTypes.Surname, kullaniciID));


                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    //var claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name,Email)
                    //};
                    //    var useridentity = new ClaimsIdentity(claims, "Login");
                    //    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    //    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Default");
                }

            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Default");
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        public async Task<IActionResult> ReservationsForRentalCars(int islem = 1, int page = 1)
        {
            ViewBag.msj = TempData["msj"];
            var client = _httpClientFactory.CreateClient();
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;
                var responseMessage = await client.GetAsync($"https://localhost:44365/api/MemberTransactions?islem=" + islem + "&id=" + kullaniciID);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMemberTransactionsDto>>(jsonData);
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }
        public async Task<IActionResult> ReserveCancel(int id)
        {
            int islem = 5;
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44365/api/MemberTransactions?islem=" + islem + "&id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["msj"] = "Rezerve işleminiz iptal edilmiştir.";
                return RedirectToAction("ReservationsForRentalCars", "Default");
            }
            return View();
        }
        public async Task<IActionResult> RentedCars(int islem = 2, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;
                var responseMessage = await client.GetAsync($"https://localhost:44365/api/MemberTransactions?islem=" + islem + "&id=" + kullaniciID);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMemberTransactionsDto>>(jsonData);
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }
        public async Task<IActionResult> MySecondHandAppointments(int islem = 3, int page = 1)
        {
            ViewBag.msj = TempData["msj"];
            var client = _httpClientFactory.CreateClient();
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;
                var responseMessage = await client.GetAsync($"https://localhost:44365/api/MemberTransactions?islem=" + islem + "&id=" + kullaniciID);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMemberTransactionsDto>>(jsonData);
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }
        public async Task<IActionResult> AppointmentCancel(int id)
        {
            int islem = 6;
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:44365/api/MemberTransactions?islem=" + islem + "&id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["msj"] = "Randevunuz iptal edilmiştir.";
                return RedirectToAction("MySecondHandAppointments", "Default");
            }
            return View();
        }
        public async Task<IActionResult> PurchasedCars(int islem = 4, int page = 1)
        {
            var client = _httpClientFactory.CreateClient();
            if (@User.Identity.Name != null)
            {
                var kullaniciID = User.Claims.Where(x => x.Type == ClaimTypes.Surname).FirstOrDefault().Value;
                var responseMessage = await client.GetAsync($"https://localhost:44365/api/MemberTransactions?islem=" + islem + "&id=" + kullaniciID);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMemberTransactionsDto>>(jsonData);
                return View(value.ToPagedList(page, 10));
            }
            return View();
        }
    }
}
