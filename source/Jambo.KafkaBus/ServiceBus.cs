using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.KafkaBus
{
    public class ServiceBus : IServiceBus
    {
        private List<IEntity> _entities = new List<IEntity>();

        public void Attach(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void Detach(IEntity entity)
        {
            _entities.Remove(entity);
        }

        private readonly string _topicName;
        private readonly Producer<Null, string> _producer;
        private readonly Consumer<Null, string> _consumer;

        public ServiceBus(string brokerList, string topicName)
        {
            _topicName = topicName;

            _producer = new Producer<Null, string>(
                new Dictionary<string, object>() {{
                    "bootstrap.servers", brokerList
                }}, null, new StringSerializer(Encoding.UTF8));

            _consumer = new Consumer<Null, string>(
                new Dictionary<string, object>() {
                { "group.id", "simple-csharp-consumer" },
                { "bootstrap.servers", brokerList }},
                null, new StringDeserializer(Encoding.UTF8));
        }

        public Task Listen()
        {
            _consumer.Assign(new List<TopicPartitionOffset>
            {
                new TopicPartitionOffset(_topicName, 0, 0)
            });

            while (true)
            {
                Message<Null, string> msg;

                if (_consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
                {
                    Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");
                }
            }
        }

        public async Task Publish()
        {
            while (_domainEvents.Count > 0)
            {
                IEvent _event = _domainEvents.Dequeue();

                await Task.Run(() => Console.WriteLine(_event.ToString()));
                //Message<Null, string> message = await _producer.ProduceAsync(_topicName, null, DateTime.Now.ToString() + _event.ToString());
            }
        }
    }
}
