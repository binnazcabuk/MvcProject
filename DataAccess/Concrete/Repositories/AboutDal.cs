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
    public class AboutDal : IAboutDal
    {

        Context context = new Context();
        DbSet<About> _object;

        public void Delete(About entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(About entity)
        {
            throw new NotImplementedException();
        }

        public List<About> List()
        {
            throw new NotImplementedException();
        }

        public List<About> List(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(About entity)
        {
            throw new NotImplementedException();
        }
    }
}
