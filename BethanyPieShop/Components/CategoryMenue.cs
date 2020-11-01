using Core.Iservice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Components
{
    public class CategoryMenue:ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenue(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult  Invoke( )
        {
            var categories= categoryRepository.AllCategories.OrderBy(c=>c.CategoryName) ;



            return View(categories);
        }

    }
}
