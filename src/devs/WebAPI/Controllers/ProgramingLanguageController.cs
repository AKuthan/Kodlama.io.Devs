﻿
using Application.Features.ProgramingLanguages.Commands;
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
    public class BrandController : BaseController
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
    }
}