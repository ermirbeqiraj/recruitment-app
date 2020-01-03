using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Queries;
using Web.Models;

namespace Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var cmd = new GetCandidateListQuery();
            var result = await _mediator.Send(cmd);
            return View(result);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CandidateRegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var cmd = new RegisterCandidateCommand(model.Name, model.Birthday, model.CurrentPosition, model.Note);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(CandidateController.Index));
            }

            return View(model);
        }
    }
}