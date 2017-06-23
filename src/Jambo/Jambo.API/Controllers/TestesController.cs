using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Jambo.API.Controllers
{
    [Route("api/[controller]")]
    public class TestesController : Controller
    {

        public TestesController(IMediator mediator)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}