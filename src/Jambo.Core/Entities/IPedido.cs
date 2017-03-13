using System;

namespace Jambo.Core.Entities
{
    public interface IPedido
    {
        Guid ID { get; set; }
        Guid IDLote { get; set; }
        Guid IDCliente { get; set; }
        DateTime DataEmissao { get; set; }
    }
}
