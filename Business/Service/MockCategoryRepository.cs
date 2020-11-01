using Core.Entity;
using Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Service
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>  new List<Category>
        {
            new Category{CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies" },
            new Category{CategoryId=2, CategoryName="Cheese Cakes", Description="Cheesy all the way" },
            new Category{CategoryId=3, CategoryName="seasonal pies", Description="Get in mood for seasonal pies" }

        };
    }
}
