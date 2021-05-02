using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }



        //GenericRepository<Category> categoryDal = new GenericRepository<Category>();



        //public List<Category> GetAll()
        //{
        //    return categoryDal.List();
        //}

        //public void Add(Category category)
        //{
        //    if(category.CategoryName==""|| category.CategoryName.Length<=3||category.CategoryDescription==""
        //        || category.CategoryName.Length>=50)
        //    {
        //        //hata msj
        //    }
        //    else
        //    {
        //        categoryDal.Insert(category);
        //    }

        //}
        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }
    }
}
