using Domain.Constants;
using Domain.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Application.Queries;
using Web.Models;

namespace Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAppointmentsListQuery());
            return View(result);
        }

        public async Task<IActionResult> MakeAppointment()
        {
            var candidates = await _mediator.Send(new GetCandidateDropQuery());
            var vacancies = await _mediator.Send(new GetVacanciesDropQuery());

            ViewBag.AppointmentTypes = new SelectList(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>());

            var vm = new MakeAppointmentModel
            {
                StartsAt = DateTime.Now,
                Candidates = new SelectList(candidates, "Id", "Text"),
                Vacancies = new SelectList(vacancies, "Id", "Text")
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAppointment(MakeAppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new MakeAppointmentCommand(model.AppointmentType, model.StartsAt, model.CandidateId, model.VacancyId);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(AppointmentController.Index));
            }

            var candidates = await _mediator.Send(new GetCandidateDropQuery());
            var vacancies = await _mediator.Send(new GetVacanciesDropQuery());

            ViewBag.AppointmentTypes = new SelectList(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>());

            model.Candidates = new SelectList(candidates, "Id", "Text", model.CandidateId);
            model.Vacancies = new SelectList(vacancies, "Id", "Text", model.VacancyId);

            return View(model);
        }

        public async Task<IActionResult> UpdateAppointment(Guid id)
        {
            var cmd = new GetAppointmentQuery(id);
            var result = await _mediator.Send(cmd);

            if (result == null)
                return NotFound();

            var candidates = await _mediator.Send(new GetCandidateDropQuery());
            var vacancies = await _mediator.Send(new GetVacanciesDropQuery());

            ViewBag.AppointmentTypes = new SelectList(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>());

            result.Candidates = new SelectList(candidates, "Id", "Text", result.CandidateId);
            result.Vacancies = new SelectList(vacancies, "Id", "Text", result.VacancyId);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAppointment(Guid id, UpdateAppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new UpdateAppointmentCommand(id, model.AppointmentType, model.StartsAt, model.CandidateId, model.VacancyId);
                var result = await _mediator.Send(cmd);

                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(AppointmentController.Index));
            }

            var candidates = await _mediator.Send(new GetCandidateDropQuery());
            var vacancies = await _mediator.Send(new GetVacanciesDropQuery());

            ViewBag.AppointmentTypes = new SelectList(Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>());

            model.Candidates = new SelectList(candidates, "Id", "Text", model.CandidateId);
            model.Vacancies = new SelectList(vacancies, "Id", "Text", model.VacancyId);

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAppointment(Guid id)
        {
            var cmd = new RemoveAppointmentCommand(id);
            var result = await _mediator.Send(cmd);
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}