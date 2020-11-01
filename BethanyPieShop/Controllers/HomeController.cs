using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Iservice;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }

        public IActionResult Index()
        {


            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = pieRepository.PiesOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}
