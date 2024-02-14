﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tcc_chat.Models;
using tcc_chat.Services;

namespace tcc_chat.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.ShowEasterEgg = true;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
