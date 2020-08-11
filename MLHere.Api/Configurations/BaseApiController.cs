using Microsoft.AspNetCore.Mvc;

namespace MLHere.Api.Configurations
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {

    }
}