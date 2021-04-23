using DataAccess.Abstract;
using Entity.Concrete;
using System;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class CategoryDal :GenericRepository<Category>, ICategoryDal
    {


      

    }
}
