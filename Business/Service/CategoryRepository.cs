using Core.BethanyDbContext;
using Core.Entity;
using Core.Iservice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly BethanysPieShopDbContext context;

        public CategoryRepository(BethanysPieShopDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> AllCategories => context.Categories.Include(c=>c.Pies);
    }
}
