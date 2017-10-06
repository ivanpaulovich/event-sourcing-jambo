using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Jambo.Domain.Exceptions;
using Jambo.Domain.Model;
using Jambo.Domain.ServiceBus;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure.ServiceBus
{
    public class Bus : ISubscriber
    {
        public readonly string brokerList;
        public readonly string topic;

        private readonly Consumer<string, string> consumer;

        public Bus(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;

            consumer = new Consumer<string, string>(
                new Dictionary<string, object>()
                {
                    { "group.id", "consumer" },
                    { "bootstrap.servers", brokerList }
                }, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8));
        }

        public void Listen(IMediator mediator)
        {
            Task.Run(() =>
            {
                consumer.Assign(new List<TopicPartitionOffset>
                {
                    new TopicPartitionOffset(topic, 0, 0)
                });

                while (true)
                {
                    Message<string, string> msg;

                    if (consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
                    {
                        try
                        {
                            Type eventType = Type.GetType(msg.Key);
                            DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(msg.Value, eventType);

                            Console.WriteLine($"CorrelationId: {domainEvent.Header.CorrelationId}");
                            Console.WriteLine($"UserName: {domainEvent.Header.UserName}");
                            Console.WriteLine($"CreatedDate: {domainEvent.CreatedDate}");
                            Console.WriteLine($"Type: {msg.Key}");
                            Console.WriteLine($"AggregateRootId: {domainEvent.AggregateRootId}");
                            Console.WriteLine($"Version: {domainEvent.Version}");
                            Console.WriteLine($"Raw: {msg.Value}");
                            Console.WriteLine();

                            mediator.Send(domainEvent).Wait();
                        }
                        catch (DomainException ex)
                        {
                            Console.WriteLine(ex.BusinessMessage);
                        }
                        catch (TransactionConflictException ex)
                        {
                            Console.WriteLine(ex.AggregateRoot.ToString() + ex.DomainEvent.ToString());
                        }
                        catch (JamboException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            });
        }

        public void Dispose()
        {
            consumer.Dispose();
        }
    }
}
