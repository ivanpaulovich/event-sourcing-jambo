using Jambo.Core.Aggregates;
using Jambo.Core.Domain;
using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Interfaces.Domain;
using Jambo.Core.Interfaces.Entities;
using Jambo.Core.Interfaces.Repository;
using Jambo.Core.Interfaces.Validation;
using Jambo.Infrastructure.Dapper.Repository;
using Jambo.Infrastructure.EF;
using Jambo.Infrastructure.EF.Entities;
using Jambo.Infrastructure.EF.Repository;
using Jambo.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jambo.WebAPI.IoC
{
    public static class JamboExtensions
    {
        public static void AddJambo(
            this IServiceCollection services, 
            string connectionString)
        {
            services.AddDbContext<VendasContext>(
                            options => options.UseSqlServer(connectionString,
                            p => p.UseRowNumberForPaging()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAggregateFactory, AggregateFactory>();
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IValidatorFactory, ValidatorFactory>();

            services.AddScoped<IEventoReadOnlyRepository, EventoReadOnlyRepository>();
            services.AddScoped<ILoteReadOnlyRepository, LoteReadOnlyRepository>();
            services.AddScoped<IPedidoWriteOnlyRepository, PedidoWriteOnlyRepository>();

            services.AddScoped<IVendaIngressosService, VendaIngressosService>();
        }
    }
}
