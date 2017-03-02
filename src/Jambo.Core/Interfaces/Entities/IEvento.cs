using System;

namespace Jambo.Core.Interfaces.Entities
{
    public interface IEvento
    {
        Guid ID { get; set; }
        string Titulo { get; set; }
        string Descricao { get; set; }
        DateTime DataRealizacao { get; set; }
    }
}
