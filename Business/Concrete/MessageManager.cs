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
        public List<Message> GetAllInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "binnaz@gmail.com" && x.MessageStatus==true);
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
            _messageDal.Update(message);
        }
        public List<Message> GetListUnRead()
        {
            return _messageDal.List(x => x.ReceiverMail == "binnaz@gmail.com").Where(x => x.IsRead == false).ToList();
        }
        public List<Message> GetAllSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "binnaz@gmail.com");
        }

        public List<Message> GetListTrash()
        {
            return _messageDal.List(x => x.ReceiverMail == "binnaz@gmail.com" && x.MessageStatus ==false);
        }

        public void TrashDelete(Message message)
        {
            _messageDal.Delete(message);
        }
    }
}
