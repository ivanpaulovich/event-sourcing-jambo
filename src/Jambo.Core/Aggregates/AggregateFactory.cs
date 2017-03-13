using Jambo.Core.Interfaces.Aggregates;
using System;
using System.Collections.Generic;

namespace Jambo.Core.Aggregates
{
    public class AggregateFactory : IAggregateFactory
    {
        private readonly Dictionary<Type, Type> conversions = new Dictionary<Type, Type>() {
            { typeof(IPedidoIngresso), typeof(PedidoIngresso) }
        };

        public T Criar<T>()
        {
            if (conversions.ContainsKey(typeof(T)))
            {
                return (T)Activator.CreateInstance(conversions[typeof(T)]);
            };

            throw new NotImplementedException(
                string.Format("Não existe um Aggregate implementado para a interface {0}.", typeof(T).ToString()));
        }
    }
}
