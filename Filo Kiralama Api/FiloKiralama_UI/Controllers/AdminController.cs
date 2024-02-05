using FiloKiralama_UI.Dtos.CarDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FiloKiralama_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

    }
}
