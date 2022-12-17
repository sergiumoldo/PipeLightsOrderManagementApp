using Microsoft.AspNetCore.Mvc;
using PipeLightsOrderManagementApp.Models;
using PipeLightsOrderManagementApp.Repositories;

namespace PipeLightsOrderManagementApp.Controllers
{
    public class OperationController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public OperationController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchInOrders(SearchModel model)
        {
            var operationRepository = new OperationRepository();
            List<OrderDto> searchList = operationRepository.Search(model);

            ViewBag.SearchedNumber = searchList.Count();

            return View(searchList);
            
        }

        [HttpPost]
        public IActionResult SortOrders(SortModel model)
        {

            var operationRepository = new OperationRepository();

            if (model.Sort == 1)
            {
                List<OrderDto> sortedList = operationRepository.SortByFirstName();
                return View(sortedList);
            }
            else if(model.Sort == 2)
            {
                List<OrderDto> sortedList = operationRepository.SortByFirstNameDesc();
                return View(sortedList);
            }
            else if (model.Sort == 3)
            {
                List<OrderDto> sortedList = operationRepository.SortByPrice();
                return View(sortedList);
            }
            else if (model.Sort == 4)
            {
                List<OrderDto> sortedList = operationRepository.SortByPriceDesc();
                return View(sortedList);
            }else

            return RedirectToAction("ShowAllOrders", "Order");
        }
    }
}
