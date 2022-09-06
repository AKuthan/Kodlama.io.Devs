using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLangugae;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            ProgramingLanguageGetByIdDto result = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            DeletedProgramingLanguageDto result = await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgramingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }
    }
}