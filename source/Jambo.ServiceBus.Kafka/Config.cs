namespace Jambo.ServiceBus.Kafka
{
    public class Config
    {
        public string BrokerList { get; }
        public string TopicName { get; }

        public Config(string brokerList, string topicName)
        {
            this.BrokerList = brokerList;
            this.TopicName = topicName;
        }
    }
}
