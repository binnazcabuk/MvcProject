using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.List();
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetAllByWriterId(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
