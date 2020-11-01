using Core.Entity;
using System.Collections;
using System.Collections.Generic;

namespace Core.ViewModels
{
    public class HomeViewModel:IEnumerable
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }

        public IEnumerator GetEnumerator()
        {
            return this.PiesOfTheWeek.GetEnumerator();
        }

       

       
    }
}
