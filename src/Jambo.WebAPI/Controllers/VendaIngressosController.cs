using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jambo.WebAPI.DTOs;
using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Exceptions;
using Jambo.Core.Interfaces.Domain;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Jambo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class VendaIngressosController : ControllerBase
    {
        public VendaIngressosController(
            IUnitOfWork unitOfWork,
            IAggregateFactory aggregateFactory,
            IVendaIngressosService vendaIngressosService) : base(
                unitOfWork,
                aggregateFactory,
                vendaIngressosService)
        {

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IPedidoIngresso pedidoIngresso = aggregateFactory.CriarAggregate<IPedidoIngresso>();

                    pedidoIngresso.Reservar(pedido.IDEvento, pedido.IDLote);

                    vendaIngressosService.EmitirIngressoParaCliente(
                        pedidoIngresso, pedido.IDCliente);

                    if (unitOfWork.SaveChanges() == 0)
                        throw new JamboException(42, "Erro de comunicação com o banco de dados");

                    return Ok(pedidoIngresso);
                }
                else
                    return BadRequest("Pedido inválido.");
            }
            catch (JamboException jamboEx)
            {
                return BadRequest(jamboEx.Mensagem);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
