using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Comments.Queries.Query;
using Sober.Application.Pages.Skills.Queries.Query;
using Sober.Contracts.Response.Comments;
using Sober.Contracts.Response.Skills;

namespace Sober.Api.Controllers
{
    [Route("[controller]")]
    public class SkillController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public SkillController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-all-skill")]
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
