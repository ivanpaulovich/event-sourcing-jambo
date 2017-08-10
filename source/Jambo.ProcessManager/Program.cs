using Jambo.Domain.SeedWork;
using Jambo.KafkaBus;
using System;

namespace Jambo.ProcessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceBus serviceBus = new ServiceBus("192.168.99.100:9092", "blogsv1");

            serviceBus.OnReceive += ProcessDomainEventDelegate;

            serviceBus.Listen();

            Console.WriteLine("Aguardando..");
            Console.ReadLine();
        }

        static void ProcessDomainEventDelegate(string topic, int partition, long offSet, string value)
        {
            Console.WriteLine($"{topic} {partition} {offSet} {value}");
        }
    }
}