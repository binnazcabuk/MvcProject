using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        void Add(Category category);
        List<Category> GetAll();
        Category GetById(int id);
        void Delete(Category category);
        void Update(Category category);
    }
}
