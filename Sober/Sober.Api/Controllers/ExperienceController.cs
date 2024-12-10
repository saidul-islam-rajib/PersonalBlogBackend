using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Experiences.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;

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
    }
}
