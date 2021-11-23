using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SalesApp.Panel.Web.Controllers
{
    public class SellersController : Controller
    {
        private readonly ISellerManagementService _seller;
        private readonly ILogger<SellersController> _logger;

        public SellersController(ISellerManagementService seller, ILogger<SellersController> logger)
        {
            _seller = seller;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View((await _seller.GetSellers()));
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "");
                throw;
            }
        }

        public IActionResult AddSeller() => View();

        [HttpPost]
        public async Task<IActionResult> AddSeller(SellerAddRequest model)
        {
            if (ModelState.IsValid)
            {
                await _seller.CreateSellerAsync(model);
                RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
