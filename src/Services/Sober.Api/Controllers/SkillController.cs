﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Skills.Commands;
using Sober.Application.Pages.Skills.Queries.Query;
using Sober.Contracts.Request.Skills;
using Sober.Contracts.Response.Skills;

namespace Sober.Api.Controllers
{
    [Route("skill")]
    public class SkillController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public SkillController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-new-skill")]
        public async Task<IActionResult> CreateSkill(SkillRequest request)
        {
            var command = _mapper.Map<CreateSkillCommand>(request);
            var result = await _mediator.Send(command);

            var response = result.Match(
                skill => Ok(_mapper.Map<SkillResponse>(skill)),
                errors => Problem(errors));

            return response;
        }

        [HttpGet]
        [Route("get-all-skills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var query = new GetAllSkillQuery();
            var skills = await _mediator.Send(query);
            if (skills is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<IEnumerable<SkillResponse>>(skills);
            return Ok(response);
        }
    }
}
