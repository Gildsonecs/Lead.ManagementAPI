using AutoMapper;
using Lead.Management.Application.Models;
using Lead.Management.Domain.Models;
using Lead.Management.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lead.Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcceptedController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvitedRepository _invitedRepository;
        public AcceptedController(IMapper mapper, IInvitedRepository invitedRepository)
        {
            _mapper = mapper;
            _invitedRepository = invitedRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AcceptedModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var result = await _invitedRepository.GetAllAcceptAsync();

            if (result == null)
                return NotFound("Dados não encontrado!");

            return Ok(_mapper.Map<IEnumerable<AcceptedModel>>(result));
        }
    }
}
