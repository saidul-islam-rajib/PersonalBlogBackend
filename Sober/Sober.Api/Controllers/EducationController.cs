using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Educations.Commands;
using Sober.Application.Pages.Educations.Queries.Query;
using Sober.Application.Pages.Experiences.Queries.Query;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Api.Controllers
{
    [Route("education")]
    public class EducationController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public EducationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("users/{userId}/create")]
        public async Task<IActionResult> CreateExperience(EducationRequest request, Guid userId)
        {
            var command = _mapper.Map<CreateEducationCommand>((request, userId));
            var result = await _mediator.Send(command);

            var response = result.Match(
                education => Ok(_mapper.Map<EducationResponse>(education)),
                errors => Problem(errors));

            return response;
        }

        [HttpGet]
        [Route("get-educations")]
        public async Task<IActionResult> GetEducations()
        {
            var query = new GetEducationQuery();
            IEnumerable<Education> educations = await _mediator.Send(query);
            var response = _mapper.Map<IEnumerable<EducationResponse>>(educations);

            return Ok(response);
        }
    }
}
