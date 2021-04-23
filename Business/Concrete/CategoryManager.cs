using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public  class CategoryManager
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public void Add(Category category)
        {
            if(category.CategoryName==""|| category.CategoryName.Length<=3||category.CategoryDescription==""
                || category.CategoryName.Length>=50)
            {
                //hata msj
            }
            else
            {
                _categoryDal.Insert(category);
            }
           
        }
    }
}
