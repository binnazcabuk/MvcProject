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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

       // [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAll()
        {
            return _messageDal.List();
        }

        //[CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllInbox(string parameter)
        {
            return _messageDal.List(x => x.ReceiverMail == parameter);
        }

        //[CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllSendbox(string parameter)
        {
            return _messageDal.List(x => x.SenderMail == parameter).Where(x => x.IsDraft == false).ToList();
        }

       // [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllUnRead()
        {
            return _messageDal.List(x => x.ReceiverMail == "binnaz@gmail.com").Where(x => x.IsRead == false).ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

       // [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        //[CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

       // [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> IsDraft()
        {
            return _messageDal.List(x => x.IsDraft == true);
        }

        public void SaveDraftAdd(Message message)
        {
            _messageDal.Insert(message);
        }
    }
}
