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
    public class ImageFileManager : IImageFileService
    {
       private IImageFileDal _imageDal;

        public ImageFileManager(IImageFileDal imageDal)
        {
            _imageDal = imageDal;
        }

        public List<ImageFile> GetAll()
        {
           return _imageDal.List();
        }
    }
}
