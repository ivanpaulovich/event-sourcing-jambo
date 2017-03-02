using System;
using Jambo.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Jambo.Infrastructure.EF.Entities
{
    public class Evento : IEvento
    {
        public virtual Guid ID { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime DataRealizacao { get; set; }

        public virtual ICollection<Lote> LotesNavigation { get; set; }
    }
}
