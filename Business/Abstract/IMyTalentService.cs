using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMyTalentService
    {
        List<MyTalent> GetAll();
        MyTalent GetById(int id);
        void Add(MyTalent myTalent);
        void Update(MyTalent myTalent);
        void Delete(MyTalent myTalent);

    }
}
