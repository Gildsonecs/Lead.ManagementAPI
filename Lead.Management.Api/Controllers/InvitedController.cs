using AutoMapper;
using Lead.Management.Application.Interfaces;
using Lead.Management.Application.Models;
using Lead.Management.Domain.Models;
using Lead.Management.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lead.Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitedController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvitedRepository _invitedRepository;
        private readonly IInvitedApplication _invitedApplication;

        public InvitedController(IMapper mapper, IInvitedRepository invitedRepository, IInvitedApplication invitedApplication)
        {
            _mapper = mapper;
            _invitedRepository = invitedRepository;
            _invitedApplication = invitedApplication;
        }

        [HttpGet]       
        [ProducesResponseType(typeof(IEnumerable<InvitedModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var result = await _invitedRepository.GetAllAsync();

            if (result == null)
                return NotFound("Dados não encontrado");

            return Ok(_mapper.Map<IEnumerable<InvitedModel>>(result));
        }

        [HttpPost]
        [Route("Create-invited")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] InviteCreateModel invitedModel)
        {
            await _invitedApplication.CreateInvited(invitedModel);

            return Ok();
        }

        [HttpPatch]
        [Route("Accept")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch(Guid id)
        {
            var result = await _invitedRepository.GetByIdAsync(id);

            if (result == null)
                return NotFound("Dados não encontrado!");

            var model = _mapper.Map<InvitedModel>(result);
            await _invitedApplication.ChangeAccept(model);

            return Ok();
        }

        [HttpPatch]
        [Route("Decline")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeclinePatch(Guid id) 
        {
            var result = await _invitedRepository.GetByIdAsync(id);

            if (result == null)
                return NotFound("Dados não encontrado!");

            await _invitedApplication.ChangeDecline(result.Id);

            return Ok();
        }
    }
}
