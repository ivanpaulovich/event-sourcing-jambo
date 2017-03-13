using Jambo.Core.Domain;
using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Application
{
    public class ApplicationBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IAggregateFactory aggregateFactory;
        protected readonly IVendaIngressosService vendaIngressosService;

        public ApplicationBase(
            IUnitOfWork unitOfWork,
            IAggregateFactory aggregateFactory,
            IVendaIngressosService vendaIngressosService)
        {
            this.unitOfWork = unitOfWork;
            this.aggregateFactory = aggregateFactory;
            this.vendaIngressosService = vendaIngressosService;
        }
    }
}
