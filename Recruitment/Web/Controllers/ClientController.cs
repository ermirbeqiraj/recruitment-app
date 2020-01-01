using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Queries;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var clientsCmd = new GetClientsCommand();
            var result = await _mediator.Send(clientsCmd);

            return View();
        }
    }
}