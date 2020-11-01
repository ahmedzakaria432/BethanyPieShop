using Core.Entity;
using Core.ViewModels;
using System.Collections.Generic;

namespace Core.Iservice
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int id);
        PiesListViewModel PiesListView(string v);
    }
}
