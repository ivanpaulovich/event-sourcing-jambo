using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Jambo.Domain.Model;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.ServiceBus.Kafka
{
    public class Bus : IPublisher, ISubscriber
    {
        private readonly Config config;

        private readonly Producer<string, string> _producer;
        private readonly Consumer<string, string> _consumer;

        private readonly IMediator mediator;

        public Bus(Config config)
        {
            this.config = config;

            _producer = new Producer<string, string>(
                new Dictionary<string, object>()
                {{
                    "bootstrap.servers", config.BrokerList}}, 
                new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8));

            _consumer = new Consumer<string, string>(
                new Dictionary<string, object>()
                {{ "group.id", "simple-csharp-consumer" },
                    { "bootstrap.servers", config.BrokerList }},
                new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8));
        }

        public Bus(Config config, IMediator mediator)
            : this(config)
        {
            this.mediator = mediator;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            string data = JsonConvert.SerializeObject(domainEvent, Formatting.Indented);

            Message<string, string> message = await _producer.ProduceAsync(
                config.TopicName, domainEvent.GetType().AssemblyQualifiedName, data);
        }

        public void Listen()
        {
            Task.Run(() =>
            {
                _consumer.Assign(new List<TopicPartitionOffset>
                {
                    new TopicPartitionOffset(config.TopicName, 0, 0)
                });

                while (true)
                {
                    Message<string, string> msg;

                    if (_consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
                    {
                        Type eventType = Type.GetType(msg.Key);
                        DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(msg.Value, eventType);

                        mediator.Send(domainEvent).Wait();
                    }
                }
            });
        }

        public void Dispose()
        {
            _producer.Dispose();
            _consumer.Dispose();
        }

        public async Task Publish(IEnumerable<DomainEvent> domainEvents, Guid correlationId)
        {
            foreach (var domainEvent in domainEvents)
            {
                domainEvent.CorrelationId = correlationId;
                await Publish(domainEvent);
            }
        }
    }
}
