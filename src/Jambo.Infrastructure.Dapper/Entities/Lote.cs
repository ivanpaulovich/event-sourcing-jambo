using System;
using Jambo.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Jambo.Infrastructure.Dapper.Entities
{
    public class Lote : ILote
    {
        public Guid ID { get; set; }
        public Guid IDEvento { get; set; }
        public DateTime DataLimite { get; set; }
        public int Quantidade { get; set; }
    }
}
