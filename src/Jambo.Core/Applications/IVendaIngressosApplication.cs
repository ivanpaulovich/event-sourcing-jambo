using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Core.Interfaces.Applications
{
    public interface IVendaIngressosApplication
    {
        void RealizarPedido(Guid idPedido, Guid idLote, Guid idCliente);
    }
}
