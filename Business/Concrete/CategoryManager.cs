﻿using Business.Abstract;
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

     
        public void Add(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
             _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.List();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);
        }
    }
}
