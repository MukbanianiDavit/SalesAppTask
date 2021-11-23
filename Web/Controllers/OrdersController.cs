using Microsoft.AspNetCore.Mvc;
using SalesApp.Infrastructure.Services.Interfaces;
using SalesApp.Infrastructure.Models.Models.RequestModels;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SalesApp.Panel.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderManagementService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderManagementService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View((await _orderService.GetAllOrdersAsync()).Orders);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "");
                throw;
            }
        }

        public IActionResult AddOrder() => View();

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderAddRequest model)
        {
            _logger.LogInformation($"params - model:{JsonConvert.SerializeObject(model)}");
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderService.AddOrderAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, $"params - model:{JsonConvert.SerializeObject(model)}");
                throw;
            }
        }

        public IActionResult AddSubOrder(string id)
        {
            _logger.LogInformation($"params - id:{JsonConvert.SerializeObject(id)}");
            try
            {
                return View(new SuborderAddRequest { OrderParentId = Guid.Parse(id) });
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, $"params - id:{JsonConvert.SerializeObject(id)}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSubOrder(SuborderAddRequest model)
        {
            _logger.LogInformation($"params - model:{JsonConvert.SerializeObject(model)}");
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderService.AddSuborderAsync(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, $"params - model:{JsonConvert.SerializeObject(model)}");
                throw;
            }
            return View(model);
        }
    }
}
