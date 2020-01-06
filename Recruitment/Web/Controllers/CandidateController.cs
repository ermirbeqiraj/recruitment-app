using Domain.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
            if (ModelState.IsValid)
            {
                var cmd = new RegisterCandidateCommand(model.FirstName, model.LastName, model.Birthday, model.CurrentPosition, model.Note);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(CandidateController.Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var cmd = new GetCandidateQuery(id);
            var result = await _mediator.Send(cmd);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, CandidateModifyModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new UpdateCandidateCommand(model.Id, model.FirstName, model.LastName, model.Birthday, model.CurrentPosition, model.Note);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(CandidateController.Index));
            }

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (id != Guid.Empty)
            {
                var cmd = new RemoveCandidateCommand(id);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    return BadRequest("Failed to remove the candidate with error: " + result.Error);

                return Ok();
            }

            return BadRequest("Invalid id");
        }
    }
}