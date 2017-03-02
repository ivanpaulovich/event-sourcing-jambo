using System;
using Jambo.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Jambo.Infrastructure.EF.Entities
{
    public class EntityFactory : IEntityFactory
    {
        private readonly Dictionary<Type, Type> conversions = new Dictionary<Type, Type>() {
            { typeof(IEvento), typeof(Evento) },
            { typeof(ILote), typeof(Lote) },
            { typeof(IPedido), typeof(Pedido) }
        };

        public T CriarEntity<T>()
        {
            if (conversions.ContainsKey(typeof(T)))
            {
                return (T)Activator.CreateInstance(conversions[typeof(T)]);
            };

            throw new NotImplementedException(
                string.Format("Não existe um Validador implementado para a classe {0}.", typeof(T).ToString()));
        }
    }
}
