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



