using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.SQLServerBus
{
    public class QueueRepository : IQueueRepository
    {
        private readonly MessagingContext _context;

        public Message Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
