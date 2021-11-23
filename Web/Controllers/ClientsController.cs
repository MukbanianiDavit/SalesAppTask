using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Panel.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientManagementService _clientService;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IClientManagementService clientService, ILogger<ClientsController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View((await _clientService.GetAllClientsAsync()).Clients);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, "");
                throw;
            }
        }

        public IActionResult AddClient() => View();

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientAddRequest model)
        {
            _logger.LogInformation($"params - model:{JsonConvert.SerializeObject(model)}");
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientService.AddClientAsync(model);
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

    }
}
