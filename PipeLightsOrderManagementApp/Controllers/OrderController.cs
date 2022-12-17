using Microsoft.AspNetCore.Mvc;
using PipeLightsOrderManagementApp.Models;
using PipeLightsOrderManagementApp.Repositories;
using System.Data.SqlClient;

namespace PipeLightsOrderManagementApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public OrderController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult InsertIntoDB(OrderDto model)
        {
            var orderRepositories = new OrderRepositories();

                orderRepositories.Insert(model);

            TempData["value"] = "OK";

            return RedirectToAction("Index", "Home", new { orderNumber = model.OrderNumber });
            
        }


        public IActionResult ShowAllOrders()
        {
            var orderRepositories = new OrderRepositories();
            List<OrderDto> order = orderRepositories.GetAll();

            decimal allOrders = order.Count();
            ViewBag.OrdersNumber = allOrders;

            decimal male = 0;
            decimal female = 0;

            decimal website = 0;
            decimal instagram = 0;
            decimal facebook = 0;
            decimal telefon = 0;
            decimal targ = 0;

            foreach (var orderItem in order)
            {
                if (orderItem.LastName == "M")
                {
                    male++;
                    decimal malePercent = (male / allOrders) * 100;

                    ViewBag.GenderM = male;
                    ViewBag.MalePercent = malePercent.ToString("#.#");
                }
                else
                {
                    female++;
                    decimal femalePercent = (female / allOrders) * 100;

                    ViewBag.GenderF = female;
                    ViewBag.FemalePercent = femalePercent.ToString("#.#");
                }
           

                if (orderItem.Channel == "Website")
                {
                    website++;
                    decimal websitePercent = (website / allOrders) * 100;

                    ViewBag.Website = website;
                    ViewBag.WebsitePercent = websitePercent.ToString("#.#");
                }
                else if (orderItem.Channel == "Instagram")
                {
                    instagram++;
                    decimal instagramPercent = (instagram / allOrders) * 100;

                    ViewBag.Instagram = instagram;
                    ViewBag.InstagramPercent = instagramPercent.ToString("#.#");
                }
                else if (orderItem.Channel == "Facebook")
                {
                    facebook++;
                    decimal facebookPercent = (facebook / allOrders) * 100;

                    ViewBag.Facebook = facebook;
                    ViewBag.FacebookPercent = facebookPercent.ToString("#.#");
                }
                else if (orderItem.Channel == "Telefon")
                {
                    telefon++;
                    decimal telefonPercent = (telefon / allOrders) * 100;

                    ViewBag.Telefon = telefon;
                    ViewBag.TelefonPercent = telefonPercent.ToString("#.#");
                }
                else if (orderItem.Channel == "Targ")
                {
                    targ++;
                    decimal targPercent = (targ / allOrders) * 100;

                    ViewBag.Targ = targ;
                    ViewBag.TargPercent = targPercent.ToString("#.#");
                }
            }

            return View(order);
        }

        public IActionResult ShowOrderDetails(int id)
        {
            var orderRepositories = new OrderRepositories();
            OrderDto order = orderRepositories.GetById(id);

            return View(order);
        }


        public IActionResult Edit(int id)
        {
            var orderRepositories = new OrderRepositories();
            OrderDto orderToEdit = orderRepositories.GetById(id);

            return View(orderToEdit);
        }


        [HttpPost]
        public IActionResult Edit(OrderDto model)
        {
            var orderRepositories = new OrderRepositories();

            orderRepositories.Update(model);

            return RedirectToAction("ShowAllOrders", "Order");
        }

        public IActionResult DeleteOrder(int id)
        {
            var orderRepositories = new OrderRepositories();
            OrderDto orderToDelete = orderRepositories.GetById(id);

            ViewBag.OrderNumber = orderToDelete.OrderNumber;
            ViewBag.Id = orderToDelete.Id;

            return View(orderToDelete);

        }

        public IActionResult Delete(int id)
        {
            var orderRepositories = new OrderRepositories();
            orderRepositories.Delete(id);

            return RedirectToAction("ShowAllOrders", "Order");
        }

    }
}



