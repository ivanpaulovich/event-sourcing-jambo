namespace Jambo.Consumer.Infrastructure.ServiceBus
{
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

    public class Bus : ISubscriber
    {
        public readonly string brokerList;
        public readonly string topic;

        private static Dictionary<string, object> constructConfig(string brokerList, bool enableAutoCommit) =>
            new Dictionary<string, object>
            {
                { "group.id", "jambo-consumer" },
                { "enable.auto.commit", enableAutoCommit },
                { "auto.commit.interval.ms", 5000 },
                { "statistics.interval.ms", 60000 },
                { "bootstrap.servers", brokerList },
                { "default.topic.config", new Dictionary<string, object>()
                    {
                        { "auto.offset.reset", "smallest" }
                    }
                }
            };

        public Bus(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;
        }

        public void Listen(IMediator mediator)
        {
            using (var consumer = new Consumer<string, string>(constructConfig(brokerList, true), new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnPartitionEOF += (_, end)
                    => Console.WriteLine($"Reached end of topic {end.Topic} partition {end.Partition}, next message will be at offset {end.Offset}");

                consumer.OnError += (_, error)
                    => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                    => Console.WriteLine($"Error consuming from topic/partition/offset {msg.Topic}/{msg.Partition}/{msg.Offset}: {msg.Error}");

                consumer.OnOffsetsCommitted += (_, commit) =>
                {
                    Console.WriteLine($"[{string.Join(", ", commit.Offsets)}]");

                    if (commit.Error)
                    {
                        Console.WriteLine($"Failed to commit offsets: {commit.Error}");
                    }
                    Console.WriteLine($"Successfully committed offsets: [{string.Join(", ", commit.Offsets)}]");
                };

                consumer.OnPartitionsAssigned += (_, partitions) =>
                {
                    Console.WriteLine($"Assigned partitions: [{string.Join(", ", partitions)}], member id: {consumer.MemberId}");
                    consumer.Assign(partitions);
                };

                consumer.OnPartitionsRevoked += (_, partitions) =>
                {
                    Console.WriteLine($"Revoked partitions: [{string.Join(", ", partitions)}]");
                    consumer.Unassign();
                };

                consumer.OnStatistics += (_, json)
                    => Console.WriteLine($"Statistics: {json}");

                consumer.Subscribe(this.topic);

                Console.WriteLine($"Subscribed to: [{string.Join(", ", consumer.Subscription)}]");

                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit.");
                while (!cancelled)
                {
                    Message<string, string> msg;
                    if (consumer.Consume(out msg, TimeSpan.FromSeconds(1)))
                    {
                        Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");

                        try
                        {
                            Type eventType = Type.GetType(msg.Key);
                            DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(msg.Value, eventType);
                            mediator.Send(domainEvent).Wait();
                        }
                        catch (DomainException ex)
                        {
                            Console.WriteLine(ex.BusinessMessage);
                        }
                        catch (TransactionConflictException ex)
                        {
                            Console.WriteLine(ex.DomainEvent.ToString());
                        }
                        catch (JamboException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
