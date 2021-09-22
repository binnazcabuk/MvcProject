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

       
        public List<Message> GetAllInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus==true);
        }

        public List<Message> GetAllAdminInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin2@gmail.com" && x.MessageStatus == true);
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
        public List<Message> GetListUnRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(x => x.IsRead == false).ToList();
        }
        public List<Message> GetAllSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public List<Message> GetListTrash(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus ==false);
        }

        public void TrashDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetListAdminTrash()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin2@gmail.com" && x.MessageStatus == false);
        }

        public List<Message> GetListAdminUnRead()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin2@gmail.com").Where(x => x.IsRead == false).ToList();
        }

        public List<Message> GetAllAdminSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin2@gmail.com");
        }
    }
}
