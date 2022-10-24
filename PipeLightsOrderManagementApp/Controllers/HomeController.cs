﻿using Microsoft.AspNetCore.Mvc;
using PipeLightsOrderManagementApp.Models;
using System.Diagnostics;

namespace PipeLightsOrderManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string orderNumber)
        {
            ViewBag.OrderNumber = orderNumber;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewOrder()
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