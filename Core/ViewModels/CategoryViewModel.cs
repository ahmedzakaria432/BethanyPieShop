using System.Collections.Generic;

namespace Core.ViewModels
{
    public class CategoryViewModel
    {
      
        
    }





    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int ID);
        void Insert(TEntity EntityName);
        void Update(TEntity EntityName);
        void Delete(int EntityNameId);
        void save();

    }

}
