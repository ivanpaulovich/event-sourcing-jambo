using Jambo.Domain.SeedWork;
using Jambo.KafkaBus;
using System;

namespace Jambo.ProcessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceBus serviceBus = new ServiceBus("10.17.12.46:32774", "blogs");

            serviceBus.OnReceive += ProcessDomainEventDelegate;

            serviceBus.Listen();

            Console.WriteLine("Aguardando..");
            Console.ReadLine();
        }

        static void ProcessDomainEventDelegate(string topic, int partition, long offSet, string value)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}