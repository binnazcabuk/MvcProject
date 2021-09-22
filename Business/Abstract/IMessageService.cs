using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox(string p);
        List<Message> GetAllSendbox(string p);
        List<Message> GetListUnRead(string p);
        List<Message> GetListTrash(string p);
        List<Message> GetAllAdminInbox();
        List<Message> GetListAdminTrash();
        List<Message> GetListAdminUnRead();
        List<Message> GetAllAdminSendbox();
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        void TrashDelete(Message message);

    }
}
