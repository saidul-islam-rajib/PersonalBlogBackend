using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;

namespace Sober.Api.Controllers.Posts
{
    [Route("[controller]")]
    public class PostsController : ApiController
    {
        [HttpGet]
        public IActionResult ListPosts()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
