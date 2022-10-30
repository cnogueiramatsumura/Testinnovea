using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Testinnovea.Models;
using Testinnovea.Services.Interfaces;

namespace Testinnovea.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAPIService _APIService;

        public HomeController(ILogger<HomeController> logger, IAPIService ApiService)
        {
            _logger = logger;
            _APIService = ApiService;
        }

        public IActionResult Index()
        {
            var viewModel = _APIService.GetAll();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
