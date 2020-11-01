using Core.BethanyDbContext;
using Core.Entity;
using Core.Iservice;
using Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Service
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext context;

        public PieRepository(BethanysPieShopDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Pie> AllPies
        {
            get{
                return context.Pies.Include(c => c.Category);

             }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int id)
        {
            return context.Pies.FirstOrDefault(p => p.PieId == id);
        }

        public PiesListViewModel PiesListView(string CurrentCategory)
        {
            var PiesList = new PiesListViewModel();
            PiesList.CurrentCategory = CurrentCategory;
            PiesList.Pies = AllPies;
            return PiesList;
        }
    }

    }

