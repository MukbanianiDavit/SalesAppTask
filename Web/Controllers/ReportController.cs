using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesApp.Infrastructure.Models.Models.ViewModels;
using SalesApp.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Panel.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IOrderManagementService _orderManagement;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IOrderManagementService orderManagement, ILogger<ReportController> logger)
        {
            _orderManagement = orderManagement;
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<OrderViewModel> GetData(DateTime from, DateTime to)
        {
            _logger.LogInformation($"params - from:{from}; to:{to}");
            try
            {
                return await _orderManagement.GetOrderBetweenAsync(from, to);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"params - from:{from}; to:{to}");
                throw;
            }
        }
    }
}
