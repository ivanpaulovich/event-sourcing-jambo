using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Jambo.Domain.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.KafkaBus
{
    public class ServiceBus : IServiceBus
    {
        private readonly string _brokerList;
        private readonly string _topicName;

        private readonly Producer<string, string> _producer;
        private readonly Consumer<string, string> _consumer;

        private ProcessDomainEventDelegate onReceive;
        public ProcessDomainEventDelegate OnReceive => onReceive;

        ProcessDomainEventDelegate IServiceBus.OnReceive {
            get => onReceive;
            set => onReceive = value; }

        public ServiceBus(string brokerList, string topicName)
        {
            _brokerList = brokerList;
            _topicName = topicName;

            _producer = new Producer<string, string>(
                new Dictionary<string, object>()
                {{
                    "bootstrap.servers", brokerList}}, 
                new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8));

            _consumer = new Consumer<string, string>(
                new Dictionary<string, object>()
                {{ "group.id", "simple-csharp-consumer" },
                    { "bootstrap.servers", brokerList }},
                new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8));
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            string data = JsonConvert.SerializeObject(domainEvent);

            Message<string, string> message = await _producer.ProduceAsync(
                _topicName, domainEvent.GetType().AssemblyQualifiedName, data);
        }

        public void Listen()
        {
            Task.Run(() =>
            {
                _consumer.Assign(new List<TopicPartitionOffset>
                {
                    new TopicPartitionOffset(_topicName, 0, 0)
                });

                while (true)
                {
                    Message<string, string> msg;

                    if (_consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
                    {
                        onReceive(msg.Topic, msg.Key, msg.Value);
                    }
                }
            });
        }

        public void Dispose()
        {
            _producer.Dispose();
            _consumer.Dispose();
        }

        public async Task Publish(IEnumerable<DomainEvent> domainEvents)
        {
            Guid correlationId = Guid.NewGuid();

            foreach (var domainEvent in domainEvents)
            {
                domainEvent.CorrelationId = correlationId;
                await Publish(domainEvent);
            }
        }
    }
}
