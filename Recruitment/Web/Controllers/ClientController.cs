using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Queries;
using Web.Models;

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
            var cmd = new GetClientsQuery();
            var result = await _mediator.Send(cmd);

            return View(result);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ClientCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new RegisterClientCommand(model.Name, model.Website, model.Description);
                var result = await _mediator.Send(cmd);

                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(ClientController.Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _mediator.Send(new GetClientUpdateQuery(id));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ClientUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var updateClientCommand = new UpdateClientCommand(model.Id, model.Name, model.Website, model.Description);
                var result = await _mediator.Send(updateClientCommand);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(ClientController.Index));
                else
                    ModelState.AddModelError("", result.Error);
            }

            return View(model);
        }

        #region vacancies
        [Route("[controller]/vacancyof-({client:guid:required})/[action]")]
        public async Task<IActionResult> Vacancies(Guid client)
        {
            var cmd = new GetVacancyListQuery(client);
            var result = await _mediator.Send(cmd);

            ViewBag.Client = client;
            return View(result);
        }

        [Route("[controller]/vacancyof-({client:guid:required})/[action]")]
        public IActionResult CreateVacancy(Guid client)
        {
            ViewBag.Client = client;
            return View();
        }

        [HttpPost]
        [Route("[controller]/vacancyof-({client:guid:required})/[action]")]
        public async Task<IActionResult> CreateVacancy(Guid client, VacancyCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new OpenVacancyCommand(model.Title, model.Description, model.OpenDate, model.CloseDate, client);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction("Vacancies", new { client });
            }

            ViewBag.Client = client;
            return View(model);
        }

        [Route("[controller]/vacancyof-({client:guid:required})/[action]/{id}")]
        public async Task<IActionResult> EditVacancy(Guid client, Guid id)
        {
            var cmd = new GetVacancyQuery(id);
            var vacancy = await _mediator.Send(cmd);
            return View(vacancy);
        }

        [HttpPost]
        [Route("[controller]/vacancyof-({client:guid:required})/[action]/{id}")]
        public async Task<IActionResult> EditVacancy(Guid client, VacancyUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new UpdateVacancyCommand(model.Id, client, model.Title, model.Description, model.OpenDate, model.CloseDate);
                var result = await _mediator.Send(cmd);

                if (result.IsFailure)
                    ModelState.AddModelError("", result.Error);
                else
                    return RedirectToAction(nameof(ClientController.Vacancies), new { client });
            }

            return View(model);
        }


        [HttpPut]
        public async Task<IActionResult> CloseVacancy(Guid client, Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid identifier provided");

            var cmd = new CloseVacancyCommand(id, client);
            var result = await _mediator.Send(cmd);
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        #endregion

        #region requirements
        [Route("[controller]/{client}/vacancy-({vacancy:guid:required})/[action]")]
        public async Task<IActionResult> Requirements(Guid client, Guid vacancy)
        {
            ViewBag.Vacancy = vacancy;
            ViewBag.Client = client;
            var cmd = new GetRequirementListQuery(vacancy);
            var result = await _mediator.Send(cmd);
            return View(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetRequirement(Guid id)
        {
            var cmd = new GetRequirementQuery(id);
            var result = await _mediator.Send(cmd);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRequirement(RequirementUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new UpdateRequirementCommand(model.Id, model.VacancyId, model.ClientId, model.SkillType, model.RequirementType, model.Content);
                var result = await _mediator.Send(cmd);
                if (result.IsFailure)
                    ViewBag.Notify = result.Error; // todo: toastr
            }


            if (model.VacancyId != Guid.Empty)
                return RedirectToAction(nameof(ClientController.Requirements), new { client = model.ClientId, vacancy = model.VacancyId });
            else
                return RedirectToAction(nameof(ClientController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddRequirement(RequirementCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var cmd = new AddRequirementCommand(model.VacancyId, model.ClientId, model.SkillType, model.RequirementType, model.Content);
                var result = await _mediator.Send(cmd);

                if (result.IsFailure)
                    ViewBag.Notify = result.Error; // todo: toastr
            }

            if (model.VacancyId != Guid.Empty)
                return RedirectToAction(nameof(ClientController.Requirements), new { client = model.ClientId, vacancy = model.VacancyId });
            else
                return RedirectToAction(nameof(ClientController.Index));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRequirement(Guid vacancy, Guid clientId, Guid requirementId)
        {
            if (vacancy != Guid.Empty && clientId != Guid.Empty && requirementId != Guid.Empty)
            {
                var cmd = new RemoveRequirementCommand(requirementId, clientId, vacancy);
                var result = await _mediator.Send(cmd);

                if (result.IsFailure)
                    ViewBag.Notify = result.Error; // todo: toastr
            }
            return Ok();
        }
        #endregion
    }
}