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
    public class MyTalentManager : IMyTalentService
    {
        IMyTalentDal _myTalentDal;

        public MyTalentManager(IMyTalentDal myTalentDal)
        {
            _myTalentDal = myTalentDal;
        }

        public void Add(MyTalent myTalent)
        {
            _myTalentDal.Insert(myTalent);
        }

        public void Delete(MyTalent myTalent)
        {
            _myTalentDal.Delete(myTalent);
        }

        public List<MyTalent> GetAll()
        {
            return _myTalentDal.List();
        }

        public MyTalent GetById(int id)
        {
            return _myTalentDal.Get(x => x.SkillID == id);
        }

        public void Update(MyTalent myTalent)
        {
            _myTalentDal.Update(myTalent);
        }
    }
}
