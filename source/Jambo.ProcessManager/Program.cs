using Jambo.Domain.SeedWork;
using Jambo.KafkaBus;
using System;

namespace Jambo.ProcessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceBus serviceBus = new ServiceBus("10.0.75.1:9092", "jambo");

            serviceBus.OnReceive += ProcessDomainEventDelegate;

            serviceBus.Listen();

            Console.WriteLine("Aguardando..");
            Console.ReadLine();
        }

        static void ProcessDomainEventDelegate(string topic, string key, string value)
        {
            Console.WriteLine($"{topic} {key} {value}");
        }
    }
}