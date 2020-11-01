using Core.Entity;
using System.Collections.Generic;

namespace Core.Iservice
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
