﻿using Jambo.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Interfaces.Repository
{
    public interface ILoteReadOnlyRepository
    {
        ILote Consultar(Guid idLote);
        IEnumerable<ILote> Listar();
    }
}