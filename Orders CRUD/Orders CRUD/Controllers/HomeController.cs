using Microsoft.AspNetCore.Mvc;
using Orders_CRUD.Models;
using Orders_CRUD.TCP;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Orders_CRUD
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allOrders = RequestHandler.getInfoForAllOrders();
            ViewBag.Orders = allOrders;

            var providerNames = RequestHandler.getProvidersNames();
            ViewBag.ProviderNames = providerNames;

            var orderItemNames = RequestHandler.getOrderItemNames();
            ViewBag.OrderItemNames = orderItemNames;

            var orderItemUnits = RequestHandler.getOrderItemUnits();
            ViewBag.OrderItemUnits = orderItemUnits;

            return View(allOrders);
        }
        [HttpPost]
        public IActionResult Index(List<string> providerNames)
        {
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