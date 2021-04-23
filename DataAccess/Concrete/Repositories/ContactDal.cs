using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.Repositories
{
  public  class ContactDal:GenericRepository<Contact>,IContactDal
    {
    }
}
