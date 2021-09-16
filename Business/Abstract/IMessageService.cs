﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox();
        List<Message> GetAllSendbox();
        List<Message> GetListUnRead();
        List<Message> GetListTrash();
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        void TrashDelete(Message message);

    }
}
