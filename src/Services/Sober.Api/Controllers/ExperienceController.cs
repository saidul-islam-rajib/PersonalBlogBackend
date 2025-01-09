using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Experiences.Commands;
using Sober.Application.Pages.Experiences.Queries.Query;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Api.Controllers
{
    [Route("experience")]
    public class ExperienceController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ExperienceController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("users/{userId}/create")]
        public async Task<IActionResult> CreateExperience(ExperienceRequest request, Guid userId)
        {
            var command = _mapper.Map<CreateExperienceCommand>((request, userId));
            var result = await _mediator.Send(command);

            var response = result.Match(
                experience => Ok(_mapper.Map<ExperienceResponse>(experience)),
                errors => Problem(errors));

            return response;
        }

        [HttpGet]
        [Route("get-experiences")]
        public async Task<IActionResult> GetExperiences()
        {
            var query = new GetExperienceQuery();
            IEnumerable<Experience> experiences = await _mediator.Send(query);
            var response = _mapper.Map<IEnumerable<ExperienceResponse>>(experiences);

            return Ok(response);
        }
    }
}
