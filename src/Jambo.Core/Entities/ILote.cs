using System;

namespace Jambo.Core.Entities
{
    public interface ILote
    {
        Guid ID { get; set; }
        Guid IDEvento { get; set; }
        DateTime DataLimite { get; set; }
        int Quantidade { get; set; }
    }
}
