using AutoMapper;
using Core.Entity;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PiesListViewModel, Pie>();
        }
    }
}
