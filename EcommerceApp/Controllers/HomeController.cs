using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceCore.Interfaces;
using EcommerceCore.Models;
using EcommerceCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICar _car;
        public HomeController(ILogger<HomeController> logger, ICar car)
        {
            _logger = logger;
            _car = car;
           
        }

        public async Task<IActionResult> Index(int page)
        {
            var cars = await _car.GetAllCars();
            PaginationViewModel result = new PaginationViewModel();

            result.PageSize = 4;
            result.CurrentPage = page == 0 ? 1 : page;
            double pages = (double)cars.Count / result.PageSize;
            result.NumberPages = (int) Math.Round(pages, 0, MidpointRounding.AwayFromZero);

            var skip = 4 * (Convert.ToInt32(result.CurrentPage) - 1);

            result.Cars = cars.Skip(skip).Take(result.PageSize).ToList();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Detail(string Id)
        {
            var car = await _car.GetACars(Id);
            return View(car);
        }
    }
}
