using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Educations.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;

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
    }
}
