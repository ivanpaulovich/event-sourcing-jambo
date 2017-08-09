namespace Jambo.SQLServerBus
{
    public interface IQueueRepository
    {
        void Enqueue(Message message);
        Message Dequeue();
    }
}
