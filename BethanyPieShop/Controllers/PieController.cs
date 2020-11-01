using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service;
using Core.Iservice;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository,ICategoryRepository categoryRepository)
        {
            this._pieRepository = pieRepository;
            this._categoryRepository = categoryRepository;
        }
        public ViewResult List(string category)
        {
            var piesListViewModel = new PiesListViewModel();

            if (string.IsNullOrEmpty(category))
            {
                piesListViewModel.CurrentCategory = "All Pies";
                piesListViewModel.Pies = _pieRepository.AllPies.OrderBy(k => k.PieId);
            }
            else
            {
                piesListViewModel.CurrentCategory = category;
                piesListViewModel.Pies = _categoryRepository.AllCategories.
                    SingleOrDefault(c => c.CategoryName == category).Pies;
            }

            return View(piesListViewModel); 
        }
        public IActionResult Details(int id)
        {
            var Pie = _pieRepository.GetPieById(id);
            if (Pie == null)
            {
                return NotFound();
            }
            return View(Pie);

        }
    } 
}
