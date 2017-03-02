using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Jambo.WebAPI.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IAggregateFactory aggregateFactory;
        protected readonly IVendaIngressosService vendaIngressosService;

        public ControllerBase(
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
